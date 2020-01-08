using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Repräsentiert einen Kunden
    /// </summary>
    [DataContract]
    public sealed class Client : IndexedEntity<int>
    {
        /// <summary>
        /// Name des Kunden 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Weitere Anmerkungen zum Kunden 
        /// </summary>
        [DataMember]
        [StringLength(1500)]
        public string Comment { get; set; }

        /// <summary>
        /// Nicht aktive Kunden gelten auf der LogMyTime Webseite als "abgelegt"
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Zeigt an, ob der Kunde ein Projekt hat, das dem eingeloggten Nutzer zugewiesen ist 
        /// </summary>
        [DataMember]
        public bool AssignedToCurrentUser { get; set; }

        /// <summary>
        /// Zusatzfeld 1 für Kunden, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer1 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 2 für Kunden, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer2 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 3 für Kunden, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer3 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 4 für Kunden, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer4 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 5 für Kunden, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer5 { get; set; }

        /// <summary>
        /// Der Zeitpunkt, zu dem der Kundeneintrag zuletzt verändert wurde
        /// </summary>
        [DataMember]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, der den Kundeneintrag zuletzt geändert hat 
        /// </summary>
        [DataMember]
        public int LastChangeAuthor { get; set; }
    }
}
