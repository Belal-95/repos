using System;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText;
            int[] RepeatedLettersCal = new int[26];
            Console.WriteLine("Enter the Text you want to calculate the upper case letter times of reapeat ");
            inputText = Console.ReadLine();


            for (int k = 0; k < inputText.Length; k++)
            {
                char ch = toUpper(inputText[k]);

                int uperCaseLetters = 65;
                for (int i = 0; i < 26; i++)
                {
                    if (ch == uperCaseLetters)
                    {
                        RepeatedLettersCal[i]++;
                    }
                    uperCaseLetters++;
                }
            }
            char c = 'A';
            foreach (int i in RepeatedLettersCal)
            {
                Console.WriteLine(c + "\t" + i);
                c++;
            }
            int maxFreq = max(RepeatedLettersCal);
            Console.Write("Max frequency=" + maxFreq + "\nletters are: ");

            int count = 0; // for counting how many times it enters to the if so we won't print ',' the first time
            for (int i= 0;i< RepeatedLettersCal.Length;i ++)
            {
                if (RepeatedLettersCal[i] == maxFreq)
                {
                    if (count != 0)
                    {
                        Console.Write(",");
                    }
                    char ch = (char)(i + 65);
                    Console.Write(ch);
                    count++;

                }

            }
            // for printing "only" word in case there was only one char the max frequency
            if (count == 1) 
            {
                Console.Write(" only");
            }

            Console.ReadLine();

        }

        static char toUpper(char c)
        {
            int uperCaseLetters = 97;
            for (int i = 0; i < 26; i++)
            {
                if (c == uperCaseLetters)
                {
                    c = (Char)(c - 32);
                }
                uperCaseLetters++;
            }
            return c;
        }

        static int max(int[] ar)
        {
            int maxVal = ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (ar[i] > maxVal)
                    maxVal = ar[i];
            }
            return maxVal;
        }
    }
}
