using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Logging;

namespace Audit_console.Logging
{
    public static class Logger
    {
        #region Loggers
        public static ILog GeneralLogger { get; set; } = LogManager.GetLogger(typeof(Logger));

        #endregion

        #region Log lists
        public static List<LogData> Logs { get; set; } = new List<LogData>();
        public static List<LogData> ErrorLogs { get; set; } = new List<LogData>();
        public static List<string> AuditedSites { get; set; } = new List<string>();
        #endregion

        #region Handle Logs
        public static void AddLog(LogData logData)
        {
            DisplayLog(logData);
            SaveLog(logData);
        }

        public static void SaveLogs()
        {
            
        }
        /// <summary>
        /// Displays the log
        /// </summary>
        /// <param name="logData">The log</param>
        private static void DisplayLog(LogData logData)
        {
            switch (logData.LogClassification)
            {
                case LogClassificationTypes.Debug:
                    AddDebug(logData);
                    break;
                case LogClassificationTypes.Information:
                    AddInformation(logData);
                    break;
                case LogClassificationTypes.Warning:
                    AddWarning(logData);
                    break;
                default:
                    AddError(logData);
                    break;
            }
        }

        private static void SaveLog(LogData logData)
        {
            if (logData.LogClassification == LogClassificationTypes.Error) ErrorLogs.Add(logData);
            Logs.Add(logData);
        }

        /// <summary>
        /// Create a correctly formatted log msg
        /// </summary>
        private static string FormatLogMsg(LogData logData)
        {
            string colon = !string.IsNullOrWhiteSpace(logData.Description) ? ":" : string.Empty;
            return $"{logData.LogType}{colon} {logData.Description} {logData.Url}";
        }
        #endregion

        #region Add Log methods

        private static void AddError(LogData logData)
        {
            GeneralLogger.Error(FormatLogMsg(logData));
        }
        private static void AddDebug(LogData logData)
        {
            GeneralLogger.Debug(FormatLogMsg(logData));
        }
        private static void AddInformation(LogData logData)
        {
            GeneralLogger.Info(FormatLogMsg(logData));
        }

        private static void AddWarning(LogData logData)
        {
            GeneralLogger.Debug(FormatLogMsg(logData));
        }

        
        #endregion

    }
}
