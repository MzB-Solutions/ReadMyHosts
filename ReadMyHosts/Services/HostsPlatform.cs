using ReadMyHosts.Core.Models;
using ReadMyHosts.Core.Handlers;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using PostSharp.Patterns.Contracts;

namespace ReadMyHosts.Services
{
    public class HostsPlatform
    {

        private readonly bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        private readonly bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        [Required]
#pragma warning disable CS8618 // Disabled since we are using Required from PostSharp
        private string rootPath;
#pragma warning restore CS8618 

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
                // by virtue of using Required from PostSharp we get an exception of no valid OS found
                rootPath = "";
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