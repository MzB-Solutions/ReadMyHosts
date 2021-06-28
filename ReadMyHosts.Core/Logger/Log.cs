using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace ReadMyHosts.Core.Logger
{
    public static class Log
    {
        #region Public Fields

        public static Serilog.Core.Logger AppLog;
        public static Serilog.Core.Logger DebugLog;

        #endregion Public Fields

        #region Public Methods

        public static void AppLogInit()
        {
            AppLog = new LoggerConfiguration()
                .WriteTo.File("ReadMyHosts.log", rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }

        public static void DebugLogInit()
        {
            DebugLog = new LoggerConfiguration()
                .WriteTo.Debug()
                .CreateLogger();
        }

        public static void FlushLogs()
        {
            AppLog.Dispose();
            DebugLog.Dispose();
        }

        #endregion Public Methods
    }
}
