using HomeWork12_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Action
{
    public class MinCount : IMinTicketOffice
    {
        public TicketOffice Min(List<TicketOffice> listTicketOffice, (int, int) coordinate)
        {
            TicketOffice ticketOffice = listTicketOffice[0];
            int min = listTicketOffice[0].Count;

            for (int i = 1; i < listTicketOffice.Count; i++)
            {
                if (listTicketOffice[i].IsOpen)
                {
                    int tempValue =  listTicketOffice[i].Count;
                    if (tempValue < min)
                    {
                        ticketOffice = listTicketOffice[i];
                        min = tempValue;
                    }
                }
            }
            return ticketOffice;
        }
    }
}
