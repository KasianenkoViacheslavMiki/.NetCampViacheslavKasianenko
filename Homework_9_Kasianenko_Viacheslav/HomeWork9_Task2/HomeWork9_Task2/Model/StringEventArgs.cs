using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Model
{
    public class StringEventArgs : EventArgs
    {
        private string valueString;
        public StringEventArgs(string _valueString)
        {
            valueString = _valueString;
        }
        public string ValueString
        {
            get { return valueString; }
            set { valueString = value; }
        } 
    }
}
