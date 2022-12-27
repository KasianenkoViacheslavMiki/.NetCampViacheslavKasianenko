using HomeWork12_Task1.Model;
using HomeWork12_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Menu
{
    static public class MenuSimulator
    {
        static private void ConsoleLog(Passenger passenger,(int,int) coordinate)
        {
            Console.WriteLine("Був обслугований "+ passenger +" на координатах "+coordinate);
        }
        static Random random = new Random();
        public static void Menu(Simulator simulator)
        {
            Console.WriteLine("N - Відкриття рандомної каси ");
            Console.WriteLine("E - Закриття рандомної каси");
            Console.WriteLine("C - Інформація про каси ");
            Console.WriteLine("I - Інформація про симуляцію");
            Console.WriteLine("Q - Закінчення симуляції");

            simulator.OnCompleted += ConsoleLog;

            while (simulator.RunSimulator)
            {
                var key = Console.ReadKey();
                try
                {
                    if (ConsoleKey.C == key.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Інформація про каси");
                        var infoAboutTicket = simulator.InfoAboutTicket;
                        foreach (var item in infoAboutTicket)
                            Console.WriteLine(item);
                    }
                    if (ConsoleKey.N == key.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Відкриття рандомної каси");
                        simulator.AddTicketOffice(new Model.TicketOffice((random.Next(0, 15), random.Next(0, 1))));
                    }
                    if (ConsoleKey.Q == key.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Закінчення симуляції");
                        simulator.EndSimulator();
                        break;
                    }
                    if (ConsoleKey.E == key.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Закриття рандомної каси");
                        simulator.CloseTicketOffice((uint)random.Next(0, (simulator.CountTicketOffice)));
                    }
                    if (ConsoleKey.I == key.Key)
                    {
                        Console.WriteLine();
                        Console.WriteLine(simulator.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
