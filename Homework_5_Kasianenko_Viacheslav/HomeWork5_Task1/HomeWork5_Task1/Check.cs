using HomeWork5_Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3_Task1
{
    static public class Check
    {
        public static void Print(Cart cart)
        {
            Console.WriteLine("-------------------------------------------------------------Check-------------------------------------------------------------");
            Console.WriteLine(cart);
            Console.WriteLine("Payeble: "+cart.GetCartPrice().ToString("0.00")+"|-------------------------------------------------------------------------------------------------------");

        }
        public static void Print(Storage product)
        {
            Console.WriteLine("-----------------------------------------------------------Storage----------------------------------------------------------------");

            Console.WriteLine(product.ToString());
        }
    }
}
