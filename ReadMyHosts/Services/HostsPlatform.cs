using ReadMyHosts.Core.Models;
using ReadMyHosts.Core.Handlers;
using System.Collections.Generic;
using PostSharp.Patterns.Contracts;

namespace ReadMyHosts.Services
{
    public class HostsPlatform
    {

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
            if (Core.Info.IsLinux)
            {
                rootPath = "/";
            }
            if (Core.Info.IsWindows)
            {
                rootPath = "C:\\Windows\\System32\\drivers\\";
            }
            if (!Core.Info.IsLinux && !Core.Info.IsWindows) {
                // by virtue of using Required from PostSharp we get an exception if no valid OS found
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