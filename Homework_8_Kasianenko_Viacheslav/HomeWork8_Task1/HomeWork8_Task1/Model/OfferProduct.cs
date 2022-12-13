using HomeWork8_Task1.Interface;
using HomeWork8_Task1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8_Task1.Model
{
    public class OfferProduct
    {
        private string nameCorp;
        private string nameProduct;
        private uint quantityProduct;

        public OfferProduct()
        {
            NameCorp = null;
            NameProduct = null;
            QuantityProduct = 0;
        }
        public OfferProduct(string nameCorp, string nameProduct, uint countProduct)
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

        public override string? ToString()
        {
            return "|Фірма заказчик: \"" + NameCorp + "\"| Назва товару: " + NameProduct + "| Потрібна кількість: " + QuantityProduct;
        }
    }
}
