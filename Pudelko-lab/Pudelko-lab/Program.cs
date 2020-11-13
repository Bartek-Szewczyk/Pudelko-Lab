using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
           Pudelko p1 = new Pudelko(11.0,UnitOfMeasure.milimeter);
           Console.WriteLine(p1.ToString("mm"));
           Console.WriteLine(p1.Objetosc);
           Console.WriteLine(p1.Pole);
        }
    }
}
