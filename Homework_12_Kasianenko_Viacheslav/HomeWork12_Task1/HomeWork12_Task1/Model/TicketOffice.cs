using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Model
{
    public class TicketOffice
    {
        private (int,int) coordinate;
        private PriorityQueue<Passenger,int> peoples = new PriorityQueue<Passenger,int>();
        private bool thisIsOpen = true;

        private bool beOverNorm=   false;

        public TicketOffice((int, int) coordinate)
        {
            this.coordinate = coordinate;
        }
        public bool IsOpen
        {
            get 
            { 
                return thisIsOpen; 
            }
        }
        public (int, int) Coordinate 
        {
            get 
            { 
                return coordinate; 
            }
        }
        public int Count
        {
            get
            {
                return peoples.Count;
            }
        }
        public void ChangePropertyBeOverNorm()
        {
            beOverNorm = !beOverNorm;
        }
        public List<Passenger> CloseTicketOffice()
        {
            thisIsOpen = false;
            List<Passenger> list = new List<Passenger>();

            while (peoples.Count !=0)
            {
                list.Add(peoples.Dequeue());
            }

            return list;
        }

        public void AddPassangerToQueue(Passenger passenger,int priority)
        {
            peoples.Enqueue(passenger, priority);
        }
        public void AddPassangerToQueue(Dictionary<Passenger,int> passengers)
        {
            foreach (var passenger in passengers) 
                peoples.Enqueue(passenger.Key, passenger.Value);
        }
        public double GetDistance((int,int) coordinate)
        {
            return Math.Sqrt(Math.Pow(coordinate.Item2 - this.coordinate.Item2,2)+ Math.Pow(coordinate.Item1 - this.coordinate.Item1, 2));
        }
        //Вернути тих хто був в кінці черги, оставити тих хто в норму входить
        public List<Passenger> ReworkQueue(uint normQueue)
        {
            List<Passenger> result = new List<Passenger>();
            int count = peoples.Count;
            if (count < normQueue)
                throw new ArgumentException("Norm queue less count passengers");
            PriorityQueue<Passenger,int> priorityQueue = new PriorityQueue<Passenger,int>();
            List<Passenger> list = new List<Passenger>();

            int i;

            for (i = 0; i < count - normQueue; i++)
            {
                Passenger passenger = priorityQueue.Dequeue();
                priorityQueue.Enqueue(passenger,(int)passenger.Status);
            }
            for (; i < normQueue; i++)
            {
                result.Add(peoples.Dequeue());
            }
            peoples.Clear();
            peoples = priorityQueue;

            return result;
        }

        public Passenger GetPassanger()
        {
            return peoples.Peek();
        }
        public void CompletedPassanger()
        {
            peoples.Dequeue();
        }
        
    }
}
