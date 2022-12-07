using HomeWork9_Task2.Enum;
using HomeWork9_Task2.Model;
using HomeWork9_Task2.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Test
{
    public class TimeCount
    {
        public delegate void TimeCountDelegate(ref List<Product> products, SupportingElement supportingElement);
        TimeCountDelegate action;
        public ShuffleClass shuffleClass = new ShuffleClass();
        public void SetAction(TimeCountDelegate timeCountDelegate)
        {
            action = timeCountDelegate;
        }
        public void TestQuickSort(List<Product> products, SupportingElement supportingElement)
        {
            if (action == null) throw new Exception("Action is null");
            ShuffleClass.Shuffle(ref products);

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            try
            {
                action(ref products, SupportingElement.end);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sw.Stop();
            Console.WriteLine("Час сортування з опорним пунктом {0}: {1}", supportingElement== SupportingElement.begin?"з початку": supportingElement == SupportingElement.end ? "з кінця":"випадково", sw.Elapsed.TotalMilliseconds);
        }
    }
}
