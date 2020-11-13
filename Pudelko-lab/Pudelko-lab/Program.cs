using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
           Pudelko p1 = new Pudelko(4,1,6);
           Pudelko p2 = new Pudelko(8,3,5);
           Console.WriteLine(p1+p2);
        }
    }
}
