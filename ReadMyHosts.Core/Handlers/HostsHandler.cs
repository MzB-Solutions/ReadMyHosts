using PostSharp.Patterns.Contracts;
using PostSharp.Patterns.Diagnostics;
using ReadMyHosts.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static PostSharp.Patterns.Diagnostics.FormattedMessageBuilder;

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
            SysInfo = new Info();
        }

        #endregion Public Constructors

        #region Public Properties

        public List<Host> HostList { get => hostList; set => hostList = value; }

        #endregion Public Properties

        #region Public Methods

        // TODO(mitoskalandiel): ReadFile should NOT be passed parameters: see #12
        public void ReadFile(string rootPath, string path = "etc", string file = "hosts")
        {
            string fullName = rootPath + path + SysInfo.DirectorySeparator + file;
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
                // Check the first character of our string and see if it is a number, if not, the line is a comment (containing text)
                // TODO(smzb): make sure we also add normal comment lines into our final collection of type `List<Host> : IObservable`
                isComment = !char.IsDigit(items[0][0]);
                if (!isComment)
                {
                    ipDigits = items[0].Split('.');
                    theHost = items[1];

                    if (!ParseMyIP(ipDigits))
                    {
                        logSource.Warning.Write(Formatted("Could NOT parse INTs [{items[0]}]!!!"));
                    }
                    else
                    {
                        logSource.Debug.Write(Formatted("Parsed INTs successfully!!!"));
                    }

                    // create a content variable with the content from above
                    Host content = new() { HostId = index, HostName = theHost, FullIpText = items[0], IsEnabled = isEnabled };

                    // add the content to the DB
                    HostList.Add(content);
                    index++;
                }
            }
        }

        #endregion Public Methods

        #region Private Fields

        private static readonly LogSource logSource = LogSource.Get();

        private readonly Core.Info SysInfo;

        private List<Host> hostList = new();

        #endregion Private Fields

        #region Private Methods

        /// <summary>
        /// parse all 4 strings
        /// </summary>
        /// <remarks>
        /// we are using the 4 Variables B1-B4 as a reference type so that <see cref="int.TryParse(string?, out int)">TryParse gives us our ints
        /// in them, as well as returning us false when one of them failed</see>
        /// FYI: the return on this is a boolean OR, meaning if ANY fails (null return), set output false as a failure indication
        /// </remarks>
        /// <param name="ipBytes">string array containing (hopefully) some numeric input on all 4 elements</param>
        /// <returns>Return false when one of the 4 strings could not be parsed into an <see cref="int">INT</see> type</returns>
        private bool ParseMyIP(string[] ipBytes) =>
                int.TryParse(ipBytes[0], NumberStyles.Integer, null, out B1) ||
                int.TryParse(ipBytes[1], NumberStyles.Integer, null, out B2) ||
                int.TryParse(ipBytes[2], NumberStyles.Integer, null, out B3) ||
                int.TryParse(ipBytes[3], NumberStyles.Integer, null, out B4);

        #endregion Private Methods
    }
}
