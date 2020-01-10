using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogMyTime.Communication;
using LogMyTime.Entities;

namespace LogMyTime
{
    public sealed class Client
    {
        private readonly IProxy _proxy;

        private readonly List<Customer> _customers;

        private readonly List<Activity> _activities;

        private readonly List<Project> _projects;

        private DateTime _lastChangeSet;

        public Client(string apiKey)
        {
            _proxy = new Proxy(apiKey);

            _customers = new List<Customer>();
            _activities = new List<Activity>();
            _projects = new List<Project>();
            _lastChangeSet = DateTime.MinValue;
        }

        public async Task<bool> Refresh(CancellationToken cancellationToken)
        {
            var result = false;
            var changeSet = await _proxy.GetChangeSet(_lastChangeSet, cancellationToken);

            // Update customers (if required)
            if (changeSet.ChangedClients > 0)
            {
                result = true;
                var customers = await _proxy.GetCustomers(cancellationToken);
                _customers.Clear();
                _customers.AddRange(customers);
            }

            // Update projects (if required)
            if (changeSet.ChangedProjects > 0)
            {
                result = true;
                var projects = await _proxy.GetProjects(cancellationToken);
                _projects.Clear();
                _projects.AddRange(projects);
            }

            // Update tasks
            if (changeSet.ChangedTasks > 0)
            {
                result = true;
                var activities = await _proxy.GetActivities(cancellationToken);
                _activities.Clear();
                _activities.AddRange(activities);
            }

            _lastChangeSet = changeSet.CurrentServerTime;
            return result;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customers.ToArray();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _projects.ToArray();
        }

        public IEnumerable<Activity> GetActivities()
        {
            return _activities.ToArray();
        }
    }
}
