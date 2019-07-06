using System;


namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputText;
            int[] RepeatedLettersCal = new int[26];
            Console.WriteLine("Enter the Text you want to calculate the upper case letter times of reapeat ");
            InputText = Console.ReadLine();

            for (int k = 0; k < InputText.Length; k++)
            {
                int UperCaseLetters = 65;
                for (int i = 0; i < 26; i++)
                {
                    if (InputText[k] == UperCaseLetters)
                    {
                        RepeatedLettersCal[i]++;
                    }
                    UperCaseLetters++;
                }
            }
            char c = 'A';
            foreach (int i in RepeatedLettersCal)
            {
                Console.WriteLine(c + "\t" + i);
                c++;
            }
            Console.ReadLine();
        }
    }
}
