using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
           Pudelko p1 = new Pudelko(8491, 5624, 7539, UnitOfMeasure.milimeter);
           Console.WriteLine(p1.ToString("m"));
           Console.WriteLine(p1.Objetosc);
           Console.WriteLine(p1.Pole);
        }
    }
}
