using System;
using System.Collections.Generic;
using System.Text;
using Serilog.Events;

namespace LogLayer
{
    public class SerilogService : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogService(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Information when IsEnabledFor(LoggingEventType.Information):
                    _logger.Information(entry.Exception, entry.Message);
                    break;
                case LoggingEventType.Debug when IsEnabledFor(LoggingEventType.Debug):
                    _logger.Debug(entry.Exception, entry.Message);
                    break;
                case LoggingEventType.Warning when IsEnabledFor(LoggingEventType.Warning):
                    _logger.Warning(entry.Exception, entry.Message);
                    break;
                case LoggingEventType.Error when IsEnabledFor(LoggingEventType.Error):
                    _logger.Error(entry.Exception, entry.Message);
                    break;
                case LoggingEventType.Fatal when IsEnabledFor(LoggingEventType.Fatal):
                    _logger.Fatal(entry.Exception, entry.Message);
                    break;
                case LoggingEventType.Trace when IsEnabledFor(LoggingEventType.Trace):
                    _logger.Verbose(entry.Exception, entry.Message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool IsEnabledFor(LoggingEventType severityType)
        {
            switch (severityType)
            {
                case LoggingEventType.Information:
                    return _logger.IsEnabled(LogEventLevel.Information);
                case LoggingEventType.Debug:
                    return _logger.IsEnabled(LogEventLevel.Debug);
                case LoggingEventType.Warning:
                    return _logger.IsEnabled(LogEventLevel.Warning);
                case LoggingEventType.Error:
                    return _logger.IsEnabled(LogEventLevel.Error);
                case LoggingEventType.Fatal:
                    return _logger.IsEnabled(LogEventLevel.Fatal);
                case LoggingEventType.Trace:
                    return _logger.IsEnabled(LogEventLevel.Verbose);
                default:
                    return false;
            }
        }
    }
}
