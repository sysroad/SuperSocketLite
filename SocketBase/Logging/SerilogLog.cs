using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Events;

namespace SuperSocket.SocketBase.Logging
{
    public class SerilogLogFactory : ILogFactory
    {
        readonly Dictionary<string, ILog> Loggers = new Dictionary<string, ILog>();

        public ILog GetLog(string name) => GetLog(name, null);

        public ILog GetLog(string name, LoggerConfiguration configuration)
        {
            if (Loggers.TryGetValue(name, out var logger))
            {
                return logger;
            }

            if (configuration == null)
            {
                configuration = new LoggerConfiguration().WriteTo.Console();
            }

            logger = new SerilogLog(configuration.CreateLogger());
            Loggers.Add(name, logger);
            return logger;
        }
    }

    public class SerilogLog : ILog
    {
        private readonly ILogger Log;

        public SerilogLog(ILogger log)
        {
            if (log == null)
            {
                throw new ArgumentNullException("log");
            }

            Log = log;
        }

        public bool IsVerboseEnabled => Log.IsEnabled(LogEventLevel.Verbose);

        public bool IsDebugEnabled => Log.IsEnabled(LogEventLevel.Debug);

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsErrorEnabled => Log.IsEnabled(LogEventLevel.Error);

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsFatalEnabled => Log.IsEnabled(LogEventLevel.Fatal);

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsInfoEnabled => Log.IsEnabled(LogEventLevel.Information);

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarnEnabled => Log.IsEnabled(LogEventLevel.Warning);

        public void Verbose(object message) => Log.Debug($"{message}");
        public void Verbose(object message, Exception exception) => Log.Debug(exception, $"{message}");
        public void VerboseFormat(string format, object arg0) => Log.Debug(format, arg0);
        public void VerboseFormat(string format, params object[] args) => Log.Debug(format, args);
        public void VerboseFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Debug(message);
        }
        public void VerboseFormat(string format, object arg0, object arg1) => Log.Debug(format, arg0, arg1);
        public void VerboseFormat(string format, object arg0, object arg1, object arg2) => Log.Debug(format, arg0, arg1, arg2);

        public void Debug(object message) => Log.Debug($"{message}");
        public void Debug(object message, Exception exception) => Log.Debug(exception, $"{message}");
        public void DebugFormat(string format, object arg0) => Log.Debug(format, arg0);
        public void DebugFormat(string format, params object[] args) => Log.Debug(format, args);
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Debug(message);
        }
        public void DebugFormat(string format, object arg0, object arg1) => Log.Debug(format, arg0, arg1);
        public void DebugFormat(string format, object arg0, object arg1, object arg2) => Log.Debug(format, arg0, arg1, arg2);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(object message) => Log.Error($"{message}");

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(object message, Exception exception) => Log.Error(exception, $"{message}");

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void ErrorFormat(string format, object arg0) => Log.Error(format, arg0);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(string format, params object[] args) => Log.Error(format, args);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Error(message);
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void ErrorFormat(string format, object arg0, object arg1) => Log.Error(format, arg0, arg1);

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void ErrorFormat(string format, object arg0, object arg1, object arg2) => Log.Error(format, arg0, arg1, arg2);

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(object message) => Log.Fatal($"{message}");

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(object message, Exception exception) => Log.Fatal(exception, $"{message}");

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void FatalFormat(string format, object arg0) => Log.Fatal(format, arg0);

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(string format, params object[] args) =>Log.Fatal(format, args);

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Fatal(message);
        }

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void FatalFormat(string format, object arg0, object arg1) => Log.Fatal(format, arg0, arg1);

        /// <summary>
        /// Logs the fatal error message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void FatalFormat(string format, object arg0, object arg1, object arg2) => Log.Fatal(format, arg0, arg1, arg2);

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(object message) => Log.Information($"{message}");

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Info(object message, Exception exception) => Log.Information(exception, $"{message}");

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void InfoFormat(string format, object arg0) => Log.Information(format, arg0);

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(string format, params object[] args) => Log.Information(format, args);

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Information(message);
        }

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void InfoFormat(string format, object arg0, object arg1) => Log.Information(format, arg0, arg1);

        /// <summary>
        /// Logs the info message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void InfoFormat(string format, object arg0, object arg1, object arg2) => Log.Information(format, arg0, arg1, arg2);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(object message) => Log.Warning($"{message}");

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Warn(object message, Exception exception) => Log.Warning(exception, $"{message}");

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        public void WarnFormat(string format, object arg0) => Log.Warning(format, arg0);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(string format, params object[] args) => Log.Warning(format, args);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            var message = string.Format(provider, format, args);
            Log.Warning(message);
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        public void WarnFormat(string format, object arg0, object arg1) => Log.Warning(format, arg0, arg1);

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        public void WarnFormat(string format, object arg0, object arg1, object arg2) => Log.Warning(format, arg0, arg1, arg2);
    }
}
