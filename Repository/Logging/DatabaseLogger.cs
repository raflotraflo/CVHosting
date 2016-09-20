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
            _db = new LoggerContext();
        }

        private void AddMessage(string message)
        {
            MessageLog msg = new MessageLog() { Excepction = message };
            _db.MessageLog.Add(msg);
            _db.SaveChanges();
        }

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Trace(string message)
        {
            throw new NotImplementedException();
        }

        public void Trace(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void TraceCurrentMethod(string message)
        {
            throw new NotImplementedException();
        }

        public void TraceFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void WarningFormat(string format, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void WarningFormat(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}