using HomeWork9_Task1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Service
{
    public class Parse : IParseStrArrToIntArr
    {
        public int[] ParseStringArrayToIntArray(string[] array)
        {
            List<int> result=new List<int>();
            int parseValue;
            foreach (var item in array)
            {
                if (!Int32.TryParse(item, out parseValue)) throw new Exception("String " + item + " not parse to int");
                result.Add(parseValue);
            }
            return result.ToArray();
        }
    }
}
