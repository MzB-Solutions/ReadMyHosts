using ReadMyHosts.Core;
using Avalonia;
using Avalonia.ReactiveUI;

namespace ReadMyHosts
{
    internal class Program
    {
        public static readonly Info SysInfo = new Info();

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
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        protected Program()
        {
#if DEBUG
        IsDebug = true;
#endif
        }

        private static bool IsDebug { get; set; } = false;
    }
}
