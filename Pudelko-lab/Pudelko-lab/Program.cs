using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using PudelkoLib;

namespace Pudelko_lab
{
    class Program
    {
        static void Main()
        {
            Pudelko p1 = new Pudelko(4, 1, 6);
            Pudelko p2 = (3, 2, 1);
            Pudelko p3 = p1 + p2;

            Console.WriteLine(p2);

            List<Pudelko> pudelka = new List<Pudelko>
            {
                new Pudelko(),
                new Pudelko(2),
                new Pudelko(1,1,1),
                new Pudelko(573,332,9856, UnitOfMeasure.milimeter),
                new Pudelko(1.2, 23, UnitOfMeasure.centimeter)

            };

            Console.WriteLine("Nieposortowana lista");
            foreach (var p in pudelka)
            {
                Console.WriteLine(p);

            }

            Console.WriteLine("Posortowana lista");
            pudelka.Sort(ComparePudelka);
            foreach (var p in pudelka)
            {
                Console.WriteLine(p);

            }


        }

        public static int ComparePudelka(Pudelko p1, Pudelko p2)
        {
            if (p1.Objetosc == p2.Objetosc)
            {
                if (p1.Pole == p2.Pole)
                {

                    if ((p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C) != 0)
                        return -1;
                    else
                        return 1;
                }
                else
                {
                    if (p1.Pole < p2.Pole)
                        return -1;
                    else
                        return 1;
                }
            }
            else
            {
                if (p1.Objetosc < p2.Objetosc)
                    return -1;
                else
                    return 1;

            }
        }
    }


}
