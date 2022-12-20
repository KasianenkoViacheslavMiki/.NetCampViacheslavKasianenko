using HomeWork9_Task1.Service;
using HomeWork9_Task1.Test;

namespace HomeWork9_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Генерація файла чисел.
            ActionFile.WriteFile("input.txt", new Generate().GenerateList(50, 60 , 0, 50).ToArray());

            new MergeSortFile().ExternalSort("input.txt");
        }
    }
}