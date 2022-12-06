using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Interface
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
