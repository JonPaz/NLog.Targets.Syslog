﻿using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NLog.Targets.Syslog.MessageSend
{
    public abstract class MessageTransmitter
    {
        private const string Localhost = "localhost";
        private const int DefaultSyslogPort = 514;

        /// <summary>The IP address of the Syslog server or an empty string</summary>
        protected string IpAddress { get; private set; }

        private string server;

        /// <summary>The IP address or hostname of the Syslog server</summary>
        public string Server
        {
            get { return server; }
            set { server = value; IpAddress = Dns.GetHostAddresses(Server).FirstOrDefault()?.ToString(); }
        }

        /// <summary>The port number the Syslog server is listening on</summary>
        public int Port { get; set; }

        /// <summary>Builds the base part of a new instance of a class inheriting from MessageTransmitter</summary>
        protected MessageTransmitter()
        {
            Server = Localhost;
            Port = DefaultSyslogPort;
        }

        internal virtual IEnumerable<byte> FrameMessageOrLeaveItUnchanged(IEnumerable<byte> syslogMessage)
        {
            return syslogMessage;
        }

        internal abstract void SendMessages(IEnumerable<byte[]> syslogMessages);
    }
}