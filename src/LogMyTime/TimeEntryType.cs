using System.Runtime.Serialization;

namespace LogMyTime
{
    /// <summary>
    /// Liste möglicher Zeiteintragstypen
    /// </summary>
    [DataContract]
    public enum TimeEntryType
    {
        /// <summary>
        /// Dauer-Zeiteintrag
        /// </summary>
        [EnumMember]
        Permanent = 1,

        /// <summary>
        /// Start/Ende 
        /// </summary>
        [EnumMember]
        StartEnd = 2,
    }
}
