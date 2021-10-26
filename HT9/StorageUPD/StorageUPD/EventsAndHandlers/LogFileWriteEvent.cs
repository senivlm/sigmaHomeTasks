using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StorageUPD
{
    public delegate void InvalidProductInitialisation(object sender, string problemDescription);
    //This method is used in methods for initialisation

    partial class LogFileWriteEvent
    {
        public static void WriteInLogTXT(object sender, string problemDescription) 
        {//If somebody wants to change the way of logging - it`s possible to choose another function
            string logFilePath = @"F:\my_study\sigma\p9\StorageUPD\StorageUPD\log.txt";

            StreamWriter sw = new StreamWriter(logFilePath, true);
            sw.WriteLine($"Error occured in {sender} - {problemDescription} Time - {DateTime.UtcNow}");
            
            sw.Close();
        }
    }
}