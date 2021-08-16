using NLog;

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
