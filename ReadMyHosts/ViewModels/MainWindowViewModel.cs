using System.Windows.Input;

//using ReadMyHosts.Helpers;

namespace ReadMyHosts.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(/*ICommand readHostsCommand*/)
        {
            //ReadHostsCommand = readHostsCommand;
        }

        public string Greeting => "Welcome to Avalonia!";
        public ICommand ReadHostsCommand { get; }
    }
}