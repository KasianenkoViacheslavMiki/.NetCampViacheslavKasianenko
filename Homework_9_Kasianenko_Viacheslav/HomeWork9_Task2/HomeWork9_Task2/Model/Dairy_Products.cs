using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork9_Task2.Enum;

namespace HomeWork9_Task2.Model
{
    public partial class Dairy_Products : Product
    {

        //Field
        private int termInDays;


        //Property
        public int TermInDays
        {
            get
            {
                return termInDays;
            }
            set
            {
                if (value < 0) throw new ArgumentException("Term in days not to have less than zero");
                else termInDays = value;
            }
        }
        //Constructor

        public Dairy_Products() : base()
        {
            termInDays = 0;
        }

        public Dairy_Products(string name, double price, double weight, Valute valuteCount, Unit massCount, int termInDays) : base(name, price, weight, valuteCount, massCount)
        {
            TermInDays = termInDays;
        }

        //Override methods class Product


        //Method for change price on percentages.
        //For example ChangePrice(20) Price equele 20 becomes 2,4 because price=20* (20/100) 
        //                            and when term in days small, price *= 60/100
        public override void ChangePrice(int percentage)
        {
            base.ChangePrice(percentage);
            if (termInDays > 0 && termInDays <= 10)
            {
                Price *= Price * ((int)PercentageTermInDays.smallTerm / 100);
            }
            else if (termInDays > 10 && termInDays <= 50)
            {
                Price *= Price * ((int)PercentageTermInDays.mediumTerm / 100);

            }
            else if (termInDays > 50)
            {
                Price *= Price * ((int)PercentageTermInDays.bigTerm / 100);
            }
        }
        //Override methods class Object
        public override string ToString()
        {
            return base.ToString() + " Днів зберігання: " + termInDays.ToString() + "|";
        }
        public override bool Equals(object? obj)
        {
            bool equalsProduct = base.Equals(obj);
            if (!equalsProduct)
            {
                return false;
            }
            if (!(obj is Dairy_Products))
            {
                return false;
            }
            Dairy_Products p = (Dairy_Products)obj;
            return termInDays == p.termInDays;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), termInDays.GetHashCode());
        }
        public override object Clone()
        {
            return new Dairy_Products(Name, Price, Weight, ValutePrice, UnitWeight, TermInDays);
        }
    }
}
