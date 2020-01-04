using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LogMyTime
{
    public sealed class LogMyTimeClient
    {
        private readonly HttpClient _client;

        public LogMyTimeClient(string apiKey)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.logmytime.de/v1/api.svc/");
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Add("X-LogMyTimeApiKey", apiKey);
            _client.DefaultRequestHeaders.Add("X-UserAgent", $"Tom Wendels Client {Assembly.GetCallingAssembly().GetName().Version}");
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        #region Projects

        public async Task<IEnumerable<Project>> GetProjects(CancellationToken cancellationToken)
        {
            var x = await _client.GetAsync(new Uri("Projects", UriKind.Relative), cancellationToken);
            x.EnsureSuccessStatusCode();
            var content = await x.Content.ReadAsStringAsync();
            var y = JsonConvert.DeserializeObject<Response<ResponseList<Project>>>(content);
            return y.D.Results;
        }

        public async Task<Project> GetProjectById(int projectId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Project> CreateProject(Project project, CancellationToken cancellationToken)
        {
            var serialized = JsonConvert.SerializeObject(project);
            HttpContent z = new StringContent(serialized);
            var x = await _client.PostAsync(new Uri("Projects", UriKind.Relative), z, cancellationToken);
            x.EnsureSuccessStatusCode();
            var content = await x.Content.ReadAsStringAsync();
            var y = JsonConvert.DeserializeObject<Project>(content);
            return y;
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
            var x = await _client.GetAsync(new Uri("Clients", UriKind.Relative), cancellationToken);
            x.EnsureSuccessStatusCode();
            var content = await x.Content.ReadAsStringAsync();
            var y = JsonConvert.DeserializeObject<Response<ResponseList<Client>>>(content);
            return y.D.Results;
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

        public Task<IEnumerable<Task>> GetTasks(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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



        #endregion
    }
}
