using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Service
{
    public class OfferAction 
    {
        public void OnOfferWriteFileEvent(StreamWriter streamWriter, StringEventArgs[] content)
        {
            string row = content[0].ValueString;
            row += "\nСуміжні товари якими можливо замінити\n";
            for (int i = 1; i < content.Length; i++) 
                row+=content[i].ValueString+" | ";
            streamWriter.WriteLine(row+"\n");
        }
    }
}
