using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17_Task1.Validators
{
    public interface IEmailValidator
    {
        public bool IsValid(string? email);
    }
}
