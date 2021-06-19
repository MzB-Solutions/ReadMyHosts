using ReadMyHosts.Core.Models;
using ReadMyHosts.Core.Handlers;
using System.Collections.Generic;

namespace ReadMyHosts.Services
{
    public class HostsPlatform
    {
        public IEnumerable<Host> GetData() {
            var handler = new HostsHandler();
            handler.ReadFile();
            return handler.HostList;
        }
    }
}