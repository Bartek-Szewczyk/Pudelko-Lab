using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace PudelkoLib
{
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable
    {
        private readonly double _a = 0.1;
        private readonly double _b = 0.1;
        private readonly double _c = 0.1;
        private readonly UnitOfMeasure _unit;

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
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            switch (unit)
            {
                case UnitOfMeasure.centimeter:
                    _a = a / 100;
                    _b = b / 100;
                    _c = c / 100;
                    break;
                case UnitOfMeasure.milimeter:
                    _a = a / 1000;
                    _b = b / 1000;
                    _c = c / 1000;
                    break;
                default:
                    _a = a;
                    _b = b;
                    _c = c;
                    break;
            }

            _unit = unit;
            CheckRange(A, B, C);
        }
        public Pudelko(double a, double b, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            switch (unit)
            {
                case UnitOfMeasure.centimeter:
                    _a = a / 100;
                    _b = b / 100;


                    break;
                case UnitOfMeasure.milimeter:
                    _a = a / 1000;
                    _b = b / 1000;

                    break;
                default:
                    _a = a;
                    _b = b;

                    break;
            }

            _unit = unit;
            CheckRange(A, B, C);
        }
        public Pudelko(double a, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            switch (unit)
            {
                case UnitOfMeasure.centimeter:
                    _a = Math.Round((a / 100), 2);
                    break;
                case UnitOfMeasure.milimeter:
                    _a = a / 1000;

                    break;
                default:
                    _a = a;
                    break;
            }

            _unit = unit;
            CheckRange(A, B, C);
        }

        public Pudelko()
        {

        }

        public void CheckRange(double a, double b, double c)
        {
            if (a < 0.001 || b < 0.001 || c < 0.001)
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
            return ToString(format, CultureInfo.GetCultureInfo("en-US"));
        }
        public override string ToString()
        {
            return this.ToString("m", CultureInfo.GetCultureInfo("en-US"));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                format = "m";
            }

            switch (format.ToUpperInvariant())
            {
                case "M":
                    return $"{A.ToString("F3", formatProvider)} {format} \u00D7 {B.ToString("F3", formatProvider)} {format} \u00D7 {C.ToString("F3", formatProvider)} {format}";
                case "CM":
                    return $"{ToCm(A).ToString("F1", formatProvider)} {format} \u00D7 {ToCm(B).ToString("F1", formatProvider)} {format} \u00D7 {ToCm(C).ToString("F1", formatProvider)} {format}";
                case "MM":
                    return $"{ToMm(A).ToString("F0", formatProvider)} {format} \u00D7 {ToMm(B).ToString("F0", formatProvider)} {format} \u00D7 {ToMm(C).ToString("F0", formatProvider)} {format}";
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

        public double Objetosc
        {
            get => Math.Round(A * B * C, 9);
        }

        public double Pole
        {
            get => Math.Round(2 * (A * B + A * C + B * C), 6);
        }

        public bool Equals(Pudelko other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Objetosc==other.Objetosc && Pole==other.Pole;
        }

        public override bool Equals(Object obj)
        {
            return Equals(obj as Pudelko);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (A, B, C).GetHashCode();
            }
           
        }


        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            if (Pudelko.ReferenceEquals(p1, null))
            {
                if (Pudelko.ReferenceEquals(p2, null))
                {
                    return true;
                }

                return false;
            }

            return p1.Equals(p1);
        }

        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !(p1.Equals(p2));
        }

        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {

            return null;
        }



        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    
}
