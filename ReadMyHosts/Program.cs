using ReadMyHosts.Core;
using Avalonia;
using Avalonia.ReactiveUI;
using Serilog;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;

[assembly: Log]

namespace ReadMyHosts
{
    [Log(AttributeExclude = true)]
    internal class Program
    {
        #region Public Fields

        public static Info SysInfo = new Info();

        #endregion Public Fields

        #region Public Methods

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            Serilog.Core.Logger? _appLog;
            if (!IsDebug)
            {
                _appLog = new LoggerConfiguration()
                    .MinimumLevel.Warning()
                    .WriteTo.File("./log/App.log", outputTemplate: template, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
            }
            else
            {
                _appLog = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Debug(outputTemplate: template)
                    .WriteTo.File("./log/AppDebug.log", outputTemplate: template, rollingInterval: RollingInterval.Hour)
                    .CreateLogger();
            }

            LoggingServices.DefaultBackend = new SerilogLoggingBackend(_appLog);
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        #endregion Public Methods

        #region Private Fields

        // The output template must include {Indent} for nice output.
        private const string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l}{Message}{NewLine}{Exception}";

        private static bool IsDebug = false;

        #endregion Private Fields
    }
}
