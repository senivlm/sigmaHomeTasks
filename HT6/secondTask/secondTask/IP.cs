using System;
using System.Collections.Generic;
using System.Text;

namespace secondTask
{
    enum DayOfWeek
    {
        monday = 1,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }



    class IP
    {
        private string ipAdress;
        public string IPAdress
        {
            get { return ipAdress; }
            set { ipAdress = value; }
        }

        //Day of the week    <->    count of visits during it
        private Dictionary<DayOfWeek, int> visitsDuringTheWeek;

        //Hour(from 0 to 23) of any day of the week    <->    count of visits during it
        private Dictionary<int, int> visitsDuringTheDay;

        public IP(string _ip = "000.00.000.001") 
        {
            IPAdress = _ip;

            visitsDuringTheWeek = new Dictionary<DayOfWeek, int>();
            visitsDuringTheWeek.Add(DayOfWeek.monday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.tuesday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.wednesday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.thursday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.friday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.saturday, 0);
            visitsDuringTheWeek.Add(DayOfWeek.sunday, 0);

            visitsDuringTheDay = new Dictionary<int, int>();
            for (int i = 0; i < 24; i++)
            {
                visitsDuringTheDay.Add(i, 0);
            }            
        }


        public void AddRecord(string _time, string _day)
        {
            try
            {
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), _day);
                visitsDuringTheWeek[day] += 1;
            }
            catch (Exception ex) 
            {
                throw new Exception("Invalid day parameter durind adding record");            
            }

            try
            {
                visitsDuringTheDay[Int32.Parse(_time.Split(':')[0])] += 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid time parameter durind adding record");
            }
        }

        public DayOfWeek GetTheMostPopularDay() 
        {
            DayOfWeek theMostPolularDay = DayOfWeek.monday;
            int countOfVisits = visitsDuringTheWeek[DayOfWeek.monday];

            foreach (DayOfWeek key in visitsDuringTheWeek.Keys)
            {
                if (visitsDuringTheWeek[key] > countOfVisits)
                {
                    theMostPolularDay = key;
                    countOfVisits = visitsDuringTheWeek[key];
                }
            }

            return theMostPolularDay;
        }

        public int GetTheMostPopularHour() 
        {
            int theMostPopularHour = 0;
            int countOfVisits = visitsDuringTheDay[0];

            for (int i = 0; i < 24; i++)
            {
                if (visitsDuringTheDay[i] > countOfVisits) 
                {
                    theMostPopularHour = i;
                    countOfVisits = visitsDuringTheDay[i];
                }
            }

            return theMostPopularHour;
        }

        public int GetTotalCountOfVisits() 
        {
            int totalCount = 0;
            foreach (DayOfWeek key in visitsDuringTheWeek.Keys)
            {
                totalCount += visitsDuringTheWeek[key];
            }

            return totalCount;
        }

        public int[] GetConnectionsByHours() 
        {
            int[] hours = new int[24];

            foreach (int hour in visitsDuringTheDay.Keys)
            {
                hours[hour] = visitsDuringTheDay[hour];
            }

            return hours;
        }

    }
}
