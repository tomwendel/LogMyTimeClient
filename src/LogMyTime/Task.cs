using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogMyTime
{
    /// <summary>
    /// Repräsentiert eine Tätigkeit
    /// </summary>
    [DataContract]
    public sealed class Task
    {
        /// <summary>
        /// Eine eindeutige Tätigkeits-ID 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Eine Beschreibung der Tätigkeit 
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// Weitere Anmerkungen zur Tätigkeit 
        /// </summary>
        [DataMember]
        [StringLength(1500)]
        public string Comment { get; set; }

        /// <summary>
        /// Nicht aktive Tätigkeiten gelten auf der LogMyTime Webseite als "abgelegt"
        /// </summary>
        [DataMember]
        public bool Billable { get; set; }

        /// <summary>
        /// Ist die Tätigkeit bei über die der LogMyTime Webseite erstellten Zeiteinträgen standardmäßig abrechenbar? Default-Wert: True 
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Zusatzfeld 1 für Tätigkeiten, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer1 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 2 für Tätigkeiten, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer2 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 3 für Tätigkeiten, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer3 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 4 für Tätigkeiten, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer4 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 5 für Tätigkeiten, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        public string Customer5 { get; set; }

        /// <summary>
        /// Der Zeitpunkt, zu dem die Tätigkeit zuletzt verändert wurde 
        /// </summary>
        [DataMember]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, der die Tätigkeit zuletzt geändert hat 
        /// </summary>
        [DataMember]
        public int LastChangeAuthor { get; set; }
    }
}
