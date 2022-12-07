using HomeWork9_Task1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Test
{
    public class Generate : IGenerate
    {
        public List<string> GenerateList(uint howMuchLine, uint howMuchNumberInLine, int low, int high)
        {
            Random random = new Random();
            List<string> list = new List<string>();
            string stringValue;
            int countNumber;
            for (int i = 0; i <= howMuchLine; i++)
            {
                stringValue = "";
                countNumber = random.Next((int)howMuchNumberInLine -20, (int)howMuchNumberInLine);
                for (int j = 0; j <= random.Next((int)howMuchNumberInLine - 30, countNumber); j++)
                {
                    stringValue+= random.Next(low, high).ToString()+" ";
                }
                list.Add(stringValue);
            }
            return list;
        }
    }
}
