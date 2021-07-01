using PostSharp.Patterns.Contracts;
using System;
using System.Runtime.InteropServices;

namespace ReadMyHosts.Core
{
    public class Info
    {
        #region Public Constructors

        public Info()
        {
            SetHostsRootPath();
        }

        #endregion Public Constructors

        #region Public Properties

        [Required]
        public string DirectorySeparator { get; set; }

        [Required]
        public string RootPath { get; set; }

        #endregion Public Properties

        #region Private Properties

        private static bool IsLinux { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        private static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        #endregion Private Properties

        #region Private Methods

        private void SetHostsRootPath()
        {
            if (IsLinux)
            {
                DirectorySeparator = "/";
                RootPath = "/";
            }
            if (IsWindows)
            {
                DirectorySeparator = "\\";
                RootPath = String.Format("C:{0}Windows{0}System32{0}drivers{0}", DirectorySeparator);
            }
            if (!IsLinux && !IsWindows)
            {
                // by virtue of using Required from PostSharp we get an exception if no valid OS found
                RootPath = String.Empty;
                DirectorySeparator = String.Empty;
            }
        }

        #endregion Private Methods
    }
}
