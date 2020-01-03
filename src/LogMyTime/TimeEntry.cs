using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LogMyTime
{
    /// <summary>
    /// Repräsentiert einen Zeiteintrag
    /// </summary>
    [DataContract]
    public sealed class TimeEntry
    {
        /// <summary>
        /// Eine eindeutige Zeiteintrags-ID 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Art des Zeiteintrags
        /// </summary>
        [DataMember]
        public TimeEntryType TypeId { get; set; }

        /// <summary>
        /// Der Startzeitpunkt des Eintrags, bei Dauer-Zeiteinträgen liegt diese immer zu Mitternacht. 
        /// </summary>
        [DataMember]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Der Endzeitpunkt des Eintrags. 
        /// </summary>
        [DataMember]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Die aus Start- und Endzeitpunkt errechnete Dauer des Zeiteintrags im hh:mm format, auf Minuten abgerundet. 
        /// </summary>
        [DataMember]
        public string DurationString { get; set; }

        /// <summary>
        /// Die aus Start- und Endzeitpunkt errechnete Dauer des Zeiteintrags in Sekunden 
        /// </summary>
        [DataMember]
        public int DurationSeconds { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, dem der Zeiteintrag zugewiesen ist 
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// Die Projekt-ID 
        /// </summary>
        [DataMember]
        public int ProjectId { get; set; }

        /// <summary>
        /// Die Tätigkeits-ID, oder 'null' falls keine Tätigkeit existiert. 
        /// </summary>
        [DataMember]
        public int? TaskId { get; set; }

        /// <summary>
        /// Ein optionaler Kommentar zum Zeiteintrag. 
        /// </summary>
        [DataMember]
        [StringLength(1500)]
        public string Comment { get; set; }

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
        /// Ist der Zeiteintrag abrechenbar? Default-Wert: True 
        /// </summary>
        [DataMember]
        public bool Billable { get; set; }

        /// <summary>
        /// Ist der Zeiteintrag abgeschlossen? Abgeschlossene Zeiteinträge können nicht verändert
        /// oder gelöscht werden. Default-Wert: False 
        /// </summary>
        [DataMember]
        public bool Locked { get; set; }

        /// <summary>
        /// Ein Zeiteintrag ist für Standardnutzer nur dann editierbar, wenn er nach dem
        /// Buchungsschluss liegt und nicht explizit abgeschlossen wurde. IsEditable wird
        /// immer nur serverseitig gesetzt. 
        /// </summary>
        [DataMember]
        public bool IsEditable { get; set; }

        /// <summary>
        /// Der für den Zeiteintrag hinterlegte Stundensatz, falls Stundensätze aktiviert sind und der
        /// Nutzer, der auf die API zugreift dazu berechtigt ist, Stundensätze zu sehen. Ansonsten ist der
        /// Wert des Feldes immer null.
        /// Dieses Feld kann über die API nur ausgelesen, nicht aber beschrieben werden. 
        /// </summary>
        [DataMember]
        public decimal? HourlyRate { get; set; }

        /// <summary>
        /// Der für den Zeiteintrag errechnete Umsatz, falls Stundensätze aktiviert sind und der Nutzer,
        /// der auf die API zugreift dazu berechtigt ist, Stundensätze zu sehen. Ansonsten ist der Wert
        /// des Feldes immer null.
        /// Dieses Feld kann über die API nur ausgelesen, nicht aber beschrieben werden. 
        /// </summary>
        [DataMember]
        public decimal? Revenue { get; set; }

        /// <summary>
        /// Der Zeitpunkt, zu dem den Zeiteintrag zuletzt verändert wurde 
        /// </summary>
        [DataMember]
        public DateTime LastChangeTime { get; set; }

        /// <summary>
        /// Die ID des Mitarbeiters, der den Zeiteintrag zuletzt geändert hat 
        /// </summary>
        [DataMember]
        public int LastChangeAuthor { get; set; }
    }
}
