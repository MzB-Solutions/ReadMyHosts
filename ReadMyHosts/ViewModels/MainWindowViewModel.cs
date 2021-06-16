using System.Windows.Input;
using ReadMyHosts.Helpers;

namespace ReadMyHosts.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(ICommand readHostsCommand)
        {
            ReadHostsCommand = readHostsCommand;
        }

        public ICommand ReadHostsCommand{ get; }
        public string Greeting => "Welcome to Avalonia!";
    }
}
