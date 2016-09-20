using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Logging
{
    public interface ILogger
    {
        void Debug(string message);
        void Debug(string message, Exception exception);
        void DebugFormat(string format, params object[] args);
        void DebugFormat(Exception exception, string format, params object[] args);

        void Trace(string message);
        void Trace(string message, Exception exception);
        void TraceFormat(string format, params object[] args);
        void TraceCurrentMethod(string message);

        void Error(string message);
        void Error(string message, Exception exception);
        void ErrorFormat(string format, params object[] args);
        void ErrorFormat(Exception exception, string format, params object[] args);

        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void FatalFormat(string format, params object[] args);
        void FatalFormat(Exception exception, string format, params object[] args);

        void Info(string message);
        void Info(string message, Exception exception);
        void InfoFormat(string format, params object[] args);
        void InfoFormat(Exception exception, string format, params object[] args);

        void Warning(string message);
        void Warning(string message, Exception exception);
        void WarningFormat(string format, params object[] args);
        void WarningFormat(Exception exception, string format, params object[] args);
    }
}
