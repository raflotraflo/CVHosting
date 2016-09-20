using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository.Repo;
using Repository.Models;

namespace Repository.Logging
{
    public class DatabaseLogger : ILogger
    {
        private ILoggerContext _db;

        public DatabaseLogger()
        {
            _db = new CVHostingContext();
        }

        private void AddMessage(string message, string type)
        {
                MessageLog msg = new MessageLog() { Excepction = message, Type = type };
                _db.MessageLog.Add(msg);
                _db.SaveChanges();
        }

        private void AddMessage(string message, Exception ex, string type)
        {
            MessageLog msg = new MessageLog()
            {
                Excepction = message + " Exception: " + ex.ToString(),
                Path = ex.Source,
                Type = type
            };
            _db.MessageLog.Add(msg);
            _db.SaveChanges();
        }

        public void Debug(string message)
        {
            AddMessage(message, "Debug");
        }

        public void Debug(string message, Exception exception)
        {
            AddMessage(message, exception, "Debug");
        }

        public void DebugFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Debug");
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, exception, "Debug");
        }

        public void Error(string message)
        {
            AddMessage(message, "Error");
        }

        public void Error(string message, Exception exception)
        {
            AddMessage(message, exception, "Debug");
        }

        public void ErrorFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Debug");
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, exception, "Error");
        }

        public void Fatal(string message)
        {
            AddMessage(message, "Fatal");
        }

        public void Fatal(string message, Exception exception)
        {
            AddMessage(message, exception, "Fatal");
        }

        public void FatalFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Fatal");
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, exception, "Fatal");
        }

        public void Info(string message)
        {
            AddMessage(message, "Info");
        }

        public void Info(string message, Exception exception)
        {
            AddMessage(message, exception, "Fatal");
        }

        public void InfoFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Info");
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, exception, "Info");
        }

        public void Trace(string message)
        {
            AddMessage(message, "Trace");
        }

        public void Trace(string message, Exception exception)
        {
            AddMessage(message, exception, "Fatal");
        }

        public void TraceCurrentMethod(string message)
        {
            AddMessage(message, "Trace");
        }

        public void TraceFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Trace");
        }

        public void Warning(string message)
        {
            AddMessage(message, "Warning");
        }

        public void Warning(string message, Exception exception)
        {
            AddMessage(message, exception, "Warning");
        }

        public void WarningFormat(string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, "Warning");
        }

        public void WarningFormat(Exception exception, string format, params object[] args)
        {
            string message = "";
            args.ToList().ForEach(x => message += x.ToString());
            AddMessage(message, exception, "Warning");
        }
    }
}