using HomeWork12_Task1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Service
{
    static class GeneratePassengerClass
    {
        static Random random = new Random();
        static string[] dataName = new[] { "Dean", "Oliver", "Fleur", "Xaviera", "Dana", "Stephen", "Emma", "Valentine", "Eve", "Lillian", "Darryl", "Uriel", "Oren", "Ivor", "Abra", "Hyatt", "Rafael", "Dustin", "Phyllis", "Mufutau", "Lucian", "Chelsea", "Hedy", "Joy", "Patience", "Faith", "Howard", "Kameko", "Uriel", "Robin", "Hedda", "Ray", "Brooke", "Len", "Coby", "Jordan", "Amela", "David", "Brock", "Nevada", "Colby", "Myra", "Dorothy", "Bevis", "Audra", "Mia", "Honorato", "Gary", "Rama", "Xander" };
        static string[] dataSurname = new[] { "Randall", "Collier", "Giles", "Higgins", "Townsend", "Cabrera", "Shields", "Moran", "Quinn", "Padilla", "Koch", "Wall", "Pope", "Daniels", "Powell", "Silva", "Bass", "Harris", "Witt", "Gay", "Ruiz", "Smith", "O'Neill", "Carlson", "Quinn", "Pena", "Valdez", "Lynch", "Kim", "Brown", "Boyer", "Berg", "Barker", "Guerrero", "Quinn", "Ferguson", "Sears", "Dunlap", "Sears", "Emerson", "Rasmussen", "Dawson", "Moore", "Walker", "Pierce", "Lopez", "Mason", "Velasquez", "Gaines", "Matthews" };

        static int lowerThresholdTime = 10;
        static int upperThresholdTime = 30;

        static public void SetThresholdTime(uint _lowerThresholdTime, uint _upperThresholdTime)
        {
            if (_lowerThresholdTime > _upperThresholdTime) 
                throw new ArgumentException("_lowerThresholdTime not be higher then _upperThresholdTime");
            lowerThresholdTime = (int) _lowerThresholdTime;
            upperThresholdTime = (int) _upperThresholdTime;
        }


        //Генерування інформації про контрольну групу пасажирів та запис її в файл.
        static public void GeneratePassenger(uint countPassenger,string path)
        {
            //List<Passenger> passes = new List<Passenger>();
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < countPassenger; i++)
                {
                    string name = dataName[random.Next(0, dataName.Length - 1)];
                    string surname = dataSurname[random.Next(0, dataSurname.Length - 1)];
                    uint age = (uint)random.Next(16, 50);
                    StatusPerson status = GetStatusPerson((uint)random.Next(0, 3));
                    uint timeInMinutes = (uint)random.Next(lowerThresholdTime, upperThresholdTime);

                    sw.WriteLine(name + "|" + surname + "|" + age + "|" + status + "|" + timeInMinutes);

                    //passes.Add(new Passenger(name, surname, age, status, timeInMinutes));
                }
            }
            //return passes;
        }
        static private StatusPerson GetStatusPerson(uint countStatus)
        {
            switch (countStatus)
            {
                case 0: 
                    return StatusPerson.Regular;
                case 1: 
                    return StatusPerson.Vip;
                case 2: 
                    return StatusPerson.Сripple;
                default:
                    throw new ArgumentException("Count Status not valid");
            }
        }
    }
}
