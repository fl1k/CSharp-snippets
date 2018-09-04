using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[0];
            while (Int32.TryParse(Console.ReadLine(), out int input))
            {
                insertIntoSortedArray(input, ref array);
                Console.Clear();
                foreach (int num in array)
                {
                    Console.WriteLine(num);
                }
            }
        }

        static void insertIntoSortedArray(int num, ref int[] array)
        {
            int n = array.Length;
            bool sortAdded = false;
            Array.Resize(ref array, n + 1);
            for (int i = n - 1; i >= 0; i--)
            {
                if (num >= array[i])
                {
                    for (int j = n; j > i; j--)
                    {
                        array[j] = array[j - 1];
                    }
                    array[i + 1] = num;
                    sortAdded = true;
                    break;
                }
            }
            if (!sortAdded)
            {
                for (int i = n; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = num;
            }
        }
    }
}
