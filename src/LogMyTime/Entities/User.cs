using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogMyTime.Entities
{
    /// <summary>
    /// Repräsentiert einen Mitarbeiter
    /// </summary>
    [DataContract]
    public sealed class User : IndexedEntity<int>
    {
        /// <summary>
        /// Anrede des Mitarbeiters 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// Vorname des Mitarbeiters 
        /// </summary>
        [DataMember]
        [StringLength(80)]
        public string FirstName { get; set; }

        /// <summary>
        /// Nachname des Mitarbeiters 
        /// </summary>
        [DataMember]
        [StringLength(80)]
        public string LastName { get; set; }

        /// <summary>
        /// E-Mail-Adresse 
        /// </summary>
        [DataMember]
        [StringLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// Genutzte Interfacesprache, mögliche Werte: DE,EN,US 
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string Language { get; set; }

        /// <summary>
        /// Zugriffsrechte des Mitarbeiter
        /// </summary>
        [DataMember]
        public UserAccessRights AccessRights { get; set; }

        /// <summary>
        /// Weitere Anmerkungen zu dem Mitarbeiter 
        /// </summary>
        [DataMember]
        [StringLength(1500)]
        public string Comment { get; set; }

        /// <summary>
        /// Nicht aktive Mitarbeiter können sich bei LogMyTime nicht einloggen und auch keine
        /// Daten per API synchronisieren. Sie verursachen aber auch keine monatlichen Kosten. 
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>
        /// Zusatzfeld 1 für Benutzer, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Custom1 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 2 für Benutzer, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Custom2 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 3 für Benutzer, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Custom3 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 4 für Benutzer, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Custom4 { get; set; }
        
        /// <summary>
        /// Zusatzfeld 5 für Benutzer, falls diese vom Administrator angelegt wurden.
        /// Die Konfiguration kann mit der Ressource Kontoeinstellungen per API ausgelesen werden. 
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Custom5 { get; set; }

        /// <summary>
        /// Der Zeitpunkt, zu dem der Mitarbeitereintrag zuletzt verändert wurde 
        /// </summary>
        [DataMember]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, der den Mitarbeitereintrag zuletzt geändert hat 
        /// </summary>
        [DataMember]
        public int LastChangeAuthor { get; set; }
    }
}
