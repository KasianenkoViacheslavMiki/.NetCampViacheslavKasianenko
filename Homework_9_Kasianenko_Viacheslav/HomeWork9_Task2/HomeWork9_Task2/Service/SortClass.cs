using HomeWork9_Task2.Enum;
using HomeWork9_Task2.Interface;
using HomeWork9_Task2.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task2.Service
{
    public class ActionSort
    {
        static public void Swap(ref Product product1, ref Product product2)
        {
            Product temp = product1;
            product1 = product2;
            product2 = temp;
        }
    }
    public class PartitionBegin : ActionSort, ISortQuick
    {
        public (int,int) Partition(ref Product[] array, int minPartitionList, int maxPartitionList)
        {
            Product pivot = array[minPartitionList];
            int i = minPartitionList - 1, j = maxPartitionList + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);
                do
                {
                    j--;
                } while (array[j] > pivot);
                if (i >= j)
                    return (j,j+1);
                Swap(ref array[i], ref array[j]);
            }
        }
    }
    public class PartitionEnd : ActionSort, ISortQuick
    {
        public (int,int) Partition(ref Product[] array, int minPartitionList, int maxPartitionList)
        {
            Product pivot = array[maxPartitionList];
            int i = minPartitionList-1;
            for (int j = minPartitionList; j <= maxPartitionList-1; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            Swap(ref array[i+1], ref array[maxPartitionList]);
            int result = i + 1;
            return (result - 1, result + 1);
        }
    }
    public class PartitionRandom : ActionSort, ISortQuick
    {
        private (int, int) Partition_R(ref Product[] array, int minPartitionList, int maxPartitionList)
        {
            Product pivot = array[minPartitionList];
            int i = minPartitionList - 1, j = maxPartitionList + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (array[i] < pivot);
                do
                {
                    j--;
                } while (array[j] > pivot);
                if (i >= j)
                    return (j, j + 1);
                Swap(ref array[i], ref array[j]);
            }
        }

        public ( int,int) Partition(ref Product[] array, int minPartitionList, int maxPartitionList)
        {
            Random random = new Random();
            int random_value = random.Next(minPartitionList, maxPartitionList);
            Swap(ref array[random_value], ref array[minPartitionList]);
            return Partition_R(ref array, minPartitionList, maxPartitionList);
        }
    }
}
