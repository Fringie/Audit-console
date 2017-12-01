using System;
using System.Reflection;
using System.Windows.Markup;
using Catel.Logging;

namespace Audit_console.Config.io
{
    static class FileLocations
    {
        #region Files
        // Usage example 
        public static FileLocationContainer TableHeaders { get; set; } =  new FileLocationContainer("table-example.json", DirectoryLocations.LoggingConfig + "table-headers.json", false, DefaultFileContents.TableHeaders);
        

        #endregion

        /// <summary>
        /// Verifies the required files exist. If they do not and they have a file defination it will create the file.
        /// </summary>
        /// <returns>False if one of the MANDATORY files did not create</returns>
        public static bool Initialize()
        {
            bool noFailures = true;
            Type classType = typeof(FileLocations);
            foreach (PropertyInfo propertyInfo in classType.GetProperties())
            {
                if (propertyInfo.PropertyType != typeof(FileLocationContainer)) continue;
                FileLocationContainer fileInfo = propertyInfo.GetValue(null) as FileLocationContainer;
                if (IoHelperMethods.FileExists(fileInfo.Path)) continue; // Skip files that exist
                // Try to create the file using the file defination if it has one
                if (fileInfo.FileDefination != null) if (IoHelperMethods.CreateFile(fileInfo.Path, fileInfo.FileDefination, fileInfo.Required)) continue;
                if (!fileInfo.Required) continue; // if not required then continue because it's ok
                noFailures = false; 
                break;
            }
            return noFailures;
        }
    }

    class FileLocationContainer
    {
        public string Name { get; private set; }
        public string Path { get; private set; }
        public bool Required { get; private set; }  
        public string FileDefination { get; private set; }   // [Optional] Hardcoded defination of file

        /// <summary>
        /// Create the corresponding data for each file you add to this project
        /// </summary>
        /// <param name="name">The name of the file including the extension</param>
        /// <param name="path">The path to where the file should be stored</param>
        /// <param name="required">Whether this file is required, true will force the app to exit if not found and cannot be created</param>
        /// <param name="fileDefination">[Optional] The base defination of the file written in JSON</param>
        public FileLocationContainer(string name, string path, bool required, string fileDefination = null)
        {
            Name = name;
            Path = path;
            Required = required;
            if (fileDefination != null) FileDefination = fileDefination;
        }
    }
    /// <summary>
    /// Put hardcoded default file contents here. This is used to recreate important files if they are not stored
    /// Priority = File > default data (stored here) > error > exit app
    /// </summary>
    static class DefaultFileContents
    {
        public static string TableHeaders { get; } = "Placeholder";
    }
}
