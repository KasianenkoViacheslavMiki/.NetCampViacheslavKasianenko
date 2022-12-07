using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Interface
{
    public interface IGenerate
    {
        public List<string> GenerateList(uint howMuchLine, uint howMuchNumberInLine,int low, int high);
    }
}
