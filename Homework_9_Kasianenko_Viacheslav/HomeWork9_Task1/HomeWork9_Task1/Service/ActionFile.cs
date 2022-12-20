using HomeWork9_Task1.Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Service
{
    static public class ActionFile 
    {
        static public void DeleteFile(List<string> paths)
        {
            foreach (string path in paths)
                File.Delete(path);
        }
        static public void WriteFile(string path, string[] strings)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string stringLine in strings) sw.WriteLine(stringLine);
                sw.Close();
            }
        }
        static public void WriteFile(string path, string stringLine)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(stringLine);
                sw.Close();
            }
            
        }
        static public void ArrayToFile(int[] data, string fileName)
        {
            string stringValue="";
            foreach (int i in data)
            {
                stringValue += i.ToString()+" ";
            }
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(stringValue);
                sw.Close();
            }
        }
        
    }
}
