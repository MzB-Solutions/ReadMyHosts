using ReadMyHosts.Core.Models;
using ReadMyHosts.Core.Handlers;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PostSharp.Patterns.Contracts;

namespace ReadMyHosts.Services
{
    public class HostsPlatform
    {

        private bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        private string rootPath;

        public string GetRootPath()
        {
            return rootPath;
        }

        public void SetRootPath()
        {
            if (isLinux)
            {
                rootPath = "/";
            }
            if (isWindows)
            {
                rootPath = "C:\\Windows\\System32\\drivers\\";
            }
            if (!isLinux&&!isWindows) {
                // we should be throwing something here since we are running neither!!
            }
        }


        public IEnumerable<Host> GetData() {
            var handler = new HostsHandler();
            SetRootPath();
            handler.ReadFile(GetRootPath());
            return handler.HostList;
        }
    }
}