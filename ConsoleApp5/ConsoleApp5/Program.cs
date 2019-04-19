using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1, j = 1,k=1;
            for( i=1;i<=6;i++)
            {
                for (j = 1; j <= i; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
        }
    }
}
