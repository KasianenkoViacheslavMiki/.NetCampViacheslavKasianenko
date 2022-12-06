using HomeWork9_Task2.Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Service
{
    public class ActionFile : IReadFile
    {
        public string[] ReadFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(path + " not found");
            List<string> strings = new List<string>();
            using (StreamReader readOnlyStream = File.OpenText(path))
            {
                string input;
                while ((input = readOnlyStream.ReadLine()) != null) strings.Add(input);
            }
            return strings.ToArray();
        }
    }
}
