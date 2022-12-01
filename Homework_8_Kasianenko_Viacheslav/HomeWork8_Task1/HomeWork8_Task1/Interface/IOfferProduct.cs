using HomeWork8_Task1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Interface
{
    public interface IOfferProduct
    {
        public event IOfferEvent.OfferHandler NotCanBeRealizationOffer;

        public string NameCorp
        { 
            get; 
            set; 
        }
        public string NameProduct
        {
            get;
            set;
        }
        public uint QuantityProduct
        {
            get;
            set;
        }
        public void InvokeEventNotCanBeRealizationOffer(string[] nameRelatedProduct,bool beginWriteFile);
    }
}
