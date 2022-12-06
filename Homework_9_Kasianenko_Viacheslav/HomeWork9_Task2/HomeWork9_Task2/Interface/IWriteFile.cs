using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Interface
{
    public interface IWriteFile
    {
        public void WriteFile(string path, string content, ref StreamReader writeStream);
    }
}
