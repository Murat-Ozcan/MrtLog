using System;
using System.Collections.Generic;
using System.Text;

namespace LogLayer
{
    public interface ILogger
    {
        void Log(LogEntry entry);
        bool IsEnabledFor(LoggingEventType severityType);
    }
}
