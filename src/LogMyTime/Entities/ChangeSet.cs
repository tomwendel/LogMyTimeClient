using System;
using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Repräsentiert das change set seit des letzten Abrufs
    /// </summary>
    [DataContract]
    public sealed class ChangeSet
    {
        /// <summary>
        /// Anzahl der derzeit aktiven Kunden 
        /// </summary>
        [DataMember]
        public int TotalClients { get; set; }

        /// <summary>
        /// Anzahl der seit LastSynchronizationTime veränderten Kunden 
        /// </summary>
        [DataMember]
        public int ChangedClients { get; set; }

        /// <summary>
        /// Anzahl der derzeit aktiven Projekte 
        /// </summary>
        [DataMember]
        public int TotalProjects { get; set; }

        /// <summary>
        /// Anzahl der seit LastSynchronizationTime veränderten Projekte 
        /// </summary>
        [DataMember]
        public int ChangedProjects { get; set; }

        /// <summary>
        /// Anzahl der derzeit aktiven Tätigkeiten 
        /// </summary>
        [DataMember]
        public int TotalTasks { get; set; }

        /// <summary>
        /// Anzahl der seit LastSynchronizationTime veränderten Tätigkeiten 
        /// </summary>
        [DataMember]
        public int ChangedTasks { get; set; }

        /// <summary>
        /// Anzahl der derzeit aktiven Mitarbeiter 
        /// </summary>
        [DataMember]
        public int TotalUsers { get; set; }

        /// <summary>
        /// Anzahl der seit LastSynchronizationTime veränderten Mitarbeiter 
        /// </summary>
        [DataMember]
        public int ChangedUsers { get; set; }

        /// <summary>
        /// Anzahl der derzeit aktiven Zeiteinträge 
        /// </summary>
        [DataMember]
        public int TotalTimeEntries { get; set; }

        /// <summary>
        /// Anzahl der seit LastSynchronizationTime veränderten Zeiteinträge 
        /// </summary>
        [DataMember]
        public int ChangedTimeEntries { get; set; }

        /// <summary>
        /// Auflistung aller IDs von Zeiteinträgen, die seit LastSynchronizationTime gelöscht wurden. 
        /// </summary>
        [DataMember]
        public string DeletedTimeEntryIDs { get; set; }

        /// <summary>
        /// Aktuelle Zeit auf dem LogMyTime Server. Diesen Zeitstempel können Sie für den nächsten Aufruf von GetChangesDigest verwenden. 
        /// </summary>
        [DataMember]
        public DateTime CurrentServerTime { get; set; }
    }
}
