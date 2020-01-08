using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogMyTime.Entities;
using Task = LogMyTime.Entities.Task;

namespace LogMyTime.Communication
{
    public interface IProxy
    {
        #region Projects

        Task<IEnumerable<Project>> GetProjects(CancellationToken cancellationToken);

        Task<Project> GetProjectById(int projectId, CancellationToken cancellationToken);

        Task<Project> CreateProject(Project project, CancellationToken cancellationToken);

        System.Threading.Tasks.Task UpdateProject(Project project, CancellationToken cancellationToken);

        System.Threading.Tasks.Task DeleteProject(int projectId, CancellationToken cancellationToken);

        #endregion

        #region Clients

        Task<IEnumerable<Client>> GetClients(CancellationToken cancellationToken);

        Task<Client> GetClientById(int clientId, CancellationToken cancellationToken);

        Task<Client> CreateClient(Client client, CancellationToken cancellationToken);

        Task UpdateClient(Client client, CancellationToken cancellationToken);

        Task DeleteClient(int clientId, CancellationToken cancellationToken);

        #endregion

        #region Tasks

        Task<IEnumerable<Task>> GetTasks(CancellationToken cancellationToken);

        Task<Task> GetTaskById(int taskId, CancellationToken cancellationToken);

        Task<Task> CreateTask(Task task, CancellationToken cancellationToken);

        Task UpdateTask(Task task, CancellationToken cancellationToken);

        Task DeleteTask(int taskId, CancellationToken cancellationToken);

        #endregion

        #region TimeEntries

        #endregion

        #region Users

        #endregion

        #region Stopwatch

        /// <summary>
        /// Liefert den Zeiteintrag der laufenden Stoppuhr mit allen zugehörigen Parametern zurück 
        /// </summary>
        Task<TimeEntry> CurrentStopWatch(CancellationToken cancellationToken);

        /// <summary>
        /// Startet eine neue Stoppuhr und liefert den zugehörigen Zeiteintrag zurück 
        /// </summary>
        Task<TimeEntry> StartStopWatch(int projectId, int taskId, CancellationToken cancellationToken,
            bool? billable = null, string comment = null);

        /// <summary>
        /// Hält die aktuelle Stoppuhr an und liefert den zugehörigen Zeiteintrag zurück 
        /// </summary>
        Task<TimeEntry> HaltStopWatch(CancellationToken cancellationToken);

        #endregion

        #region Change Log

        Task<ChangeSet> GetChangeSet(DateTime lastRequest, CancellationToken cancellationToken);

        #endregion
    }
}
