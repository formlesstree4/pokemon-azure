using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace MercurySvc
{
    public partial class Entry : ServiceBase
    {

        private Mercury.Mercury _systemServer;

        public Entry()
        {
            InitializeComponent();
            // ServiceName = "Mercury Trade Server";
            _systemServer = new Mercury.Mercury(2500);
        }

        public void MercuryLoggingRoutine(Mercury.MercuryOutputEventArgs e)
        {
            WriteEventEntry(e.Output, EventLogEntryType.Information, 0, 0);
        }

        public void MercuryErrorRoutine(Mercury.MercuryErrorEventArgs e)
        {
            WriteEventEntry(e.Message + e.Exception, EventLogEntryType.Error, 0, 0);
        }

        protected override void OnStart(string[] args)
        {
            WriteEventEntry("Starting Mercury!", EventLogEntryType.Information, 0, 0);
            _systemServer = new Mercury.Mercury(2500);
            _systemServer.Output += MercuryLoggingRoutine;
            _systemServer.Error += MercuryErrorRoutine;
            _systemServer.Start();
            // base.OnStart(args);
            WriteEventEntry("Done Starting!", EventLogEntryType.Information, 0, 0);
        }

        protected override void OnStop()
        {
            WriteEventEntry("Shutting down Mercury", EventLogEntryType.Information, 0, 0);
            _systemServer.Stop();
            _systemServer.Output -= MercuryLoggingRoutine;
            _systemServer.Error -= MercuryErrorRoutine;
            _systemServer.Dispose();
            WriteEventEntry("Shutdown Complete, passing to base.", EventLogEntryType.Information, 0, 0);
            base.OnStop();
        }

        protected override void OnCustomCommand(int command)
        {
            if(command == 0)
                EventLog.Clear();
            base.OnCustomCommand(command);
        }


        protected void WriteEventEntry(string message, EventLogEntryType eventType, int id, short category)
        {
            // Select the log.
            EventLog.Log = "Application";

            // Define the source.
            EventLog.Source = ServiceName;
            
            // Write the log entry.
            EventLog.WriteEntry(message, eventType, id, category);
        }
    }
}
