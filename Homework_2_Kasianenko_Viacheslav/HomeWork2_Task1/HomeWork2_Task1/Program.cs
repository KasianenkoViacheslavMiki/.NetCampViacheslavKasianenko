namespace HomeWork2_Task1
{
    internal class Program
    {
        static int Main(string[] args)
        {
            RecTangleMatrix recTangleMatrix1 = new RecTangleMatrix(8, 5);
            recTangleMatrix1.InitializationVerticalSnake(true);
            Console.WriteLine(recTangleMatrix1);
            Console.WriteLine();

            RecTangleMatrix recTangleMatrix2 = new RecTangleMatrix(8, 5);
            recTangleMatrix2.InitializationVerticalSnake(false);
            Console.WriteLine(recTangleMatrix2);
            Console.WriteLine();

            RecTangleMatrix recTangleMatrix3 = new RecTangleMatrix(8, 5);
            recTangleMatrix3.InitializationDiagonalSnake(true);
            Console.WriteLine(recTangleMatrix3);
            Console.WriteLine();

            RecTangleMatrix recTangleMatrix4 = new RecTangleMatrix(8, 5);
            recTangleMatrix4.InitializationDiagonalSnake(false);
            Console.WriteLine(recTangleMatrix4);
            Console.WriteLine();

            RecTangleMatrix recTangleMatrix5 = new RecTangleMatrix(8, 5);
            recTangleMatrix5.InitializationSpiralSnake();
            Console.WriteLine(recTangleMatrix5);
            Console.WriteLine();

            return 0;
        }
    }
}