using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using LogMyTime.Entities;
using Newtonsoft.Json;
using Task = LogMyTime.Entities.Task;

namespace LogMyTime.Communication
{
    public sealed class Proxy : IProxy
    {
        private readonly HttpClient _client;

        public Proxy(string apiKey)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.logmytime.de/v1/api.svc/")
            };

            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-LogMyTimeApiKey", apiKey);
            _client.DefaultRequestHeaders.Add("X-UserAgent", $"Tom Wendels Client {Assembly.GetCallingAssembly().GetName().Version}");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region Projects

        public async Task<IEnumerable<Project>> GetProjects(CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri("Projects", UriKind.Relative), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ResponseList<Project>>>(content).D.Results;
            }
        }

        public async Task<Project> GetProjectById(int projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> CreateProject(Project project, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateProject(Project project, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteProject(int projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Clients

        public async Task<IEnumerable<Client>> GetClients(CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri("Clients", UriKind.Relative), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ResponseList<Client>>>(content).D.Results;
            }
        }

        public Task<Client> GetClientById(int clientId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Client> CreateClient(Client client, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClient(Client client, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClient(int clientId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Tasks

        public async Task<IEnumerable<Task>> GetTasks(CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri("Tasks", UriKind.Relative), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ResponseList<Task>>>(content).D.Results;
            }
        }

        public Task<Task> GetTaskById(int taskId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Task> CreateTask(Task task, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTask(Task task, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(int taskId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TimeEntries

        #endregion

        #region Users

        #endregion

        #region Stopwatch

        /// <summary>
        /// Liefert den Zeiteintrag der laufenden Stoppuhr mit allen zugehörigen Parametern zurück 
        /// </summary>
        public async Task<TimeEntry> CurrentStopWatch(CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri("CurrentStopWatch", UriKind.Relative), cancellationToken))
            {
                // Stop if resource is not available
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<TimeEntry>>(content).D;
            }
        }

        /// <summary>
        /// Startet eine neue Stoppuhr und liefert den zugehörigen Zeiteintrag zurück 
        /// </summary>
        public async Task<TimeEntry> StartStopWatch(int projectId, int taskId, CancellationToken cancellationToken, bool? billable = null, string comment = null)
        {
            var sb = new StringBuilder();
            sb.Append($"?ProjectId={projectId}");
            sb.Append($"&TaskId={taskId}");
            if (billable.HasValue)
                sb.Append($"billable={billable}");
            if (comment != null)
                sb.Append($"comment={HttpUtility.UrlEncode(comment)}");

            using (var response = await _client.GetAsync(new Uri($"StartStopWatch{sb}", UriKind.Relative), cancellationToken))
            {
                // 403 on existing items which are not accessable
                // 500 on not existing items (task and project)

                // Stop if resource is not available
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<TimeEntry>>(content).D;
            }
        }

        /// <summary>
        /// Hält die aktuelle Stoppuhr an und liefert den zugehörigen Zeiteintrag zurück 
        /// </summary>
        public async Task<TimeEntry> HaltStopWatch(CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri("HaltStopWatch", UriKind.Relative), cancellationToken))
            {
                // Stop if resource is not available
                if (response.StatusCode == HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<TimeEntry>>(content).D;
            }
        }

        #endregion

        #region Change Log

        public async Task<ChangeSet> GetChangeSet(DateTime lastRequest, CancellationToken cancellationToken)
        {
            using (var response = await _client.GetAsync(new Uri($"GetChangesDigest?LastSynchronizationTime={lastRequest:s}", UriKind.Relative), cancellationToken))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ChangeSet>>(content).D;
            }
        }

        #endregion
    }
}
