using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Logging
{
    public class CommonLogger : ILogger
    {
        #region Private members

        private NLog.ILogger _logger;

        #endregion Private members

        #region .Ctor

        internal CommonLogger(string loggerName)
        {
            _logger = NLog.LogManager.GetLogger(loggerName);
        }

        internal CommonLogger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        #endregion .Ctor


        #region Methods

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            _logger.Debug(exception, message, new object[0]);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            _logger.Debug(exception, format, args);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Trace(string message, Exception exception)
        {
            _logger.Trace(exception, message, new object[0]);
        }

        public void TraceCurrentMethod(string message)
        {
            _logger.Trace(string.Format("{0} - {1}", new System.Diagnostics.StackFrame(1).GetMethod().Name, message));
        }

        public void TraceFormat(string format, params object[] args)
        {
            _logger.Trace(format, args);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Error(exception, message, new object[0]);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Error(format, args);
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            _logger.Error(exception, format, args);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception, message, new object[0]);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            _logger.Fatal(exception, format, args);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Info(string message, Exception exception)
        {
            _logger.Info(exception, message, new object[0]);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            _logger.Info(exception, format, args);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Warning(string message, Exception exception)
        {
            _logger.Warn(exception, message, new object[0]);
        }

        public void WarningFormat(string format, params object[] args)
        {
            _logger.Warn(format, args);
        }

        public void WarningFormat(Exception exception, string format, params object[] args)
        {
            _logger.Warn(exception, format, args);
        }

        #endregion Methods

    }
}