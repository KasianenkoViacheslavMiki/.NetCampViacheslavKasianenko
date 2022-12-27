using HomeWork12_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Interface
{
    public interface IMinTicketOffice
    {
        public TicketOffice Min(List<TicketOffice> listTicketOffice, (int, int) coordinate);
    }
}
