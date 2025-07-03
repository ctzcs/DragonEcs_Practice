using System;
using System.Collections.Generic;

namespace Framework
{
    public partial class Logger
    {
        private static readonly Dictionary<string, Logger> Loggers = new();

        private static LogLevel _globalLogLevel;
        private static LogDelegate _appenders;

        public static LogLevel GlobalLogLevel
        {
            get => _globalLogLevel;
            set
            {
                _globalLogLevel = value;
                foreach (var logger in Loggers.Values)
                    logger.LogLevel = value;
            }
        }

        public static void AddAppender(LogDelegate appender)
        {
            _appenders += appender;
            foreach (var logger in Loggers.Values)
                logger.OnLog += appender;
        }

        public static void RemoveAppender(LogDelegate appender)
        {
            _appenders -= appender;
            foreach (var logger in Loggers.Values)
                logger.OnLog -= appender;
        }

        public static Logger GetLogger(Type type)
        {
            return GetLogger(type.FullName);
        }

        public static Logger GetLogger(string name)
        {
            if (!Loggers.TryGetValue(name, out var logger))
            {
                logger = new Logger(name)
                {
                    LogLevel = GlobalLogLevel
                };
                logger.OnLog += _appenders;
                Loggers.Add(name, logger);
            }

            return logger;
        }

        public static void ClearLoggers()
        {
            Loggers.Clear();
        }

        public static void ClearAppenders()
        {
            _appenders = null;
            foreach (var logger in Loggers.Values)
                logger.OnLog = null;
        }
    }
}