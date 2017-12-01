using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Audit_console.Config.io;
using Catel.Collections;

namespace Audit_console.Logging
{
    static class LogClassificationTypes
    {
        public const string Warning  = "Warning";
        public const string Error = "Error";
        public const string Information  = "Information";
        public const string Debug  = "Debug";

        private static readonly List<string> ValidLogClassifications = new List<string>();

        public static void Initialize()
        {
            SetValidLogClassifications();
        }

        public static bool IsValidLogClassification(string logClassification)
        {
            return ValidLogClassifications.Contains(logClassification);
        }
        
        private static void SetValidLogClassifications()
        {
            foreach (var fieldInfo in typeof(LogClassificationTypes).GetFields())
            {
                if (fieldInfo.FieldType == typeof(string)) ValidLogClassifications.Add(fieldInfo.GetValue(null).ToString());
            }
            
        }
    }
}
