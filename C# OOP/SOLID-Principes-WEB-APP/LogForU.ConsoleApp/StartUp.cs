using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Appenders;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;
using System;
using LogForU.Core.Enums;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.IO;
using LogForU.ConsoleApp.CustomLayouts;

namespace LogForU.ConsoleApp
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);
            var logger = new Logger(consoleAppender);

            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");



        }
    }
}