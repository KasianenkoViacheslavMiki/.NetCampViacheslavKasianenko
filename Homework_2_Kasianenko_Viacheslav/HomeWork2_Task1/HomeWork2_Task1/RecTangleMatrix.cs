using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_Task1
{
    internal class RecTangleMatrix
    {
        //Field
        private int numberRows;
        private int numberCols;
        private int[,] tangleMatrix;
        //Constructor
        public RecTangleMatrix(int numberRows, int numberCols)
        {
            this.NumberRows = numberRows;
            this.NumberCols = numberCols;
            tangleMatrix = new int[numberRows, numberCols];
        }
        //Property
        public int numberOfCells
        { 
            get
            {
                return NumberRows * NumberCols;
            }
        }
        private int NumberRows 
        {
            get => numberRows;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number rows must be not lower zero");
                }
                
                // потрібно перевиділяти пам'ять
                numberRows = value;
            } 
        }
        private int NumberCols 
        {
            get => numberCols;
            set
            {
                if (value < 0) 
                { 
                    throw new ArgumentOutOfRangeException("Number collums must be not lower zero"); 
                }
                // потрібно перевиділяти пам'ять
                numberCols = value;
            }
        }

        //Method of class

        //Method for fill the matrix in the form of a vertical snake. Both directions.
        //For example <name_matrix>.InitializationVerticalSnake(true);  //Fill the matrix in the form of a vertical snake. (From Left to Right) 
        //            <name_matrix>.InitializationVerticalSnake(false); //Fill the matrix in the form of a vertical snake. (From Right to Left)
        public void InitializationVerticalSnake(bool leftToRight)
        {
            tangleMatrix = new int[numberRows, numberCols];
            int k = 1;
            if (leftToRight)
            {
                //Fill the matrix in the form of a vertical snake. (From Left to Right)
                bool down = true;
                int i=0,j=0;
                while ((k-1)!=(this.numberOfCells))
                {//не оптимально!
                    tangleMatrix[i,j] = k;
                    k++;
                    if (down)
                    {
                        if (i == NumberRows - 1)
                        {
                            //Right shift
                            down = false;
                            j++;
                        }
                        else
                        {
                            //Down
                            i++;
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {
                            //Left shift
                            down = true;
                            j++;
                        }
                        else 
                        {
                            //Up
                            i--;
                        }
                    }
                }
            }
            else
            {
                //Fill the matrix in the form of a vertical snake. (From Right to Left)
                bool up = true;
                int i = NumberRows-1, j = NumberCols-1;
                while ((k - 1) != (this.numberOfCells))
                {
                    tangleMatrix[i, j] = k;
                    k++;
                    if (up)
                    {
                        if (i == 0)
                        {
                            //Left shift
                            up = false;
                            j--;
                        }
                        else
                        {
                            //Up
                            i--;
                        }
                    }
                    else
                    {
                        if (i == NumberRows - 1)
                        {
                            //Left shift
                            up = true;
                            j--;
                        }
                        else
                        {
                            //Down
                            i++;
                        }
                    }
                }
            }
        }

        //Method for fill the matrix in the form of a diagonal snake. Both directions.
        //For example <name_matrix>.InitializationDiagonalSnake(true);  //Fill the matrix in the form of a diagonal snake. (From Left to Right) 
        //            <name_matrix>.InitializationDiagonalSnake(false); //Fill the matrix in the form of a diagonal snake. (From Right to Left)
        public void InitializationDiagonalSnake(bool leftToRight)
        {
            tangleMatrix = new int[numberRows, numberCols];
            int k = 1;
            if (leftToRight)
            {
                //Fill the matrix in the form of a diagonal snake. (From Left to Right)
                bool up = true;
                int i = 0, j = 0;
                while ((k - 1) != (this.numberOfCells))
                {
                    tangleMatrix[i, j] = k;
                    k++;
                    if (up)
                    {
                        if ((j + 1) >= NumberCols)
                        {
                            //Down shift
                            up = false;
                            i++;
                        }
                        else if ((i - 1) < 0)
                        {
                            //Right shift
                            up = false;
                            j++;
                        }
                        else
                        {
                            //Up
                            i--;
                            j++;
                        }
                    }
                    else 
                    {
                       if ((i + 1) >= NumberRows)
                        {
                            //Right shift
                            up = true;
                            j++;
                        }
                        else if ((j - 1) < 0)
                        {
                            //Down shift
                            up = true;
                            i++;
                        }
                        else
                        {
                            //Down
                            i++;
                            j--;
                        }
                    }
                }
            }
            else
            {
                //Fill the matrix in the form of a diagonal snake. (From Right to Left)
                bool down = true;
                int i = NumberRows-1, j = NumberCols-1;
                while ((k - 1) != (this.numberOfCells))
                {
                    tangleMatrix[i, j] = k;
                    k++;
                    if (down)
                    {
                        if (i + 1 >= NumberRows&&j!=0)
                        {
                            down=false;
                            j--;
                        }
                        else if (j==0)
                        {
                            down = false;
                            i--;
                        }
                        else {
                            j--;
                            i++;
                        }
                    }
                    else
                    {
                        if (i==0)
                        {
                            down=true;
                            j--;
                        }
                        else if  (j + 1 >= NumberCols)
                        {
                            down = true;
                            i--;
                        }
                        else
                        {
                            i--;
                            j++;
                        }
                    }
                }
            }
        }

        //Method for fill the matrix in the form of a spiral snake. Both directions.
        //For example <name_matrix>.InitializationSpiralSnake();  //Fill the matrix in the form of a spiral snake. 
        public void InitializationSpiralSnake()
        {
            tangleMatrix = new int[numberRows, numberCols];
            int k = 1;
            //Fill the matrix in the form of a spiral snake. (From Out to In)
            bool verticalUp = false;
            bool verticalDown = true;
            bool horizontalRight = false;
            bool horizontalLeft = false;
            int i = 0, j = 0;
            while ((k - 1) != (this.numberOfCells))
            {
                tangleMatrix[i, j] = k;
                k++;
                if (verticalDown)
                {
                    if (i+1 < NumberRows&& tangleMatrix[i+1,j]==0)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                        verticalDown = false;
                        horizontalRight = true;
                    }
                 }
                else if (horizontalRight)
                {
                    if (j + 1 < NumberCols && tangleMatrix[i, j+1] == 0)
                    {
                        j++;
                    }
                    else
                    {
                        i--;
                        horizontalRight = false;
                        verticalUp = true;
                    }
                }
                else if (verticalUp)
                {
                    if (i - 1 >=0 && tangleMatrix[i-1, j] == 0)
                    {
                        i--;
                    }
                    else
                    {
                        j--;
                        verticalUp = false;
                        horizontalLeft = true;
                    }
                }
                else if (horizontalLeft)
                {
                    if (j - 1 >=0 && tangleMatrix[i, j-1] == 0)
                    {
                        j--;
                    }
                    else
                    {
                        i++;
                        horizontalLeft = false;
                        verticalDown = true;
                    }
                }
            }
        }
        public override string ToString()
        {
            string result = "";
            for (int i=0;i< NumberRows; i++) {
                for (int j = 0; j < NumberCols; j++)
                {// 10-чарівна константа Друк не оптимальний.
                    if (tangleMatrix[i, j]<10) result += " "+tangleMatrix[i, j] + " ";
                    else result += tangleMatrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
