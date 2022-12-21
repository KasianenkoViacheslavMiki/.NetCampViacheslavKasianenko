using HomeWork12_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Service
{
    static public class ParseFile
    {
        static public List<Passenger> ParseStrings(string[] strings)
        {
            List<Passenger> passengers = new List<Passenger>();
            foreach (string str in strings)
            {
                string[] split = str.Split("|");
                if (split.Length == 0 || split.Length < 3) 
                    throw new Exception("Not valid string offer for parse");

                uint tempAge;
                if (!uint.TryParse(split[2], out tempAge)) 
                    throw new Exception("Not valid string for parse in uint");

                StatusPerson? tempStatusPerson;
                if (!TryParseStatus(split[3], out tempStatusPerson)) 
                    throw new Exception("Not valid string for parse in StatusPerson");

                uint tempTime;
                if (!uint.TryParse(split[4], out tempTime)) 
                    throw new Exception("Not valid string for parse in uint");

                passengers.Add(new Passenger(split[0], split[1],tempAge, (StatusPerson) tempStatusPerson,tempTime));
            }

            return passengers;
        }
        static public Passenger ParseStrings(string stringParse)
        {
            string[] split = stringParse.Split("|");
            if (split.Length == 0 || split.Length < 3)
                throw new Exception("Not valid string offer for parse");

            uint tempAge;
            if (!uint.TryParse(split[2], out tempAge))
                throw new Exception("Not valid string for parse in uint");

            StatusPerson? tempStatusPerson;
            if (!TryParseStatus(split[3], out tempStatusPerson))
                throw new Exception("Not valid string for parse in StatusPerson");

            uint tempTime;
            if (!uint.TryParse(split[4], out tempTime))
                throw new Exception("Not valid string for parse in uint");

            return new Passenger(split[0], split[1], tempAge, (StatusPerson)tempStatusPerson, tempTime);
        }

        static public List<string> ReadFile(string path)
        {
            if (!File.Exists(path)) 
                throw new FileNotFoundException(path + " not found");
            List<string> strings = new List<string>();
            using (StreamReader readOnlyStream = File.OpenText(path))
            {
                string input;
                while ((input = readOnlyStream.ReadLine()) != null) 
                    strings.Add(input);
            }
            return strings;
        }
        static bool TryParseStatus(string parseString,out StatusPerson? statusPerson)
        {
            switch (parseString)
            {
                case "Regular":
                    {
                        statusPerson = StatusPerson.Regular;
                        return true;
                    }
                case "Сripple":
                    {
                        statusPerson = StatusPerson.Сripple;
                        return true;
                    }
                case "Vip":
                    {
                        statusPerson = StatusPerson.Vip;
                        return true;
                    }
                default:
                    {
                        statusPerson = null;
                        return false;
                    }
            }
        }
    }
}
