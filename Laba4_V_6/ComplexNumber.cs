using System;


namespace Laba4_V_6
{
    class ComplexNumber
    {
        private double _realPart;
        private double _imaginaryPart;

        private double RealPart
        {
            get => _realPart;
            set => _realPart = value;
        }
        private double ImaginaryPart
        {
            get => _imaginaryPart;
            set => _imaginaryPart = value;
        }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="realPart">действительная часть комплексного числа</param>
        /// <param name="imaginaryPart">мнимая часть комплексного числа</param>
        public ComplexNumber(double realPart, double imaginaryPart)
        {
            RealPart = realPart;
            ImaginaryPart = imaginaryPart;
        }
        /// <summary>
        /// модуль комплексного числа
        /// </summary>
        /// <returns></returns>
        public double Module()
        {
            return Math.Sqrt(RealPart * RealPart + ImaginaryPart * ImaginaryPart);
        }
        /// <summary>
        /// угол фи комплексного числа 
        /// </summary>
        /// <returns></returns>
        private double AnglePhi()
        {
            return Math.Atan2(ImaginaryPart, RealPart);
        }
        /// <summary>
        /// возведение в степень комплексного числа
        /// </summary>
        /// <param name="n">степень возведения </param>
        /// <returns></returns>
        public ComplexNumber Pow(int n)
        {
            if (n > 0)
            {
                double newMagnitude = Math.Pow(this.Module(), n);
                return new ComplexNumber(newMagnitude * Math.Cos(this.AnglePhi() * n), newMagnitude * Math.Sin(this.AnglePhi() * n));
            }
            else if (n == 1)
            {
                return new ComplexNumber(1, 0);
            }
            else
            {
                double newMagnitude = Math.Pow(this.Module(), 1 / Math.Abs(n));
                return new ComplexNumber(Math.Cos(this.AnglePhi() / n) * newMagnitude, Math.Sin(this.AnglePhi() / n) * newMagnitude);
            }
        }
        /// <summary>
        /// метод вывода комплексного числа
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $" {RealPart} + {ImaginaryPart}i";
        }
  
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is  null || c2 is  null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new ComplexNumber(c1.RealPart + c2.RealPart, c1.ImaginaryPart + c2.ImaginaryPart);
            }

        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is null || c2 is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return c1 + new ComplexNumber(-c2.RealPart, -c2.ImaginaryPart);
            }
        }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is  null || c2 is  null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return new ComplexNumber(c1.RealPart * c2.RealPart - c1.ImaginaryPart * c2.ImaginaryPart, c1.RealPart * c2.ImaginaryPart + c1.ImaginaryPart * c2.RealPart);
            }
        }
        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            if (c1 is null || c2 is  null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                double denominator = c2.RealPart * c2.RealPart + c2.ImaginaryPart * c2.ImaginaryPart;
                if (denominator != 0)
                {
                    double realPart = (c1.RealPart * c2.RealPart + c1.ImaginaryPart * c2.ImaginaryPart) / denominator;
                    double imaginaryPart = (c1.ImaginaryPart * c2.RealPart - c1.RealPart * c2.ImaginaryPart) / denominator;
                    return new ComplexNumber(realPart, imaginaryPart);
                }
                else
                {
                    throw new DivideByZeroException();
                }
            }
        }
    }
}
