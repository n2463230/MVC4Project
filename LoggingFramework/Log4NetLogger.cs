﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoggingFramework
{
    public class Log4NetLogger
    {
        static Log4NetLogger()
        {
            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "Log4Net", "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(string message, Exception exception)
        {
            Log.Debug(message, exception);
        }

        public static void Debug(string message)
        {
            Log.Debug(message);
        }

        public static void Error(string message, Exception exception)
        {
            Log.Error(message, exception);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Info(string message, Exception exception)
        {
            Log.Info(message, exception);
        }

        public static void Info(string message)
        {
            Log.Info(message);
        }

        public static void Info(string message, string userName)
        {
            message = string.Format("{0} - {1}", userName, message);
            Log.Info(message);
        }
    }
}
