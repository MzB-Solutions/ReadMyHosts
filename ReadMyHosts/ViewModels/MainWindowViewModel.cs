using ReadMyHosts.Services;

namespace ReadMyHosts.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Public Constructors

        public MainWindowViewModel(HostsService hosts)
        {
            HostList = new HostListViewModel(hosts.GetData());
        }

        #endregion Public Constructors

        #region Public Properties

        public HostListViewModel HostList { get; }

        #endregion Public Properties
    }
}
