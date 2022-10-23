using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithClasses
{
    internal class Check
    {
        //Method of class
        public void Print(Buy buy)
        {
            Console.WriteLine(buy.ToString());
        }
        public void Print(Product product)
        {
            Console.WriteLine(product.ToString());
        }
    }
}
