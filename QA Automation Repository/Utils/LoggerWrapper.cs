﻿using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Utils
{
    public class LoggerWrapper
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static void LogInfo(string text)
        {
            _logger.Info(text);
        }

        public static void LogError(string text)
        {
            _logger.Error(text);
        }
    }
}
