using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithClasses
{
    internal class Product
    {
        //Field
        private string name;
        private double price;
        private double weight;
        //Constructor
        public Product()
        {
            name = "Null";
            price = 0;
            weight = 0;
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        //Property
        public string Name 
        {
            get 
            { 
                return name;
            }
            set { 
                name = value;
            }
        }

        public double Price
        {
            get 
            { 
                return price; 
            }
            set 
            {
                if (value < 0) throw new ArgumentException("Price not to have less than zero");
                else price = value;
            }
        }

        public double Weight
        {
            get 
            { 
                return weight; 
            }
            set 
            {
                if (value < 0) throw new ArgumentException("Weight not to have less than zero");
                else weight = value;
            }
        }
        //Method of class
        public override string ToString()
        {
            return base.ToString()+": |Name: "+Name+"| Price: "+Price+"| Weight: "+  Weight+"|";
        }

    }
}
