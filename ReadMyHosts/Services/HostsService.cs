using ReadMyHosts.Core.Handlers;
using ReadMyHosts.Core.Models;
using System.Collections.Generic;

namespace ReadMyHosts.Services
{
    public class HostsService
    {
        #region Public Methods

        public IEnumerable<Host> GetData()
        {
            return new HostsHandler().HostList;
        }

        #endregion Public Methods
    }
}
