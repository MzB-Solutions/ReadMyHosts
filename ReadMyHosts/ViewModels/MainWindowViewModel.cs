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
            List = new HostsListViewModel(hosts.GetData());
        }

        public HostsListViewModel List { get; }

    }
}
