using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;
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
                .WriteTo.File("./logs/RMH-App.log", rollingInterval: RollingInterval.Hour)
                .CreateLogger();
            LoggingServices.DefaultBackend = new SerilogLoggingBackend(AppLog);
        }

        public static void DebugLogInit()
        {
            DebugLog = new LoggerConfiguration()
                .WriteTo.Debug()
                .WriteTo.File("./logs/RMH-Debug.log", rollingInterval: RollingInterval.Hour)
                .CreateLogger();
        }

        public static void FlushLogs()
        {
            //AppLog.Dispose();
            //DebugLog.Dispose();
        }

        #endregion Public Methods

        #region Private Fields

        // The output template must include {Indent} for nice output.
        private const string logTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l}{Message}{NewLine}{Exception}";

        #endregion Private Fields
    }
}
