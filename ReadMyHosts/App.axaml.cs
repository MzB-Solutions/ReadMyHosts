using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReadMyHosts.Services;
using ReadMyHosts.ViewModels;
using ReadMyHosts.Views;

namespace ReadMyHosts
{
    public class App : Application
    {
        #region Public Methods

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            base.OnFrameworkInitializationCompleted();
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var hostsPlatform = new HostsService();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(hostsPlatform),
                };
            }
        }

        #endregion Public Methods
    }
}
