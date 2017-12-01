namespace Audit_console.AppMainCode
{
    class Main
    {
        //todo REPLACE CurrentWeb WHEN RELATIONALHIERACHY.cs ADDED
        public string CurrentWeb { get; set; }
        /*
        /// <summary>
        /// Runs a void method
        /// </summary>
        /// <param name="methodToRun">The method you'd like to attempt to run (usually this method)</param>
        /// <param name="callerName">Leave as null</param>
        /// <param name="callerPath">Leave as null</param>
        public static void RunVoidMethod(Action methodToRun, [CallerMemberName] string callerName = null, [CallerFilePath] string callerPath = null)
        {
            //if (!string.IsNullOrWhiteSpace(callerName) && (callerName.Contains("Set") || callerName.Contains("Get")))
            
            try
            {
                methodToRun();
            }
            catch (Exception e)
            {
                string errorMsg = $"Class: '{callerPath}' encountered an unexpected error. Method: '{callerName}', error: '{e}'";
                LogData error = new LogData(Config.Logging.LogTypes.Default.UnhandledException, LogClassificationTypes.Error, errorMsg);
                Logger.Logs.Add(error);
                Logger.GeneralLogger.Error(errorMsg);
            } 
            
        }*/
    }
}
