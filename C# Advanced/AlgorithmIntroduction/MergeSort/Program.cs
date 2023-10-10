using System;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 14, 2, 8, 3};
            list = MergeSort(list);
            Console.WriteLine(string.Join(' ', list));
        }
        static List<int> MergeSort(List<int> list)
        {
            if(list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> leftArray = new();
            List<int> rightArray = new();

            for (int i = 0; i < list.Count; i++)
            {
                if(i < middle)
                {
                    leftArray.Add(list[i]);
                }
                else
                {
                    rightArray.Add(list[i]);
                }
            }

            List<int> sortedLeftArray = MergeSort(leftArray);
            List<int> sortedRightArray = MergeSort(rightArray);

            return Merge(sortedLeftArray, sortedRightArray);
        }
        static List<int> Merge(List<int> leftArray, List<int> rightArray)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            List<int> merged = new();
            for (int i = 0; i < leftArray.Count + rightArray.Count; i++)
            {
                if(leftIndex >= leftArray.Count)
                {
                    merged.Add(rightArray[rightIndex++]);
                    continue;
                }
                if (rightIndex >= rightArray.Count)
                {
                    merged.Add(leftArray[leftIndex++]);
                    continue;
                }

                if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    merged.Add(leftArray[leftIndex++]);
                }
                else
                {
                    merged.Add(rightArray[rightIndex++]);
                }
            }
            return merged;

        }
    }
}