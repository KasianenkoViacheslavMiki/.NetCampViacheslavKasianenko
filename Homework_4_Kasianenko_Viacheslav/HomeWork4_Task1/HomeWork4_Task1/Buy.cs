using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Buy
    {
        //Field
        private int quantity;
        private Product product;
        //Constructor
        public Buy()
        {
            this.quantity = 0;
            this.product = new Product();
        }
        public Buy(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }
        //Property
        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity < 0)
                {
                    throw new ArgumentException("Quantity not to have less than zero");
                }
                else quantity = value;
            }
        }

        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
            }
        }
        //Method of class
        public double CalculationTotalPrice()
        {
            return Quantity * Product.Price;
        }
        public double CalculationTotalWeight()
        {
            return Quantity * Product.Weight;
        }
        public override string ToString()
        {
            return base.ToString() + ": |Name: " + Product.Name + "| Unit Price: " + Product.Price + "| Unit Weight: " + Product.Weight + "| Quantity: " + Quantity + "| Total Weight: " + CalculationTotalWeight().ToString("0.00") + "| Total Price: " + CalculationTotalPrice() + "|";
        }

    }
}
