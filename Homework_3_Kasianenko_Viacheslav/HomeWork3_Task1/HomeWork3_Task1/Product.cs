using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Product
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
            set
            {
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
        //Method

        //Method for change price on percentages.
        //For example ChangePrice(20) Price equele 20 becomes 4 because price= 20*= (20/100)
        public virtual void ChangePrice(int percentage)
        {
            if ((percentage < 0) || (percentage >= 100))
            {
                this.price *= (percentage / 100);
            }
            else
            {
                throw new ArgumentException("Percentage not to have less then zero or more than 100");
            }
        }
        //Override methods class Object
        public override string ToString()
        {
            return "|Name: " + Name + "| Price: " + Price + "| Weight: " + Weight + "|";
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Product)) return false;

            Product p = (Product)obj;
            return Name == p.Name && Price == p.Price && Weight == p.Weight;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Price.GetHashCode() ^ Weight.GetHashCode();
        }
    }
}
