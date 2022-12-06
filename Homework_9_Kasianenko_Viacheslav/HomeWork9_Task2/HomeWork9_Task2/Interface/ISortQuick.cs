using HomeWork9_Task2.Enum;
using HomeWork9_Task2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Interface
{
    public interface ISortQuick
    {
        public (int,int) Partition(ref Product[] array, int minPartitionList, int maxPartitionList);
    }
}
