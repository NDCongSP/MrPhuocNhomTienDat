using System;
using System.IO;

namespace DemoPhucThinh.Common
{
    public static class Logger
    {
        private static readonly string logPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "app.log.txt");

        public static void Log(string message)
        {
            try
            {
                File.AppendAllText(logPath,
                    $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
            }
            catch { /* tránh crash nếu lỗi ghi file */ }
        }
    }
}
