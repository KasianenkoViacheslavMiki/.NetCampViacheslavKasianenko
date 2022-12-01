using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Model
{
    public class OffersProduct : IOfferProduct
    {
        public event IOfferEvent.OfferHandler NotCanBeRealizationOffer;
        private string nameCorp;
        private string nameProduct;
        private uint quantityProduct;

        public OffersProduct()
        {
            NameCorp = null;
            NameProduct = null;
            QuantityProduct = 0;
        }
        public OffersProduct(string nameCorp, string nameProduct, uint countProduct)
        {
            NameCorp = nameCorp;
            NameProduct = nameProduct;
            QuantityProduct = countProduct;
        }

        public string NameCorp 
        {
            get 
            {
                return nameCorp;
            }
            set
            {
                nameCorp=value;
            }
        }
        public string NameProduct
        {
            get
            {
                return nameProduct;
            }
            set
            {
                nameProduct = value;
            }
        }
        public uint QuantityProduct
        {
            get
            {
                return quantityProduct;
            }
            set
            {
                quantityProduct = value;
            }
        }
        public void InvokeEventNotCanBeRealizationOffer(string[] nameRelatedProduct, bool beginWriteText)
        {
            List<StringEventArgs> stringEventArgs = new List<StringEventArgs>();
            stringEventArgs.Add(new StringEventArgs(beginWriteText.ToString()));
            stringEventArgs.Add(new StringEventArgs("result.txt"));
            stringEventArgs.Add(new StringEventArgs(this.ToString()));  
            foreach (string name in nameRelatedProduct) stringEventArgs.Add(new StringEventArgs(name));
            NotCanBeRealizationOffer?.Invoke(this, stringEventArgs.ToArray());
        }

        public override string? ToString()
        {
            return "|Фірма заказчик: \"" + NameCorp + "\"| Назва товару: " + NameProduct + "| Потрібна кількість: " + QuantityProduct;
        }
    }
}
