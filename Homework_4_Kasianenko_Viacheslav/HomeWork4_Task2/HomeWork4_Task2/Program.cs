namespace HomeWork4_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayNumber arrayNumber = new ArrayNumber(40);
            arrayNumber.GenerateRandomNumber(1, 7);
            //ArrayNumber arrayNumber = new ArrayNumber(new int[] { 1, 3, 4, 4, 3, 3, 3, 3, 4, 1, 6, 5, 5, 5, 4, 7, 6, 1, 2, 2, 4, 9, 6 });
            Console.WriteLine(arrayNumber);

            //arrayNumber.frequencyTable();
            arrayNumber.FindHighRateSimpleNumber();
        }
    }
}