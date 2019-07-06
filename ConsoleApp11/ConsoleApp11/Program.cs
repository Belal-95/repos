using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[10];
            //for(int i=0;i <arr.Length ;i++)
            //{
            //    Console.WriteLine($"Please Insert number {i + 1} \n then click enter");
            //    arr[i] = Convert.ToInt32( Console.ReadLine());
            //}

            //Console.WriteLine("Inserting the Array completed ");

            //Console.WriteLine("Checking the Array numbers ");

            //bool IsLessthan10 = true;
            //foreach (int number in arr)
            //{
            //    if (number < 10)
            //        continue;
            //    Console.WriteLine("Not All the numbers less than 10");
            //    IsLessthan10 = false;
            //    break;
            //}
            //if (IsLessthan10)
            //    Console.WriteLine("All the numbers of the array less than 10 ");

            //Console.WriteLine("Showing the array vertically ");

            //foreach (int number in arr)
            //{
            //    Console.WriteLine(number);
            //}

            //Console.WriteLine("Showing the array Horizontally ");

            //foreach (int number in arr)
            //{
            //    Console.Write(number+"\t");
            //}

            int k = 1;
            Console.WriteLine(k);
            k++;
            Console.WriteLine(k);
            Console.WriteLine(k++);
            Console.WriteLine(++k);
            Console.WriteLine(k);
            int y = ++k;
            Console.WriteLine(y);
            y = k++;
            Console.WriteLine(y);
            Console.WriteLine(k);
        }
    }
}
