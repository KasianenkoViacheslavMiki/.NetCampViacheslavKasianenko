namespace HomeWork2_Task2
{
    internal class Program
    {
        static int Main(string[] args)
        {

            MatrixColor matrixColor = new MatrixColor(new int[,] { { 0,1,2,3,4,5,6,7,8,9 }, 
                                                                   { 1,4,4,1,2,3,4,5,6,1 }, 
                                                                   { 2,6,5,5,4,5,5,5,5,1 }, 
                                                                   { 3,8,3,5,7,1,7,1,1,1 } });
            Console.WriteLine(matrixColor);

            int firstIndex;
            int lastIndex;
            int length;
            int color = matrixColor.searchLongLineColor(out firstIndex, out lastIndex,out length);

            Console.WriteLine("Color: " + color + " first index " + firstIndex + " last index " + lastIndex + " length " + length);

            Console.WriteLine();

            MatrixColor matrixColor1 = new MatrixColor(8, 8);
            matrixColor1.RandomInitialization();

            Console.WriteLine(matrixColor1);

            color = matrixColor1.searchLongLineColor(out firstIndex, out lastIndex, out length);

            Console.WriteLine("Color: " + color + " first index " + firstIndex + " last index " + lastIndex + " length " + length);

            return 0;
        }
    }
}