using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                  WELCOM TO THE NUMBERS GAME \n");
            Console.WriteLine("=> the game and the rules are very simple. \n\n" +
                "=> first a number of 4 digits is being generated and the 4 digits are not duplicated numbers. \n\n" +
                "=> you should try to know the number by guessing. \n\n" +
                "=> you should write a number of 4 digits and the 4 digits should not be duplicated. \n\n" +
                "=> you should write numbers until you guess the number that generatd by the system. \n\n" +
                "=> you should try to know it by fewer tries. \n\n" +
                "=> the rule is that your number will be compared with the generated number \n\n" +
                "and give you the results as the following \n\n" +
                "=> the results of the comparasing will be like 'x' and 'o' or '----' .\n\n" +
                "=> x: means that there is one of your numbers is there in the generated number \n\n" +
                "and the number in the same location. \n\n" +
                "=> o: means that there is one of your numbers is there in the generated number \n\n" +
                "and the number is in different location. \n\n " +
                "=> ----: means that there is not any of your numbers are in the generated number. \n\n " +
                "=> for example: if your number was '1234' and the generated number was '1542' \n\n" +
                "you will get 'oox' \n\n" +
                "that means there are three digits of your number are exist in the generated number \n\n" +
                "and 1 digit in the same place as in the generated number and the other two are in differet places.\n\n" +
                "=> so you will keep trying until you will get 'xxxx' then that means that you know the number");
            
            vv: 
            int ch='k';
            Console.WriteLine("SO DO YOU WANT TO PLAY THIS GAME ? Y/N");
          //  while (ch != 'y' || ch != 'Y' || ch != 'n' || ch != 'N')
                try { ch = char.Parse(Console.ReadLine());
                if (ch != 'y' && ch != 'Y' && ch != 'n' && ch != 'N')
                    throw new Exception();
            }
                catch (Exception)
                {
                    Console.WriteLine("you should just write Y/N \n\n ");
                    goto vv;
                }
            if (ch == 'n' || ch == 'N')
                return;
            else 
            Console.Clear();
                



            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            if (name.Length==0)
                name = "NO NAME PERSON ";
                Console.Clear();

            vvvv:
            Console.WriteLine("                                     HELLO "+ name);







            int x1, x2, x3, x4, c = 0;
            int v1 = 0, v2 = 0, v3 = 0, v4 = 0, xx = 0, oo = 0;
          //  int DontDisplayXO = 0;

            //  Exception e = new Exception();
            //for (int i = 1; i < 10; i++)
            //{
            Random rnd = new Random();
            x1 = rnd.Next(10);
            x2 = rnd.Next(10);
            while (x2 == x1)
                x2 = rnd.Next(10);

            x3 = rnd.Next(10);
            while (x3 == x1 || x3 == x2)
                x3 = rnd.Next(10);

            x4 = rnd.Next(10);
            while (x4 == x1 || x4 == x2 || x4 == x3)
                x4 = rnd.Next(10);

            int[] x = new int[4];
            x[0] = x1;
            x[1] = x2;
            x[2] = x3;
            x[3] = x4;
         //   Console.WriteLine("x1= " + x1 + "\t   x2= " + x2 + "\tx3= " + x3 + "\t   x4= " + x4);








            //////////////////////////taking input///////////////////////////
            while (xx != 4)
            {
                xx = 0;
                oo = 0;
            //    DontDisplayXO = 0;
                Console.WriteLine("enter your number");
                string s = Console.ReadLine();
                

                //   string s1 = s.Split('1','1',StringSplitOptions.RemoveEmptyEntries);
                //       char c = '1';
                //int[] l = new[];
                try
                {
                    string s1 = string.Copy(s);
                    string g1 = s.Remove(1);
                    //    Console.WriteLine("\n ---------------------------\n" + g1);

                    v1 = Int32.Parse(g1);
                    //    Console.WriteLine("\n ---------------------------\n" + v1);
                    //if (v1 == x1)

                    //    Console.WriteLine("no 1 is matched");
                    string k2 = s.Remove(0, 1);
                    //  Console.WriteLine("k2 =" +k2);
                    string g2 = k2.Remove(1);
                    //    Console.WriteLine("\n ---------------------------\n" + g2);
                    v2 = Int32.Parse(g2);


                    string k3 = s.Remove(0, 2);
                    //  Console.WriteLine("k3 =" +k3);
                    string g3 = k3.Remove(1);
                    //   Console.WriteLine("\n ---------------------------\n" + g3);
                    v3 = Int32.Parse(g3);

                    int v5 = 0;

                    string k4 = s.Remove(0, 3);
                    if (k4.Length == 1)
                        v5 = Int32.Parse(k4);

                    else
                        throw new Exception();
                    //   Console.WriteLine("\n ---------------------------\n v5= " + v5);
                    //   Console.WriteLine("k4 =" +k4);
                    //   string g4 = k4.Remove(1);
                    //   Console.WriteLine("\n ---------------------------\n" + k4);
                    v4 = Int32.Parse(k4);







                }

                catch (FormatException)
                {
                    Console.WriteLine("you can write just numbers and it should be 4 digits and the numbers cannot be duplucated ");
                    goto belal;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.WriteLine(" you cannot write nothing pleas write a 4 digits number and numbers cannot be duplucated  ");
                    goto belal;
                }
                catch (Exception ex)
                {
                    //  Console.WriteLine ( ex);
                    Console.WriteLine("you can't write more than 4 digits numbers ");
                    goto belal;
                }


                int[] y = new int[4] { v1, v2, v3, v4 };
                bool b = false;
                for (int i = 0; i < 4; i++)
                {
                    if (b == true)
                        break;
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                            continue;
                        if (y[i] == y[j])
                        {

                            Console.WriteLine("the digits cannot be duplicated ");
                            goto belal;
                            b = true;
                            break;
                        }
                    }

                    //          throw new ExecutionEngineException();

                    //catch (ExecutionEngineException)
                    //{
                    //    Console.WriteLine("the digits cannot be duplicated ");

                    //}
                }


                ////s.CopyTo(2, null, 2, 3);
                //char[] k = new char[7]; /*{ 'k', 'l', 'm', 'n' };*/
                //s.CopyTo(0, k, 0, 3);
                //foreach (int ii in k)
                //Console.WriteLine("_________  " + k[ii]);

                //}


                ////////////////////////////comparasing//////////////////////////

                //  if (Console.ReadLine ()==g1)


                for (int i = 0; i < 4; i++)
                {
                    if (x[i] == y[i])
                        xx++;
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == j)
                            continue;
                        if (x[i] == y[j])
                            oo++;

                    }
                }

                //Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx=  " + xx
                //                   + "\nooooooooooooooooooooooooooooooooo=  " + oo);

                Console.Write("                             "+ s + "              |            ");
                for (int i = 0; i < oo; i++)
                    Console.Write("o");

                for (int i = 0; i < xx; i++)
                    Console.Write("x");

                if (xx == 0 && oo == 0)
                    Console.Write("----");

                Console.WriteLine();
                c++;



                belal:
                { }



            }

            Console.WriteLine("\nyou know the number by " + c + " tries thanks for your playing ^___^ \n");

            vvv:
            Console.WriteLine( "DO YOU WANT TO PLAY AGAIN? Y/N");
            ch = 'K';
            try
            {
                ch = char.Parse(Console.ReadLine());
                if (ch != 'y' && ch != 'Y' && ch != 'n' && ch != 'N')
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("you should just write Y/N \n\n ");
                goto vvv;
            }
            if (ch == 'n' || ch == 'N')
                return;
            else
                Console.Clear();
            goto vvvv;

        }
    }
}
