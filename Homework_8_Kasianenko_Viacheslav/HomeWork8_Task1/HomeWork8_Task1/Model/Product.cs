using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork8_Task1.Enum;

namespace HomeWork8_Task1.Model
{
    public class Product : IComparable<Product>, ICloneable, IComparable
    {
        //Field
        private string name;
        private double price;
        private double weight;
        private Valute valutePrice;
        private Unit unitWeight;
        //Constructor
        public Product()
        {
            name = "Null";
            price = 0;
            weight = 0;
        }

        public Product(string name, double price, double weight, Valute valutePrice, Unit unitWeight)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ValutePrice = valutePrice;
            UnitWeight = unitWeight;
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

        public Valute ValutePrice { get => valutePrice; set => valutePrice = value; }
        public Unit UnitWeight { get => unitWeight; set => unitWeight = value; }

        //Method

        //Method for change price on percentages.
        //For example ChangePrice(20) Price equele 20 becomes 4 because price= 20*= (20/100)
        public virtual void ChangePrice(int percentage)
        {
            if (percentage < 1)
            {
                price *= percentage / 100;
            }
            else
            {
                throw new ArgumentException("Percentage not to have less then 1");
            }
        }

        public Product ChangeValute(Valute valute)
        {
            if (valute == ValutePrice)
            {
                return (Product)Clone();
            }
            if (Valute.dollar == ValutePrice)
            {
                if (valute == Valute.euro)
                {
                    ValutePrice = Valute.euro;
                    Price = Price * ValuteConst.dollarInEuro;
                }
                else if (valute == Valute.grivna)
                {
                    ValutePrice = Valute.grivna;
                    Price = Price * ValuteConst.dollarInGrn;
                }
            }
            if (Valute.euro == ValutePrice)
            {
                if (valute == Valute.dollar)
                {
                    ValutePrice = Valute.dollar;
                    Price = Price * ValuteConst.euroInDollar;
                }
                else if (valute == Valute.grivna)
                {
                    ValutePrice = Valute.grivna;
                    Price = Price * ValuteConst.euroInGrn;
                }
            }
            if (Valute.grivna == ValutePrice)
            {
                if (valute == Valute.dollar)
                {
                    ValutePrice = Valute.dollar;
                    Price = Price * ValuteConst.grnInDollar;
                }
                else if (valute == Valute.euro)
                {
                    ValutePrice = Valute.euro;
                    Price = Price * ValuteConst.grnInEuro;
                }
            }
            return (Product)Clone();
        }

        //Override methods class Object
        public override string ToString()
        {
            return "|Назва: " + Name + "| Ціна: " + Price.ToString("0.00") + " " + ValutePrice.ToString() + "| Вага: " + Weight.ToString("0.00") + " " + UnitWeight.ToString() + "|";
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Product)) return false;

            Product p = (Product)obj;
            return Name == p.Name && Price == p.Price && Weight == p.Weight;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name.GetHashCode(), Price.GetHashCode(), Weight.GetHashCode());
        }
        //Implementation method for class Product and all child classes.

        public int CompareTo(object? obj)
        {
            if (obj is Product product)
            {
                //return product.Name.CompareTo(Name);
                if (product.Name != Name)
                {
                    int len = product.Name.Length > Name.Length ? product.Name.Length : Name.Length;
                    for (int i = 0; i < len; i++)
                    {
                        if (product.Name[i] < Name[i])
                        {
                            return -1;
                        }
                        else if (product.Name[i] > Name[i])
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
        virtual public object Clone()
        {
            return new Product(Name, Price, Weight, ValutePrice, UnitWeight);
        }

        public int CompareTo(Product? other)
        {
            _ = other ?? throw new ArgumentException("Null");

            return name.CompareTo(other.name);
        }
        public class SortByName : IComparer<Product>
        {
            public int Compare(Product? x, Product? y)
            {
                if (x.Price == y.Price)
                    return 0;
                else if (x.Price > y.Price)
                    return 1;
                else
                    return -1;
            }
        }
    }
}
