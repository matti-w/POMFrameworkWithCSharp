using Serilog;

namespace E2E.UI.Test.Helper.Logger
{
    public class Log
    {
        private static readonly ILogger logger;

        static Log()
        {
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMdd_HHmmss");
            logger = new LoggerConfiguration().WriteTo.File(path: ReportPath($"Log_{formattedDateTime}")).CreateLogger();
        }

        public static void Info(string message)
        {
            logger.Information(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Error(string message, Exception e)
        {
            logger.Error(message, e);
        }

        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        public static void Warn(string message)
        {
            logger.Warning(message);
        }

        private static string ReportPath(string fileName)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + $"TestRunLog\\{fileName}.txt";
            return reportPath;
        }
    }
}
