﻿using System;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
           Pudelko p1 = new Pudelko(4,1,6);
           Pudelko p2 = (3,2,1);
           Pudelko p3 = p1 +p2;
           Console.WriteLine(p2);
        }
    }
}
