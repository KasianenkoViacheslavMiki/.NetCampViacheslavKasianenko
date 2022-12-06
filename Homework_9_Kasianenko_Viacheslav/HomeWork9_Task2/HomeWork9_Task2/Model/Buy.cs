using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Model
{
    public class Buy : ICloneable
    {
        //Field
        private int quantity;
        private Product product;
        //Constructor
        public Buy()
        {
            quantity = 0;
            product = new Product();
        }
        public Buy(int quantity, Product product)
        {
            Quantity = quantity;
            Product = (Product)product.Clone();
        }
        //Property
        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity not to have less than zero");
                }
                else quantity = value;
            }
        }
        public void AddQuantity(int addQuantity)
        {
            Quantity += addQuantity;
        }
        public void SubtractQuantity(int substractQuantity)
        {
            Quantity -= substractQuantity;
        }
        public double GetTotalPrice()
        {
            return Quantity * Product.Price;
        }
        public double GetTotalWeight()
        {
            return Quantity * Product.Weight;
        }
        public Product Product
        {
            get
            {
                return (Product)product.Clone();
            }
            set
            {
                product = (Product)(value as Product).Clone();
            }
        }

        public override string ToString()
        {
            string result = product.ToString() + " Кількість: " + Quantity + "| Обща вага: " + GetTotalWeight().ToString("0.00") + "| Ціна за товар: " + GetTotalPrice().ToString("0.00") + "|";
            return result;
        }

        public object Clone()
        {
            return new Buy(Quantity, Product);
        }
    }
}
