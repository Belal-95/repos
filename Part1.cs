using System;

public class Class1
{
    public Class1()
    {
        string[] InputText;
        int[] RepeatedLettersCal = new int[26];
        System.WriteLine("Enter the Text you want to calculate the upper case letter times of reapeat ");
        InputText = System.ReadLine();

        foreach (char c in InputText)
        {
            int UperCaseLetters = 65;
            for (int i = 0; i < 26; i++)
            {
                if (UperCaseLetters == RepeatedLettersCal[i])
                    RepeatedLettersCal[i]++;
                UperCaseLetters++;
            }
        }
        char c = 'A';
        foreach (char i in RepeatedLettersCal)
        {
            System.WriteLine(c + "\t" + i);
        }

    }
}
