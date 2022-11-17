using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4_Task2
{
    public class ArrayNumber
    {
        private int[] arrayNumbers;

        //Constuctor for generate array with random numbers.
        public ArrayNumber(int from, int to,int sizeArray)
        {
            Random random = new Random();
            arrayNumbers = new int[sizeArray];
            GenerateRandomNumber(from, to);
        }

        public ArrayNumber(int[] arrayNumbers)
        {
            this.ArrayNumbers = arrayNumbers;
        }

        public ArrayNumber(int sizeArray)
        {
            arrayNumbers = new int[sizeArray];
        }

        public int[] ArrayNumbers 
        { 
            get => arrayNumbers; 
            set => arrayNumbers = value; 
        }
        //Indexator for access
        public int this[int index]
        {
            set => arrayNumbers[index] = value;
            get => arrayNumbers[index];
        }
        public void GenerateRandomNumber(int from, int to)
        {
            Random random = new Random();
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayNumbers[i] = random.Next(from, to);
            }
        }
        //Method for print Freqency table for all numbers
        public void FrequencyTable()
        {// алгоритмічно не правильна реалізація
            int[] table = new int[0];
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (table.Length == 0 || table.Length < arrayNumbers[i])
                {
                    Array.Resize(ref table, arrayNumbers[i]+2);
                }
                table[arrayNumbers[i]]++;
            }
            Console.WriteLine("| Number --------------- Occurs |");
            for (int i = 0; i < table.Length; i++)
            {   
                if (table[i] != 0) Console.WriteLine("| "+i+"   ---------------- "+table[i]+" |");
            }
        }
        //Method for 
        private bool IsPrime(int number)
        {//Можна скоротити цикл
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        public void FindHighRateSimpleNumber()
        {
            int firstNumber=0;
            int countFirstNumber = 0;
            int endFirstNumber = 0;

            int secondNumber = 0;
            int countSecondNumber = 0;
            int endSecondNumber = 0;


            if (arrayNumbers.Length == 0) return;

            int findNumber = arrayNumbers[0];
            int countFindNumber = 1;

            for (int i=1; i<arrayNumbers.Length; i++)
            {
                if (IsPrime(arrayNumbers[i]))
                {
                    if (arrayNumbers[i] == findNumber)
                    {
                        countFindNumber++;
                    }
                    else
                    {
                        if (countFirstNumber < countFindNumber && countSecondNumber < countFindNumber)
                        {
                            secondNumber = firstNumber;
                            countSecondNumber = countFirstNumber;
                            endSecondNumber = endFirstNumber;

                            firstNumber = findNumber;
                            countFirstNumber = countFindNumber;
                            endFirstNumber = i;
                        }
                        else if (countSecondNumber < countFindNumber)
                        {
                            secondNumber = findNumber;
                            countSecondNumber = countFindNumber;
                            endSecondNumber = i;
                        }

                        findNumber = arrayNumbers[i];
                        countFindNumber = 1;
                    }
                }
            }
            // Метод має шукати, а не роздруковувати.
            Console.WriteLine("First  high simple number " + firstNumber + " occurs " + countFirstNumber+ " Begin index "+(endFirstNumber- countFirstNumber) +" End index " + endFirstNumber);
            Console.WriteLine("Second high simple number " + secondNumber + " occurs " + countSecondNumber + " Begin index "+ (endSecondNumber - countSecondNumber) + " End index " + endSecondNumber);
        }

        public override string? ToString()
        {
            string result = "";
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                result += arrayNumbers[i].ToString() + " ";
            }
            return result;
        }
    }
}
