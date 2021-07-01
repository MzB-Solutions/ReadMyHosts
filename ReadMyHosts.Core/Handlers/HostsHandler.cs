//using Microsoft.Extensions.Logging;
using PostSharp.Patterns.Contracts;
using ReadMyHosts.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReadMyHosts.Core.Handlers
{
    public class HostsHandler
    {
        #region Public Constructors

        /// <summary>
        /// HostsHandler Constructor
        /// </summary>
        public HostsHandler()
        {
            Info.SetDirectorySeparator();
            Info.SetHostsRootPath();
        }

        #endregion Public Constructors

        #region Public Properties

        //private readonly ILogger<HostsHandler> _hostsHandlerLogger;
        public List<Host> HostList { get => hostList; set => hostList = value; }

        #endregion Public Properties

        #region Public Methods

        public void ReadFile(string rootPath, string path = "etc", string file = "hosts")
        {
            string fullName = rootPath + path + Info.DirectorySeparator + file;
            string line;
            int index = 0;

            // Regex to search for 1 or more whitespaces (<= all Regex is Voodoo to me lol, thank you SO for this one)
            Regex whitespaceRegex = new(@"\s+");

            // open the filestream for reading
            // TODO(smzb): do a try loop here to catch stuff going wrong
            StreamReader reader = File.OpenText(fullName);
            // read file line by line
            while ((line = reader.ReadLine()) != null)
            {
                string[] ipDigits;
                string theHost;
                string[] items = whitespaceRegex.Split(line);
                bool isEnabled;
                bool isComment;
                if (line.StartsWith("#"))
                {
                    isEnabled = false;
                    items = items.Where((item, index) => index != 0).ToArray();
                }
                else
                {
                    isEnabled = true;
                }
                // Check the first character of our string and see if it is a number, if not, the line is a comment
                isComment = !char.IsDigit(items[0][0]);
                if (!isComment)
                {
                    ipDigits = items[0].Split('.');
                    theHost = items[1];

                    if (!ParseMyIP(ipDigits))
                    {
                        //CoreLogger.DebugLog.Debug("Could NOT parse INTs!!");
                    }
                    else
                    {
                        //CoreLogger.DebugLog.Debug("Parsed INTs successfully");
                    }

                    // create a content variable with the content from above
                    Host content = new() { HostId = index, HostName = theHost, FullIp = ReturnIP(B1, B2, B3, B4), FullIpText = items[0], IsEnabled = isEnabled };

                    // add the content to the DB
                    HostList.Add(content);
                    index++;
                }
            }
        }

        #endregion Public Methods

        #region Private Fields

        [Range(0, 255)]
        private int B1;

        [Range(0, 255)]
        private int B2;

        [Range(0, 255)]
        private int B3;

        [Range(0, 255)]
        private int B4;

        private List<Host> hostList = new();

        #endregion Private Fields

        #region Private Methods

        private static byte[] ReturnIP(int a, int b, int c, int d)
        {
            byte[] ipDecimals = { (byte)a, (byte)b, (byte)c, (byte)d };
            for (int i = 0; i < ipDecimals.Length; i++)
            {
                ipDecimals[i] = ipDecimals[i];
            }
            return ipDecimals;
        }

        // Basically parse all 4 strings into ints and if not successfull return false, otherwise true
        private bool ParseMyIP(string[] ipBytes) =>
                int.TryParse(ipBytes[0], NumberStyles.Integer, null, out B1) ||
                int.TryParse(ipBytes[1], NumberStyles.Integer, null, out B2) ||
                int.TryParse(ipBytes[2], NumberStyles.Integer, null, out B3) ||
                int.TryParse(ipBytes[3], NumberStyles.Integer, null, out B4);

        #endregion Private Methods
    }
}
