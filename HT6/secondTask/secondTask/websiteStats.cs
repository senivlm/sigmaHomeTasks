using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace secondTask
{
    class websiteStats
    {
        public string Domen { get; set; }
        private Dictionary<string, IP> users = null;

        public websiteStats(string _domen = null) 
        { 
            this.Domen = _domen;
            users = new Dictionary<string, IP>();
        }

        public void StartInitialisationFromFile(string _filePath) 
        {
            using (var sr = new StreamReader(_filePath)) 
            {
                string connection = sr.ReadLine();

                while (!String.IsNullOrEmpty(connection))
                {
                    string[] connectionDetails = connection.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (!users.ContainsKey(connectionDetails[0]))
                    {
                        users.Add(connectionDetails[0], new IP(connection));
                    }

                    users[connectionDetails[0]].AddRecord(connectionDetails[1], connectionDetails[2]);
                    connection = sr.ReadLine();
                }
            }
        }

        public string GetAllStats() 
        {
            string result = "";
            foreach (string ip in users.Keys)
            {
                result += $"user IP is: {ip}, total count of connections to the website: {users[ip].GetTotalCountOfVisits()}," +
                    $" the most popular day: {users[ip].GetTheMostPopularDay()}, the most popular hour: {users[ip].GetTheMostPopularHour()}\n";          
            }

            return result;
        }

        public int GetMostPopularHourWebsite() 
        {
            int[] hours = new int[24];
            foreach (string ip in users.Keys)
            {
                int[] ipConnections = users[ip].GetConnectionsByHours();
                for (int i = 0; i < 24; i++)
                {
                    hours[i] += ipConnections[i];
                }
            }

            int MostPopularHour = 0;
            int times = hours[0];

            for (int i = 0; i < 24; i++)
            {
                if (hours[i] > times)
                {
                    times = hours[i];
                    MostPopularHour = i;
                }
            }

            return MostPopularHour;
        }

    }
}
