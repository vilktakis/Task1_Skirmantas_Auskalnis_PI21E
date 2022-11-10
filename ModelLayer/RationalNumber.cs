using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class RationalNumber
    {
        public string name { get; set; }
        public int numerator;
        public int denominator;

        public RationalNumber(int x, int y)
        {
            numerator = x;
            denominator = y;
        }

        public RationalNumber()
        {

        }

        public RationalNumber Addition(RationalNumber rationalNumber)
        {
            int numerator1 = numerator * rationalNumber.denominator;
            int numerator2 = rationalNumber.numerator * denominator;
            int newNumerator = numerator1 + numerator2;

            int newDenominator = denominator * rationalNumber.denominator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        public RationalNumber Subtraction(RationalNumber rationalNumber)
        {
            int numerator1 = numerator * rationalNumber.denominator;
            int numerator2 = rationalNumber.numerator * denominator;
            int newNumerator = numerator1 - numerator2;

            int newDenominator = denominator * rationalNumber.denominator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        public RationalNumber Multiplication(RationalNumber rationalNumber)
        {
            int newNumerator = numerator * rationalNumber.numerator;

            int newDenominator = denominator * rationalNumber.denominator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        public RationalNumber Division(RationalNumber rationalNumber)
        {
            int newNumerator = numerator * rationalNumber.denominator;

            int newDenominator = denominator * rationalNumber.numerator;

            return new RationalNumber(newNumerator, newDenominator);
        }

        public bool More(RationalNumber rationalNumber)
        {
            double x = numerator / denominator;

            double y = rationalNumber.numerator / rationalNumber.denominator;

            if (x > y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Equals(RationalNumber rationalNumber)
        {
            double x = numerator / denominator;

            double y = rationalNumber.numerator / rationalNumber.denominator;

            if (x == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public RationalNumber Negative()
        {
            return new RationalNumber(numerator * -1, denominator);
        }
    }
}
