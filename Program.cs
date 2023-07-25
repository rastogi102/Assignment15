using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAssignment15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);

            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);

                }

            }
            Swap(array, i + 1, right);
            return i + 1;
        }
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  "); // Changed WriteLine to Write to print on the same line.
            }
            Console.WriteLine("\n");
        }
        //public static int[] arrayip()
        //{
        //    Console.WriteLine("enter length of the array");
        //    int len;
        //    len = int.Parse(Console.ReadLine());
        //    int[] arr = new int[len];
        //    Console.WriteLine("enter array items");
        //    for (int i = 0; i < len; i++)
        //    {
        //        arr[i] = int.Parse(Console.ReadLine());

        //    }
        //    return arr;
        //}
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);

            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;

                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }
        public static bool checkSorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;

                }

            }
            return true;
        }
        static void Main(string[] args)
        {
            //int[] array= arrayip();
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("Original Array");
            Stopwatch sw = new Stopwatch();
            Print(array);
            sw.Start();


            QuickSort(array);
            sw.Stop();
            Print(array);
            bool check = checkSorted(array);
            if (check) { Console.WriteLine("Array is Sorted"); }
            else { Console.WriteLine("unsorted"); }
            Console.WriteLine("____________________");
            Console.WriteLine($"ArraySize of QuickSort {array.Length} & Time Taken {sw.Elapsed.TotalMilliseconds} millideconds");
            Console.WriteLine("____________________");



            int[] array1 = { 64, 34, 25, 12, 22, 11, 90 };

            Stopwatch sw1 = new Stopwatch();
            Console.WriteLine("Before Applying Merge Sort");
            Print(array1);
            sw1.Start();
            MergeSort(array1);
            sw1.Stop();
            Console.WriteLine("After Applying Merge Sort");
            Print(array1);

            
            Console.WriteLine($"ArraySize of Merge Sort {array1.Length} Time Taken {sw1.Elapsed.TotalMilliseconds} millideconds");
           
            Console.ReadKey();
            //ArraySize of QuickSort 7 & Time Taken 0.4045 millideconds
            //ArraySize of Merge Sort 7 Time Taken 0.5139 millideconds
        }
    }
}
