using System;
using System.Collections.Generic;
using System.Text;
using PudelkoLib;

namespace Pudelko_lab
{
    public static class PudelkoKompresuj
    {
        public static Pudelko Kompresuj(this Pudelko p)
        {

            double a = Math.Cbrt(p.Objetosc);
            return new Pudelko(a,a,a);
        }
    }
}
