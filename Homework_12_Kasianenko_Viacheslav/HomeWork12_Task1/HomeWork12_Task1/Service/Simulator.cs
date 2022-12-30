using HomeWork12_Task1.Action;
using HomeWork12_Task1.Interface;
using HomeWork12_Task1.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Service
{
    public class Simulator
    {
        private uint queueNorm;
        private string pathInput;
        private int countThread=0;
        private int countEndPassengers = 0;
        private List<(int, int)> exitsCoordinat = new List<(int, int)>();

        private StreamWriter sw;

        private object locker = new();

        private bool canWentPassenger = true;

        private bool runSimulator = false;
        private CountdownEvent eventFinish;

        private bool beOverNorm = false;

        public event Action<TicketOffice> OnOverNorm;
        public event Action<Passenger,(int,int)> OnCompleted;

        private Random random = new Random();

        private List<TicketOffice> listTicketOffice = new List<TicketOffice>();

        //Стратегії
        private IMinTicketOffice minTicketOfficeStrategy;


        //Ініціалізація класу
        public Simulator(uint queueNorm, string pathOutput, string pathInput)
        {
            this.queueNorm = queueNorm;
            this.pathInput = pathInput;
            this.sw = new StreamWriter(pathOutput);
        }
        public List<string> InfoAboutTicket
        {
            get
            {
                List<string> result = new List<string>();
                lock (locker)
                {
                    foreach (TicketOffice ticket in listTicketOffice)
                    {
                        result.Add(ticket.ToString());
                    }
                }
                return result;
            }
        }
        public int CountTicketOffice
        {
            get 
            { 
                return listTicketOffice.Count; 
            }
        }

        //Методи зміни стратегій
        private void ChangeMinTicketOfficeStrategy(IMinTicketOffice _minTicketOfficeStrategy)
        {
            minTicketOfficeStrategy= _minTicketOfficeStrategy;  
        }
 
        public bool RunSimulator 
        { 
            get => runSimulator;
        }

        //Додавання кас
        public void AddTicketOffice(TicketOffice _ticketOffice)
        {
            listTicketOffice.Add(_ticketOffice);
            if (runSimulator)
            {
                ThreadPool.QueueUserWorkItem(ThreadTicketOffice, _ticketOffice);
                countThread++;
            }
        }   
        //Додавання входів
        public void AddExitCoordinate((int,int) exitCoordinate)
        {
            lock (locker)
            {
                exitsCoordinat.Add(exitCoordinate);
            }
        }
        //Ініціалізація потоків
        private void InitThread()
        {
            foreach (TicketOffice ticketOffice in listTicketOffice)
            {
                ThreadPool.QueueUserWorkItem(ThreadTicketOffice, ticketOffice);
                countThread++;
            }

            ThreadPool.QueueUserWorkItem(ThreadWentPassenger);
            countThread++;
            eventFinish = new CountdownEvent(countThread);
        }
        
        //Прихід пассажира

        //private void WentPassenger(Passenger passenger)
        //{
        //    (int, int) coordinateWentPassenger;
        //    lock (locker)
        //    {
        //        coordinateWentPassenger = exitsCoordinat[random.Next(0, exitsCoordinat.Count)];
        //    }

        //    TicketOffice ticketOffice = GetNeedTicketOffice(coordinateWentPassenger);

        //    ticketOffice.AddPassangerToQueue(passenger,(int)passenger.Status);

        //    if (ticketOffice.Count > queueNorm)
        //    {
        //        OnOverNorm?.Invoke(ticketOffice);
        //        ActionOverNorm(ticketOffice);
        //    }
        //}
        private void WentPassenger(Passenger passenger, (int, int) coordinateWentPassenger)
        {
            IMinTicketOffice minTicketOffice = null;

            TicketOffice ticketOffice = GetNeedTicketOffice(coordinateWentPassenger);

            ticketOffice.AddPassangerToQueue(passenger, (int)passenger.Status);

            if (ticketOffice.Count > queueNorm)
            {
                OnOverNorm?.Invoke(ticketOffice);
                ActionOverNorm(ticketOffice);
            }
        }

        private TicketOffice GetNeedTicketOffice((int, int) coordinateWentPassenger)
        {
            TicketOffice ticketOffice = listTicketOffice[0];

            bool equal = true;

            for (int i = 0; i < listTicketOffice.Count - 1; i++)
            {
                if (listTicketOffice[i].IsOpen && listTicketOffice[i].Count != listTicketOffice[i + 1].Count)
                {
                    equal = false;
                    break;
                }
            }

            if (equal)
            {
                ChangeMinTicketOfficeStrategy(new MinTicketDistance());
            }
            else 
            {
                ChangeMinTicketOfficeStrategy(new MinCount());
            }

            ticketOffice = minTicketOfficeStrategy.Min(listTicketOffice, coordinateWentPassenger);

            return ticketOffice;
        }

        private void ActionOverNorm(TicketOffice ticketOffice)
        {
            if (beOverNorm)
            {
                canWentPassenger = false;
            }
            else
            {
                beOverNorm = true;
                ThreadPool.QueueUserWorkItem(ThreadOverNorm, ticketOffice);
                eventFinish.AddCount();
            }
        }

        private void ThreadOverNorm(object? objectThread)
        {
            TicketOffice ticketOffice = (TicketOffice) objectThread;   
            List<Passenger> listPassenger =  ticketOffice.ReworkQueue(queueNorm);
            foreach (Passenger passenger in listPassenger)
            {
                WentPassenger(passenger, ticketOffice.Coordinate);
            }
            eventFinish.Signal();
        }
        //Функція потоку приходу пасажирів
        private void ThreadWentPassenger(object? objectThread)
        {
            Passenger wentPassenger;
            (int, int) coordinateWentPassenger;
            using (StreamReader readOnlyStream = File.OpenText(pathInput))
            {
                string input;
                while ((input = readOnlyStream.ReadLine()) != null)
                {
                    lock (locker)
                    {
                        coordinateWentPassenger = exitsCoordinat[random.Next(0, exitsCoordinat.Count)];
                    }
                    if (!runSimulator) break;
                    if (canWentPassenger)
                    {
                        wentPassenger = ParseFile.ParseStrings(input);
                        lock (locker)
                        {
                            WentPassenger(wentPassenger, coordinateWentPassenger);
                        }
                        Thread.Sleep(2000);
                    }
                }
            }
            eventFinish.Signal();
        }
        //Функція потоку каси
        private void ThreadTicketOffice(object? ticketOffice)
        {
            TicketOffice ticketOfficeThread = (TicketOffice) ticketOffice;

            while (runSimulator && ticketOfficeThread.IsOpen) //Перевірка чи симуляція йде далі чи офіс відчинений
            {
                if (ticketOfficeThread.Count > 0) //Перевірка чи є пассажир на цій касі
                {
                    Passenger passenger;

                    lock (locker)
                    {
                        passenger = ticketOfficeThread.GetPassanger();
                    }

                    Thread.Sleep((int)passenger.TimeSec * 1000);

                    lock (locker)
                    {
                        OnCompleted?.Invoke(passenger, ticketOfficeThread.Coordinate);
                        EndPassanger(passenger, sw, ticketOfficeThread.Coordinate);
                        ticketOfficeThread.CompletedPassanger();
                    }
                    if (!canWentPassenger)
                    {
                        lock (locker)
                        {
                            if (ticketOfficeThread.Count < queueNorm/2)
                            {
                                canWentPassenger = true;
                            }
                        }
                    }
                }
            }
            eventFinish.Signal();
        }
        //Функція потоку переформатування черги
        private void ThreadFormatPassengers(object? listPassnegers)
        {
            (List<Passenger>, (int, int)) rewentListPassengers = ((List<Passenger>, (int, int)))listPassnegers;

            foreach (Passenger passenger in rewentListPassengers.Item1)
            {
                lock (locker)
                {
                    WentPassenger(passenger, rewentListPassengers.Item2);
                }
            }

        }
        //Записування пассажира в файл
        private void EndPassanger(Passenger passenger, StreamWriter streamWriter, (int,int) coordinate)
        {
            streamWriter.WriteLine("|№ "+(++countEndPassengers) +"| Пасажир: "+ passenger+ "| Був обслужений касой яка знаходиться на таких координатах "+coordinate);
        }

        //Закінчення симуляції
        public void EndSimulator()
        {
            runSimulator = false;
            eventFinish.Wait();
            sw.Close();
        }

        //Закриття каси
        public void CloseTicketOffice(uint numberTicketOffice)
        {
            if (numberTicketOffice < listTicketOffice.Count)
                throw new IndexOutOfRangeException("NumberTicketOffice Index out of range");

            (int,int) coordinateTicketOffice = listTicketOffice[(int)numberTicketOffice].Coordinate;

            (List<Passenger>,(int,int)) rewentListPassenger =  (listTicketOffice[(int)numberTicketOffice].CloseTicketOffice(),coordinateTicketOffice);

            ThreadPool.QueueUserWorkItem(ThreadFormatPassengers,rewentListPassenger);
        }
        //Запуск симулятора
        public void StartSimulator( )
        {
            if (runSimulator)
                throw new Exception("Simulator run");

            if (exitsCoordinat.Count == 0)
                throw new Exception("Not have exits");

            

            if (listTicketOffice.Count == 0) 
                throw new Exception("Not have ticket office");
            runSimulator = true;
            InitThread();
        }

        public override string? ToString()
        {
            return "Статус симулятора " + runSimulator + "| Кількість відкритих кас " + listTicketOffice.Count + "| Кількість обслугованих пассажирів "+countEndPassengers;
        }
    }
}
