using HomeWork12_Task1.Menu;
using HomeWork12_Task1.Service;

namespace HomeWork12_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Генерація контрольної групи
            //GeneratePassengerClass.GeneratePassenger(20, "1.txt");

            //Запуск симуляції
            Simulator simulator = new Simulator(5,"result.txt","1.txt");

            simulator.AddTicketOffice(new Model.TicketOffice((1, 2)));
            simulator.AddTicketOffice(new Model.TicketOffice((3, 4)));
            simulator.AddTicketOffice(new Model.TicketOffice((5, 6)));

            simulator.AddExitCoordinate((0, 3));
            simulator.AddExitCoordinate((0, 5));

            try
            {
                simulator.StartSimulator();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Контроль симуляції
            MenuSimulator.Menu(simulator);
        }
    }
}