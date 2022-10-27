using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    public class Check
    {
        public void Print(Buy buy)
        {
            Console.WriteLine(buy.ToString());
        }
        public void Print(Product product)
        {
            Console.WriteLine(product.ToString());
        }
        public void Print(Meat product)
        {
            Console.WriteLine(product.ToString());
        }
        public void Print(Dairy_Products product)
        {
            Console.WriteLine(product.ToString());
        }
        public void Print(Storage product)
        {
            Console.WriteLine(product.ToString());
        }
    }
}
