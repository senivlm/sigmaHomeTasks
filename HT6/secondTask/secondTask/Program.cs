using System;

namespace secondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                129.18.130.124 9:12:45 sunday
                129.18.130.124 21:11:24 monday
                129.18.130.124 9:12:44 sunday
                129.18.130.124 13:33:40 tuesday
                129.18.130.124 23:7:44 friday
                129.18.130.124 22:12:44 monday
                129.18.130.124 23:12:44 monday
                139.18.150.126 11:12:44 sunday
                139.18.150.126 12:11:7 tuesday
                139.18.150.126 12:12:4 friday
                139.18.150.126 20:32:24 tuesday
                139.18.150.126 23:22:45 thursday
                119.18.140.127 23:24:35 friday
                119.18.140.127 4:25:15 friday
                119.18.140.127 4:33:5 tuesday
                119.18.140.127 12:22:35 monday
                119.18.140.127 2:2:40 saturday
             */



            websiteStats website1 = new websiteStats("Google.com");
            website1.StartInitialisationFromFile(@"F:\my_study\sigma\p6\secondTask\secondTask\bin\Debug\netcoreapp3.1\stats.txt");


            Console.WriteLine(website1.GetAllStats());
            Console.WriteLine(website1.GetMostPopularHourWebsite() + "is the most popular");

            //Console.Read();
        }
    }
}
