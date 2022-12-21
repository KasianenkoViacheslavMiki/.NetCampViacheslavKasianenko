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
        static Random random = new Random();
        public static void Menu(Simulator simulator)
        {
            while (simulator.RunSimulator)
            {
                var key = Console.ReadKey();
                try
                {
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
