using ReadMyHosts.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReadMyHosts.ViewModels
{
    public class HostListViewModel : ViewModelBase
    {
        #region Public Constructors

        public HostListViewModel(IEnumerable<Host> hosts)
        {
            Hosts = new ObservableCollection<Host>(hosts);
        }

        #endregion Public Constructors

        #region Public Properties

        public string Greeting => "Welcome to Avalonia!";
        public ObservableCollection<Host> Hosts { get; }

        #endregion Public Properties
    }
}
