using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Contracts;

namespace ReadMyHosts.Core
{
    public static class Info
    {
        public static bool IsLinux { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        public static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    }
}
