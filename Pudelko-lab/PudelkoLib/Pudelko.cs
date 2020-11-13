using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        public readonly double _a = 0.1;
        public readonly double _b = 0.1;
        public readonly double _c = 0.1;
        public readonly UnitOfMeasure _unit;

        public double A
        {
            get => _a;
        }


        public double B
        {
            get => _b;
        }
        public double C
        {
            get => _c;
        }
        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            _a = a;
            _b = b;
            _c = c;
            _unit = unit;
            CheckRange(a, b, c);
        }
        public Pudelko()
        {
            _unit = UnitOfMeasure.centimeter;
        }

        public void CheckRange(double a, double b, double c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (a > 10 || b > 10 || c > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }
        public override string ToString()
        {
            return this.ToString("m", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {

            switch (format.ToUpperInvariant())
            {
                case "M":
                    return $"{A.ToString("F3", formatProvider)}{format}\u00D7 {B.ToString("F3", formatProvider)}{format} \u00D7 {C.ToString("F3", formatProvider)}{format} ";
                case "CM":
                    return $"{ToCm(A).ToString("F1", formatProvider)}{format} \u00D7 {ToCm(B).ToString("F1", formatProvider)}{format} \u00D7 {ToCm(C).ToString("F1", formatProvider)}{format} ";
                case "MM":
                    return $"{ToMm(A).ToString("F0", formatProvider)}{format} \u00D7 {ToMm(B).ToString("F0", formatProvider)}{format} \u00D7 {ToMm(C).ToString("F0", formatProvider)}{format} ";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public double ToCm(double a)
        {
            return a * 100;
        }

        public double ToMm(double a)
        {
            return a * 1000;
        }



        public bool Equals(Pudelko other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public enum UnitOfMeasure
    {
        milimeter, centimeter, meter
    }
}
