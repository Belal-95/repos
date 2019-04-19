using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    struct point
    {
        public double x, y;
    }
   abstract class rec
    {
        //private double len;
        //private double wid;
        public double Len { get;set; }
        //{
        //    get
        //    {
        //        return len;
        //    }
        //    set
        //    {
        //        if (value > 0.0)
        //            len = value;
        //    }
        //}
        public double Wid { get; set; }
        //{
        //    get
        //    {
        //        return wid;
        //    }
        //    set
        //    {
        //        if (value > 0.0)
        //            wid = value;
        //    }

        //}
        public abstract double Getarea();
        //{
        //    //return Len * Wid;
        //}
    }
    class Program
    {
        static void Main(string[] args)
        {
            //rec rect = new rec {Len=10.0,Wid=20.0 };
            //rec rect2 = rect;
            //rect2.Len = 100;
            ////rect.Len = 10.0;
            ////rect.Wid = 20.0;
            //double res = rect.Getarea();
            //Console.WriteLine("rect.len = {0} \n area of rectangle : {1}",rect.Len, res);

            //point p1; /*= new point();*/
            //p1.x =10;
            //p1.y =20;
            //point p2 = p1;
            //p2.x = 100;

            //Console.WriteLine("p1.x= {0}", p1.x);
            Rectangle obj = new Rectangle(20, 30);
            Console.WriteLine("........ IS  "+obj.Getarea());
            Console.WriteLine("........ 2222 IS  " + obj.ToString());

        }

    }
    class Rectangle : rec
    {
        public Rectangle(double length, double width)
        {
            Len = length;
            Wid = width;
        }
        public override double Getarea()
        {
            return Wid * Len;
        }
        public override string ToString()
        {
            return String.Format("Width = {0}, Length = {1}", Wid, Len);
        }
    }
}
