using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Interface
{
    public interface IOfferEvent
    {
        public delegate void OfferHandler(object sender, StringEventArgs[] content);

        public void OnOfferWriteFileEvent(object sender, StringEventArgs[] content);
    }
}
