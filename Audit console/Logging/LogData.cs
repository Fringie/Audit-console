using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Audit_console.AppMainCode;

namespace Audit_console.Logging
{
    public class LogData
    {
        public DateTime Date { get; }
        public string LogType { get; }
        public string LogClassification { get;  }
        public string Description { get; }
        public string Data { get;}
        public string Url { get; }

        /// <summary>
        /// A log
        /// </summary>
        /// <param name="url">The site this log relates to</param>
        /// <param name="logType">The type of log, as defined in the Config.LoggingLogTypes.Settings file</param>
        /// <param name="logClassification">The type of log as defined in Config.Logging.LogClassificationTypes.cs</param>
        /// <param name="description">The description of the log</param>
        /// <param name="data">Any data you want to provide for the log</param>
        /// <param name="methodName">Ignore this, C# implementation quirk - gets the caller method name, leave as is</param>
        public LogData(string url = "", string logType = "", string logClassification = "", string description = "", string data = "", [CallerMemberName] string methodName = null)
        {
            Url = Config.io.IoHelperMethods.SafeCsvText(url);
            Date = DateTime.Now;
            LogType = string.IsNullOrWhiteSpace(logType) ? HelperMethods.GetMethodName(methodName) : Config.io.IoHelperMethods.SafeCsvText(logType);
            Description = Config.io.IoHelperMethods.SafeCsvText(description);
            LogClassification = LogClassificationTypes.IsValidLogClassification(logClassification) ? logClassification : $"Invalid log type: '{logClassification}'";
            Data = Config.io.IoHelperMethods.SafeCsvText(data);
        }
        
        
    }

    

}
