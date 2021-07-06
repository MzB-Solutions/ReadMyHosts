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

    public sealed class HostsHandler
    {
        /// <summary>
        /// HostsHandler Constructor
        /// </summary>
        /// TODO (smzb) need to implement custom path logic
        public HostsHandler()
        {
            SysInfo = new Info();
            ReadFile(SysInfo.RootPath);
        }

        // What follows here is an implementation of a Singleton Pattern ###
        // Ensuring, that there truely can only be one!
        private static readonly Lazy<HostsHandler> lazy = new Lazy<HostsHandler>
            (() => new HostsHandler());

        public static HostsHandler Instance {get { return lazy.Value;} }
        // This is the end of the Singleton pattern ###
        public List<Host> HostList { get => hostList; set => hostList = value; }

        // TODO(mitoskalandiel): ReadFile should NOT be passed parameters: see #12
        // should be fixed, since the only calling it now, is our constructor
        private void ReadFile(string rootPath, string path = "etc", string file = "hosts")
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

                    // create a content variable with the content from above
                    Host content = new() { HostId = index, HostName = theHost, FullIpText = items[0], IsEnabled = isEnabled };

                    // add the content to the DB
                    HostList.Add(content);
                    index++;
                }
            }
        }

        private static readonly LogSource logSource = LogSource.Get();

        private readonly Core.Info SysInfo;

        private List<Host> hostList = new();


    }
}
