using Audit_console.Config.io;
using Audit_console.Logging;

namespace Audit_console.Config
{
    public static class Main
    {
        public static bool Initialize()
        {
            if (!DirectoryLocations.Initialize() || !FileLocations.Initialize()) return false;
            LogClassificationTypes.Initialize();
            Logger.AddLog(new LogData("", LogTypes.Default.LogConfigIo, LogClassificationTypes.Information));
            return true;
        }

        
    }
}
