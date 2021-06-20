using System;
using System.Collections.Generic;
using System.Text;
using ReadMyHosts.Services;

namespace ReadMyHosts.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(HostsPlatform hosts)
        {
            HostList = new HostListViewModel(hosts.GetData());
        }

        public HostListViewModel HostList { get; }

    }
}
