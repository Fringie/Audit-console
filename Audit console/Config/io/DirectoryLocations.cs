using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Navigation;

namespace Audit_console.Config.io
{
    static class DirectoryLocations
    {
        // Directories
        public static string RootDirectory { get; set; } = Directory.GetCurrentDirectory() + @"\";
        public static string ConfigRoot { get; set; } = RootDirectory + @"Config\";
        public static string DataRoot { get; set; } = RootDirectory + @"Data\";
        public static string LoggingConfig { get; set; } = ConfigRoot + @"Logging\";

        /// <summary>
        /// Create & verify each directory
        /// </summary>
        /// <returns>False if one of the directories did not create</returns>
        public static bool Initialize()
        {
            Type classType = typeof(DirectoryLocations);
            foreach (PropertyInfo propertyInfo in classType.GetProperties())
            {
                //if (propertyInfo.PropertyType != typeof(string)) continue; // only get string properties
                string path = propertyInfo.GetValue(null).ToString(); // get path
                if (!IoHelperMethods.DirectoryExists(path) && !IoHelperMethods.CreateDirectory(path)) return false;    
            }
            return true; 
        }
    }
}
