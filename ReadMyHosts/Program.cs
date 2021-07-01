using ReadMyHosts.Core;
using Avalonia;
using Avalonia.ReactiveUI;
using Serilog;
using PostSharp.Patterns.Diagnostics;
using PostSharp.Patterns.Diagnostics.Backends.Serilog;

namespace ReadMyHosts
{
    internal class Program
    {
        public static Info SysInfo = new Info();

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            if (IsDebug)
            {
                return AppBuilder.Configure<App>()
                           .UsePlatformDetect()
                           .LogToTrace()
                           .UseReactiveUI();
            }
            else
            {
                return AppBuilder.Configure<App>()
                           .UsePlatformDetect()
                           .UseReactiveUI();
            }
        }

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
#if DEBUG
            IsDebug = true;
#else
        IsDebug = false;
#endif
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        internal static bool IsDebug;
    }
}
