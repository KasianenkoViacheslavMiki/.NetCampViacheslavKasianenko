using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Model
{
    public enum StatusPerson
    {
        Regular=0,
        Vip=1,
        Сripple =2
    }
    public class Passenger
    {
        private string name;
        private string surname;
        private uint age;
        private StatusPerson status;
        private uint timeInSec; //Умовні одиниці очікування (В секундах)

        public Passenger(string name, string surname, uint age, StatusPerson status, uint time)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.status = status;
            this.timeInSec = time;
        }

        public uint Age
        {
            get 
            { 
                return age; 
            }
        }
        public StatusPerson Status
        {
            get 
            { 
                return status; 
            }  
        }
        public uint TimeSec
        {
            get 
            { 
                return timeInSec; 
            }
        }

        public override string? ToString()
        {
            return "Імя: |"+ name + " Фамілія: |" + surname + " Вік: |" + age + " Статус: |" + status + " Часу біля каси: "+ TimeSec;
        }
    }
}
