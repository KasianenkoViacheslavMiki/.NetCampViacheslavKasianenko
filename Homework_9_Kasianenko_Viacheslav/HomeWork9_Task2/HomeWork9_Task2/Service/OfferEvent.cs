using HomeWork9_Task2.Interface;
using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Service
{
    public class OfferEvent : IOfferEvent
    {
        public void OnOfferWriteFileEvent(object sender, StringEventArgs[] content)
        {
            if (sender is not IOfferProduct)
            {
                throw new InvalidDataException("Sender not be a offer");
            }
            bool beginWriteFile;
            if (!bool.TryParse(content[0].ValueString,out beginWriteFile))
            {
                throw new InvalidDataException("Not can be parse first args");
            }
            using (StreamWriter streamWriter = new StreamWriter(content[1].ValueString, !beginWriteFile))
            {
                string row = content[2].ValueString;
                row += "\nСуміжні товари якими можливо замінити\n";
                for (int i = 3; i < content.Length; i++) row+=content[i].ValueString+" | ";
                streamWriter.WriteLine(row+"\n");
            }
        }
    }
}
