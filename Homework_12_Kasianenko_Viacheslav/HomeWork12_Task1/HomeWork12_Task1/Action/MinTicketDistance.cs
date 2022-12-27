using HomeWork12_Task1.Interface;
using HomeWork12_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12_Task1.Action
{
    public class MinTicketDistance : IMinTicketOffice
    {
        public TicketOffice Min(List<TicketOffice> listTicketOffice, (int,int) coordinate)
        {
            TicketOffice ticketOffice = listTicketOffice[0];
            double min = listTicketOffice[0].GetDistance(coordinate);

            for (int i = 1; i < listTicketOffice.Count; i++)
            {
                if (listTicketOffice[i].IsOpen)
                {
                    double tempValue = listTicketOffice[i].GetDistance(coordinate);
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
