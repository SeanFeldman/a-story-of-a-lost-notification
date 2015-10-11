using System;

namespace Registration
{
    public static class Logger
    {
        public static void Log(string what, Exception exception = null)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {what}\n{exception}");
        }
    }
}