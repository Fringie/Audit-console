using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Catel.Logging;
using Catel.MVVM.Converters;

namespace Audit_console.Config.io
{
    public static class IoHelperMethods
    {
        private static ILog _directoryLogger = LogManager.GetLogger(typeof(DirectoryLocations));
        private static ILog _fileLogger = LogManager.GetLogger(typeof(FileLocations));
        

        /// <summary>
        /// Checks the directory exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool DirectoryExists(string path)
        {
            if (Directory.Exists(path)) return true;
            string msg = $@"Directory '{path}' does not exist.";
            _directoryLogger.Info(msg);
            return false;
        }

        /// <summary>
        /// Attempt to create a directory x ammount of times
        /// </summary>
        /// <param name="path">Path to the directory</param>
        /// <param name="attempts">[Optional] how many attempts to create the directory</param>
        /// <returns>True if directory was created</returns>
        public static bool CreateDirectory(string path, int attempts = 5)
        {
            bool createdDirectory = false;
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    _directoryLogger.Info($@"Attempt {i}/{attempts} to create directory '{path}' ...");
                    Directory.CreateDirectory(path);
                    createdDirectory = true;
                    _directoryLogger.Info($@"Successfully created directory '{path}' ...");
                    break;
                }
                catch (Exception e)
                {
                    createdDirectory = false;
                    _directoryLogger.Error($@"Failed to create directory at '{path}'. Error: '{e}'");
                    if (i <= attempts) DelayAndPrompt("Waiting for 500 ms before re-attempting to create the directory.", TimeSpan.FromMilliseconds(500));
                }
            }
            return createdDirectory;
        }


        /// <summary>
        /// Checks the file exists
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FileExists(string path)
        {
            if (File.Exists(path)) return true;
            string msg = $@"File '{path}' does not exist.";
            _fileLogger.Info(msg);
            return false;
        }

        /// <summary>
        /// Attempt to create a file x ammount of times
        /// </summary>
        /// <param name="path">Path to the file (inc file name and extension)</param>
        /// <param name="data">The data inside of the file</param>
        /// <param name="required">If the file is required or optional, if the file is not required make sure there your code skips over the file if it doesn't exist</param>
        /// <param name="attempts">[Optional] how many attempts to create the file</param>
        /// <returns>True if directory was created</returns>
        public static bool CreateFile(string path, string data, bool required, int attempts = 5)
        {
            bool createFile = false;
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    _fileLogger.Info($@"Attempt {i}/{attempts} to create file '{path}' ...");
                    File.WriteAllText(path, data);
                    createFile = true;
                    _fileLogger.Info($@"Successfully created file '{path}' ...");
                    break;
                }
                catch (Exception e)
                {
                    string msg = required ? 
                            $@"Failed to create a required file at '{path}'. The application will be unable to continue. Error: '{e}'" 
                            : $@"Failed to create non mandatory file at '{path}'. Application will continue. Error: '{e}'";
                    createFile = false;
                    _fileLogger.Error(msg);
                    if (i <= attempts) DelayAndPrompt("Waiting for 250 ms before re-attempting to create the file.", TimeSpan.FromMilliseconds(250));
                    

                }
            }
            return createFile;
        }

        /// <summary>
        /// Logs an info message then
        /// </summary>
        /// <param name="message"></param>
        /// <param name="waitDelay"></param>
        public static void DelayAndPrompt(string message, TimeSpan waitDelay)
        {
            _directoryLogger.Info(message);
            Thread.Sleep(waitDelay);
        }

        /// <summary>
        /// Turn a string into a CSV cell output
        /// </summary>
        /// <param name="str">String to output</param>
        /// <returns>The CSV cell formatted string</returns>
        public static string SafeCsvText(string str)
        {
            if (!Regex.IsMatch(str, "[,\"\\r\\n]")) return str;
            StringBuilder sb = new StringBuilder(); 
            sb.Append("\"");
            foreach (char nextChar in str)
            {
                sb.Append(nextChar);
                if (nextChar == '"') sb.Append("\"");
            }
            sb.Append("\"");
            return sb.ToString();
        }
    }
}
