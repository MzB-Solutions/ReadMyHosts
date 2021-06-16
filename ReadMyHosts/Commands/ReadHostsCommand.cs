using Microsoft.Extensions.Logging;
using ReadMyHosts.Core.Handlers;

using System.Windows;

namespace ReadMyHosts.Commands
{
    internal class ReadHostsCommand : CommandBase
    {
        private readonly ILogger<ReadHostsCommand> _readHostsCommandLogger;

        public ReadHostsCommand(ILogger<ReadHostsCommand> readHostsCommandLogger)
        {
            _readHostsCommandLogger = readHostsCommandLogger;
        }

        public override void Execute(object parameter)
        {
            HostsHandler handler = new();
            _readHostsCommandLogger.LogInformation("Attempting to read and parse 'hosts' file");

            // This is the long way of doing this on a default windows install
            // handler.ReadFile("C:\\Windows\\System32\\drivers\\etc\\", "hosts");

            // Do this to use default values
            handler.ReadFile();

            MessageBox.Show(handler.HostList.ToString(), "Done", MessageBoxButton.OK);
        }
    }
}