using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Service
{
    static public class Check
    {
        public static void Print(Cart cart)
        {
            Console.WriteLine("-------------------------------------------------------------Check-------------------------------------------------------------");
            Console.WriteLine(cart);
            Console.WriteLine("До сплати: " + cart.GetCartPrice().ToString("0.00") + "|-------------------------------------------------------------------------------------------------------");

        }
        public static void Print(Storage product)
        {
            Console.WriteLine("-----------------------------------------------------------Storage----------------------------------------------------------------");

            Console.WriteLine(product.ToString());
        }
    }
}
