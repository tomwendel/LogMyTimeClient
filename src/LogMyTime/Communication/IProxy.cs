using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogMyTime.Entities;

namespace LogMyTime.Communication
{
    /// <summary>
    /// Communication proxy for the LogMyTime API
    /// </summary>
    public interface IProxy
    {
        #region Projects

        /// <summary>
        /// Returns a list of projects
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>List of projects</returns>
        Task<IEnumerable<Project>> GetProjects(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the project with the given id
        /// </summary>
        /// <param name="projectId">project id</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>project</returns>
        Task<Project> GetProjectById(int projectId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="project">new project</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>new project</returns>
        Task<Project> CreateProject(Project project, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the given project
        /// </summary>
        /// <param name="project">project</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task UpdateProject(Project project, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the project with the given id
        /// </summary>
        /// <param name="projectId">project id</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task DeleteProject(int projectId, CancellationToken cancellationToken);

        #endregion

        #region Customers

        /// <summary>
        /// Returns a list of customers
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>List of customers</returns>
        Task<IEnumerable<Customer>> GetCustomers(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the customer with the given id
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>customer</returns>
        Task<Customer> GetCustomerById(int customerId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer">new customer</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>new customer</returns>
        Task<Customer> CreateCustomer(Customer customer, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the given customer
        /// </summary>
        /// <param name="customer">customer to update</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task UpdateCustomer(Customer customer, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the customer with the given id
        /// </summary>
        /// <param name="customerId">customer id</param>
        /// <param name="cancellationToken"></param>
        Task DeleteCustomer(int customerId, CancellationToken cancellationToken);

        #endregion

        #region Activities

        /// <summary>
        /// Returns a list of activities
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>list of activities</returns>
        Task<IEnumerable<Activity>> GetActivities(CancellationToken cancellationToken);

        /// <summary>
        /// Returns the activity with the given id
        /// </summary>
        /// <param name="activityId">activity id</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>activity</returns>
        Task<Activity> GetActivityById(int activityId, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new activity
        /// </summary>
        /// <param name="activity">new activity</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>activity</returns>
        Task<Activity> CreateActivity(Activity activity, CancellationToken cancellationToken);

        /// <summary>
        /// Updates the given activity
        /// </summary>
        /// <param name="activity">activity to update</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task UpdateActivity(Activity activity, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the activity with the given id
        /// </summary>
        /// <param name="activityId">activity id</param>
        /// <param name="cancellationToken">cancellation token</param>
        Task DeleteActivity(int activityId, CancellationToken cancellationToken);

        #endregion

        #region TimeEntries

        #endregion

        #region Users

        #endregion

        #region Stopwatch

        /// <summary>
        /// Returns the time entry for a running stop watch.
        /// </summary>
        Task<TimeEntry> CurrentStopWatch(CancellationToken cancellationToken);

        /// <summary>
        /// Starts a new stop watch and returns the related time entry.
        /// </summary>
        Task<TimeEntry> StartStopWatch(int projectId, int taskId, CancellationToken cancellationToken,
            bool? billable = null, string comment = null);

        /// <summary>
        /// Stops the current stop watch and returns the related time entry.
        /// </summary>
        Task<TimeEntry> HaltStopWatch(CancellationToken cancellationToken);

        #endregion

        #region Change Log

        /// <summary>
        /// Returns a change log since the last request
        /// </summary>
        /// <param name="lastRequest">last request time (server time)</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>change set</returns>
        Task<ChangeSet> GetChangeSet(DateTime lastRequest, CancellationToken cancellationToken);

        #endregion
    }
}
