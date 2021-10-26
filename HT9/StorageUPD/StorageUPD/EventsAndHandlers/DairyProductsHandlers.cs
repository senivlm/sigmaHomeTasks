using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace StorageUPD
{
    public delegate void GetBadDairyProductsHandler(object sender, string message);

    partial class DairyProductsHandlers
    {
        public static void WriteInLogTXT(object sender, string message)
        {
            string logFilePath = @"F:\my_study\sigma\p9\StorageUPD\StorageUPD\log.txt";

            StreamWriter sw = new StreamWriter(logFilePath, true);
            sw.WriteLine($"Delete bad dairy products method was invoked by {sender} - deleted: {message}. Time - {DateTime.UtcNow}");

            sw.Close();
        }

        public static void WriteInConsole(object sender, string message) 
        {
            Console.WriteLine($"Delete bad dairy products method was invoked by {sender} - deleted: {message}.\nTime - {DateTime.UtcNow}");
        }
    }
}
