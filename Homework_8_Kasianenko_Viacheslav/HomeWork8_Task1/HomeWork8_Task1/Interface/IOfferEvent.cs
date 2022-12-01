using HomeWork8_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Interface
{
    public interface IOfferEvent
    {
        public delegate void OfferHandler(object sender, StringEventArgs[] content);

        public void OnOfferWriteFileEvent(object sender, StringEventArgs[] content);
    }
}
