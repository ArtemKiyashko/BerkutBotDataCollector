using System;
using CommandLine;

namespace BerkutBotDataCollector.DataAccess.Options
{
    public class DbCommandArgs
    {
        [Option('c', "ConnectionStringName", Required = true, HelpText = "Please provide connection string setting name")]
        public string ConnectionStringName { get; set; }
    }
}

