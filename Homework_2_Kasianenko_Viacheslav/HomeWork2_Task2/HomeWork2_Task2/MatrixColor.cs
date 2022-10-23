using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task2
{
    internal class MatrixColor
    {
        //Field
        private int[,] colorMatrix;
        private readonly int rangeLower = 0, rangeUpper = 16;

        //Constructor
        public MatrixColor(int numberRows,int numberCols)
        {
            this.colorMatrix = new int[numberRows,numberCols];
        }
        public MatrixColor(int[,] matrix)
        {
            this.colorMatrix = matrix;
        }
        //Method of class

        //Method fill matrix random number from "rangeLower" to "rangeUpper".
        public void RandomInitialization()
        {
            Random random = new Random();
            for (int i = 0; i < colorMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < colorMatrix.GetLength(1); j++)
                {
                    colorMatrix[i, j] = random.Next(rangeLower, rangeUpper);
                }
            }
        }
        public int searchLongLineColor(out int firstIndex, out int lastIndex, out int resultLength)
        {
            resultLength = 0;     //Return final length
            firstIndex = 0;       //Return final first index
            lastIndex = 0;        //Return final last index
            int longLineColor = 0;//Return color

            int firstIndexSearch = 0;
            int lastIndexSearch = 0;
            int resultLengthSearch = 0;
            int colorSearch = 0;
            for (int i = 0; i < colorMatrix.GetLength(0); i++)
            {
                firstIndexSearch = 0;
                lastIndexSearch = 0;
                resultLengthSearch = 1;
                colorSearch = colorMatrix[i, firstIndexSearch];
                for (int j = 1; j < colorMatrix.GetLength(1); j++)
                {
                    if (colorMatrix[i, j] == colorSearch)
                    {
                        resultLengthSearch++;
                    }
                    else
                    {
                        lastIndexSearch = j - 1;
                        if (resultLengthSearch > resultLength)
                        {
                            firstIndex = firstIndexSearch;
                            lastIndex = lastIndexSearch;
                            longLineColor = colorSearch;
                            resultLength = resultLengthSearch;
                        }
                        colorSearch = colorMatrix[i, j];
                        firstIndexSearch = j;
                        resultLengthSearch = 1;
                    }
                }
            }

            return longLineColor;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < colorMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < colorMatrix.GetLength(1); j++)
                {
                    if (colorMatrix[i, j] < 10) result += " " + colorMatrix[i, j] + " ";
                    else result += colorMatrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }

    }
}
