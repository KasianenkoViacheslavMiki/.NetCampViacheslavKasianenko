using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Product: IComparable, IComparer
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
        //Implementation method for class Product and all child classes.

        public int CompareTo(object? obj)
        {
            if (obj is Product product)
            {
                //return product.Name.CompareTo(Name);
                if (product.Name != this.Name)
                {
                    int len = product.Name.Length>this.Name.Length? product.Name.Length: this.Name.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (product.Name[i] < this.Name[i])
                        {
                            return -1;
                        }
                        else if (product.Name[i] > this.Name[i])
                        {
                            return 1;
                        }
                    }
                }
                else return 0;
            }
            else
            {
                throw new ArgumentException("Object not it Product");
            }
            return 0;
        }

        public int Compare(object? x, object? y)
        {
            if (x is Product obj1 && y is Product obj2)
            {
                if (obj1.Price == obj2.Price)
                    return 0;
                else if (obj1.Price > obj2.Price)
                    return 1;
                else 
                    return -1;
            }
            throw new ArgumentException("Object not it Product");
        }
    }
}
