using PostSharp.Patterns.Contracts;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;
using Serilog;
using System;
using System.Runtime.InteropServices;
using static PostSharp.Patterns.Diagnostics.FormattedMessageBuilder;

[assembly: Log]

namespace ReadMyHosts.Core
{
    //[Log(AttributeExclude = true)]
    public class Info
    {
        // The output template must include {Indent} for nice output.
        private const string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l}{Message}{NewLine}{Exception}";

        private static bool IsDebug;
        private Serilog.Core.Logger _coreLog;

        #region Public Constructors

        public Info()
        {
#if DEBUG
            IsDebug = true;
#else
            IsDebug = false;
#endif

            if (!IsDebug)
            {
                _coreLog = new LoggerConfiguration()
                    .MinimumLevel.Warning()
                    .WriteTo.File("./log/App.log", outputTemplate: template, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }
            if (IsDebug)
            {
                _coreLog = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Debug(outputTemplate: template)
                    .WriteTo.File("./log/AppDebug.log", outputTemplate: template, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }

            LoggingServices.DefaultBackend = new SerilogLoggingBackend(_coreLog);

            SetOS();
            SetHostsRootPath();
        }

        #endregion Public Constructors

        ~Info()
        {
            //_coreLog.Dispose();
        }

        #region Public Properties

        public string CustomPath { get; set; }

        [Required]
        public string DirectorySeparator { get; set; }

        [Required]
        public string RootPath { get; set; }

        #endregion Public Properties

        #region Internal Fields

        internal bool NeedsFix = false;

        #endregion Internal Fields

        #region Private Fields

        private static readonly LogSource logSource = LogSource.Get();
        private OSType SystemType;

        #endregion Private Fields

        #region Private Enums

        [Flags]
        private enum OSType
        {
            None = 0b_0000,
            Windows = 0b_0001,
            Linux = 0b_0010,
            FreeBSD = 0b_0011,
            OSX = 0b_00100
        }

        #endregion Private Enums

        #region Private Methods

        private void SetHostsRootPath()
        {
            switch (SystemType)
            {
                case OSType.None:
                    // by virtue of using Required from PostSharp we get an exception if no valid OS found
                    RootPath = string.Empty;
                    DirectorySeparator = string.Empty;
                    logSource.Warning.Write(Formatted("The OS Type is [None]"));
                    break;

                case OSType.Windows:
                    DirectorySeparator = "\\";
                    RootPath = String.Format("C:{0}Windows{0}System32{0}drivers{0}", DirectorySeparator);
                    logSource.Debug.Write(Formatted("The OS Type is [Windows]"));
                    break;

                case OSType.Linux:
                    DirectorySeparator = "/";
                    RootPath = "/";
                    logSource.Debug.Write(Formatted("The OS Type is [Linux]"));
                    break;

                case OSType.FreeBSD:
                    DirectorySeparator = "/";
                    RootPath = "/";
                    logSource.Debug.Write(Formatted("The OS Type is [FreeBSD]"));
                    break;

                case OSType.OSX:
                    throw new NotImplementedException();

                default:
                    throw new AccessViolationException();
            }
        }

        private void SetOS()
        {
            bool IsBSD = RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD);
            bool IsLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool IsOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            bool IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            if (IsBSD)
            {
                SystemType = OSType.FreeBSD;
            }
            else if (IsLinux)
            {
                SystemType = OSType.Linux;
            }
            else if (IsOSX)
            {
                SystemType = OSType.OSX;
            }
            else if (IsWindows)
            {
                SystemType = OSType.Windows;
            }
            else
            {
                SystemType = OSType.None;
            }
        }

        #endregion Private Methods
    }
}
