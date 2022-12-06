using HomeWork9_Task2.Enum;
using HomeWork9_Task2.Interface;
using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Service
{
    public class ClassSortProduct 
    {
        static readonly private Dictionary<SupportingElement, ISortQuick> _sort = new Dictionary<SupportingElement, ISortQuick>
        {
            { SupportingElement.begin,new PartitionBegin()},
            { SupportingElement.end,new PartitionEnd() },
            { SupportingElement.random,new PartitionRandom() }
        };
        static private void QuickSort(ref Product[] products, int minPartitionList, int maxPartitionList, SupportingElement supportingElement)
        {
            if (maxPartitionList <= minPartitionList) return;
            ISortQuick partition = _sort[supportingElement];
            (int,int) i = partition.Partition(ref products, minPartitionList, maxPartitionList);
            QuickSort(ref products, minPartitionList, i.Item1, supportingElement);
            QuickSort(ref products, i.Item2, maxPartitionList, supportingElement);
        }
        static public void SortProduct(ref List<Product> products, SupportingElement supportingElement)
        {
            Product[] arrayProduct = products.ToArray();
            QuickSort(ref arrayProduct, 0, arrayProduct.Length-1, supportingElement);
            products = arrayProduct.ToList();
        }
    }
}
