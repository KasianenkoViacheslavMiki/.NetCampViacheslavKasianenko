using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Validators
{
    public class MobileValidator : IMobileValidator
    {
        public bool IsValid(string? mobile)
        {
            if (mobile == null)
            {
                return false;
            }
            if (!new Regex("^0?\\d{8}$").IsMatch(mobile))
            {
                return false;
            }
            return true;
        }
    }
}
