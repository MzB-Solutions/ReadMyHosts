using PostSharp.Patterns.Contracts;
using System;
using System.Runtime.InteropServices;

namespace ReadMyHosts.Core
{
    public static class Info
    {
        #region Public Properties

        [Required]
        public static string DirectorySeparator { get; set; }

        [Required]
        public static string RootPath { get => rootPath; set => rootPath = value; }

        #endregion Public Properties

        #region Public Methods

        public static void SetDirectorySeparator()
        {
            if (IsLinux)
            {
                DirectorySeparator = "/";
            }
            if (IsWindows)
            {
                DirectorySeparator = "\\";
            }
            if (!IsLinux && !IsWindows)
            {
                DirectorySeparator = String.Empty;
            }
        }

        public static void SetHostsRootPath()
        {
            if (IsLinux)
            {
                rootPath = "/";
            }
            if (IsWindows)
            {
                rootPath = "C:\\Windows\\System32\\drivers\\";
            }
            if (!IsLinux && !IsWindows)
            {
                // by virtue of using Required from PostSharp we get an exception if no valid OS found
                rootPath = "";
            }
        }

        #endregion Public Methods

        #region Private Fields

        private static string rootPath;

        #endregion Private Fields

        #region Private Properties

        private static bool IsLinux { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

        private static bool IsWindows { get; } = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        #endregion Private Properties
    }
}
