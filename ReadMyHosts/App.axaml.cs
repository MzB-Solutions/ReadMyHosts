using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReadMyHosts.ViewModels;
using ReadMyHosts.Views;
using ReadMyHosts.Services;

namespace ReadMyHosts
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var hostsPlatform = new HostsPlatform();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(hostsPlatform),
                };
            }

            
        }
    }
}