using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_Task1.Service
{
    static class MergeSort
    {
        static private void ActionMerge(ref int[] arrNumber, int left, int mid, int right)
        {
            int lengthLeftArray = mid - left + 1;
            int lengthRightArray = right - mid;

            int[] leftArray = new int[lengthLeftArray];
            int[] rightArray = new int[lengthRightArray];

            Array.Copy(arrNumber, left, leftArray, 0, lengthLeftArray);
            Array.Copy(arrNumber, mid + 1, rightArray, 0, lengthRightArray);

            int k = left;
            int i = 0, j = 0;

            while (i < lengthLeftArray && j < lengthRightArray)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arrNumber[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arrNumber[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < lengthLeftArray)
            {
                arrNumber[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < lengthRightArray)
            {
                arrNumber[k] = rightArray[j];
                j++;
                k++;
            }
        }
        static private void MergeSortArr(ref int[] arrNumber, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right  - left) / 2;

                MergeSortArr(ref arrNumber, left, mid);
                MergeSortArr(ref arrNumber, mid + 1, right);

                ActionMerge(ref arrNumber, left, mid, right);
            }
        }
        static public void MergeSortFunc(ref int[] arrNumber)
        {
            try
            {
                MergeSortArr(ref arrNumber, 0, arrNumber.Length-1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error sort "+ ex.Message);
            }
        }
    }
}
