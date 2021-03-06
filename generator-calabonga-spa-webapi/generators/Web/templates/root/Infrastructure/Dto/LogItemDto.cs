using System;
using <%= projectName %>.Models.Base;

namespace <%= projectName %>.Web.Infrastructure.Dto {

    /// <summary>
    /// Data Transfer Object for LogItem
    /// </summary>
    public class LogItemDto : Identity {

        /// <summary>
        /// Type of the log-item
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// Log message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Creation Date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Operation Exception Message
        /// </summary>
        public string StackTrace { get; set; }
    }
}
