using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Validators
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string? email)
        {
            if (null == email)
            {
                return false;
            }
            if (!new Regex("^\\S+@\\S+\\.\\S+$").IsMatch(email))
            {
                return false;
            }
            return true;
        }
    }
}
