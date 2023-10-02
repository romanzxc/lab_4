using System;

namespace Laba4_V_6
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a1 = new ComplexNumber(9.32, 2.4 );
            ComplexNumber a2 = new ComplexNumber(-45, -0.44);
            ComplexNumber a3 = new ComplexNumber(0.007, 0);

            Console.WriteLine("a1= " + a1);
            Console.WriteLine("a2= " + a2);
            Console.WriteLine("a3= " + a3);
            ComplexNumber x = a2.Pow(4)+  ( a1 - a2) / (a3* a1);
            Console.WriteLine("x=a2^4 + ( a1 - a2) / (a3* a1)");
            Console.WriteLine("x: " + x);
            Console.WriteLine("Модуль x="+x.Module());

        }
    }
}
