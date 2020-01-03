using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogMyTime
{
    /// <summary>
    /// Repräsentiert ein einzelnes Projekt
    /// </summary>
    [DataContract]
    public sealed class Project
    {
        /// <summary>
        /// Eine eindeutige Projekt-ID
        /// </summary>
        [DataMember(Name = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Die ID des Kunden oder 'null' falls keiner zugewiesen ist
        /// </summary>
        [DataMember(Name = "ClientID")]
        public int ClientId { get; set; }

        /// <summary>
        /// Der Name des Projekts
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Nicht aktive Projekte gelten auf der LogMyTime Webseite als "abgelegt"
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Weitere Anmerkungen zu dem Projekt 
        /// </summary>
        [DataMember]
        [StringLength(1500)]
        public string Comment { get; set; }

        /// <summary>
        /// Der Stundenrahmen in Sekunden
        /// </summary>
        [DataMember]
        public int TimeBudget { get; set; }

        /// <summary>
        /// Zeigt an, ob das Projekt dem eingeloggten Nutzer zugewiesen ist.
        /// Diese Eigenschaft kann nicht beschrieben werden, sondern gibt nur die
        /// über die Webseite gemachten Projekt-Nutzer-Zuweisungen wieder.
        /// </summary>
        [DataMember]
        public bool AssignedToCurrentUser { get; set; }

        /// <summary>
        /// Falls für dieses Projekt nur von bestimmten Nutzern bebucht werden soll,
        /// werden die IDs der zugewiesenen Nutzer hier aufgezählt. Durch Setzen dieser
        /// Eigenschaft können Nutzer auch über die API zugewiesen werden. 
        /// </summary>
        [DataMember]
        public string AssignedUsers { get; set; }

        /// <summary>
        /// Falls für dieses Projekt nur bestimmte tätigkeiten gebucht werden sollten,
        /// werden die IDs der zugewiesenen Tätigkeiten hier aufgezählt. Durch Setzen dieser
        /// Eigenschaft können Tätigkeiten auch über die API zugewiesen werden. 
        /// </summary>
        [DataMember]
        public string AssignedTasks { get; set; }

        /// <summary>
        /// Zusatzfeld 1 für Projekte, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer1 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 2 für Projekte, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer2 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 3 für Projekte, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer3 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 4 für Projekte, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer4 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 5 für Projekte, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer5 { get; set; }

        /// <summary>
        /// Der Zeitpunkt, zu dem das Projekt zuletzt verändert wurde 
        /// </summary>
        [DataMember]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, der das Projekt zuletzt geändert hat 
        /// </summary>
        [DataMember]
        public int LastChangeAuthor { get; set; }
    }
}
