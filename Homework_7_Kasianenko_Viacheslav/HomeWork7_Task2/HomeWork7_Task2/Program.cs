namespace HomeWork7_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MasterCard
            string card_number = "5555-5555-5555-4444";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //MasterCard
            card_number = "5555555555554445";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //American Express
            card_number = "378282246310005";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //MasterCard
            card_number = "5555555555554444";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //Visa
            card_number = "4222222222222";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //Visa
            card_number = "4003789100205381";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //American Express 
            card_number = "378282246310005";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //American Express
            card_number = "371449635398431";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //American Express Corporate
            card_number = "378734493671000";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //MasterCard
            card_number = "5555555555554444";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //MasterCard
            card_number = "5105105105105100";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //Visa 
            card_number = "4111111111111111";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //Visa 
            card_number = "4012888888881881";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();

            //Visa 
            card_number = "4222222222222";
            Console.WriteLine(CheckCard.InfoCheckCard(card_number));
            Console.WriteLine();
        }
    }
}