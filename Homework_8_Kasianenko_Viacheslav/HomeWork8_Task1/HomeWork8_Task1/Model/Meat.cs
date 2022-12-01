using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork8_Task1.Enum;

namespace HomeWork8_Task1.Model
{

    public class Meat : Product
    {
        //Field
        private CategoriaMeat categoria;
        private SortMeat sort;

        //Property
        public CategoriaMeat Categoria
        {
            get
            {
                return categoria;
            }
            set
            {
                categoria = value;
            }
        }
        public SortMeat Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }
        //Constructor
        public Meat() : base()
        {
            Categoria = new CategoriaMeat();
            Sort = new SortMeat();
        }

        public Meat(string name, double price, double weight, Valute valuteCount, Unit massCount, CategoriaMeat categoria, SortMeat sort) : base(name, price, weight, valuteCount, massCount)
        {
            Categoria = categoria;
            Sort = sort;
        }
        //Override methods class Product


        //Method for change price on percentages.
        //For example ChangePrice(20) Price equele 20 becomes 2 because price=20* (20/100) 
        //                            and when categoria meat equels first, price *= 50/100
        public override void ChangePrice(int percentage)
        {
            base.ChangePrice(percentage);
            switch (categoria)
            {
                case CategoriaMeat.First:
                    Price *= (int)CategoriaMeat.First / 100;
                    break;
                case CategoriaMeat.Second:
                    Price *= (int)CategoriaMeat.Second / 100;
                    break;
                default:
                    throw new Exception("Error change price meat");
            }
        }
        //Override methods class Object
        public override string ToString()
        {
            return base.ToString() + " Категорія м'яса: " + Categoria.ToString() + " | Сорт м'яса: " + Sort.ToString() + "|";
        }

        public override bool Equals(object? obj)
        {
            bool equalsProduct = base.Equals(obj);
            if (!equalsProduct)
            {
                return false;
            }
            if (!(obj is Meat))
            {
                return false;
            }
            Meat p = (Meat)obj;
            return Categoria == p.Categoria && Sort == p.Sort;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Categoria.GetHashCode() ^ Sort.GetHashCode());
        }

        public override object Clone()
        {
            return new Meat(Name, Price, Weight, ValutePrice, UnitWeight, categoria, sort);
        }
    }
}
