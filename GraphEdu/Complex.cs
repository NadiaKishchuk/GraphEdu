using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEdu
{
    public class Complex
    {
        public double Real { get; private set; }
        public double Imagine { get; private set; }

        public Complex(double real, double imagine)
        {
            Real = real;
            Imagine = imagine;
        }
        public Complex() : this(0, 0) { }

        public static Complex operator +(Complex first, Complex second)
        {
            return new Complex(first.Real + second.Real, first.Imagine + second.Imagine);
        }
        public static Complex operator *(Complex first, Complex second)
        {
            return new Complex(first.Real * second.Real - first.Imagine * second.Imagine
                , first.Imagine * second.Real + first.Real * second.Imagine);
        }
        public Complex Sin()
        {
            //return new Complex(Math.Sin(Real) * Math.Cosh(Imagine),
            //    Math.Cos( Real)*Math.Sinh(Imagine));
            return new Complex(Math.Sin(Real) * Math.Cosh(Imagine),
                Math.Cos(Real) * Math.Sinh(Imagine));
        }
        public bool IsInvalid()
        {
            return double.IsNaN(Real) || double.IsInfinity(Real) ||
                IsInfinity();
        }
        public bool IsInfinity()
        {
            return double.IsNaN(Imagine) || double.IsInfinity(Imagine);
        }


    }
}
