using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
           Pudelko p1 = new Pudelko(10,4,8, UnitOfMeasure.centimeter);
           Console.WriteLine(p1.ToString());
        }
    }
}
