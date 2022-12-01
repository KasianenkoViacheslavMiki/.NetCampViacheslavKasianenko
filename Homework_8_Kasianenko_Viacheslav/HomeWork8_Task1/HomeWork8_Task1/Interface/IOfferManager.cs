using HomeWork8_Task1.Model;
using HomeWork8_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Interface
{
    public interface IOfferManager
    {
        public IList<IOfferProduct> OfferProduct { get; set; }
        public IDictionary<string, string[]> NameReletedProduct { get; set; }

        public void AddEventOffer(IOfferEvent.OfferHandler any);
        public void RemoveEventOffer(IOfferEvent.OfferHandler any);

        public void InitialisationOfferManager();
        public void RealizationOffer(Storage storage);
    }
}
