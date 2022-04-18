
using System;
using System.Linq;

namespace TDDRealWorld
{
    public class Calculator
    {
        virtual public double Add(params double[] numbers)
        {
            return numbers.Sum();
        }

        virtual public double Multiply(params double[] numbers)
        {
            double total = 1;
            foreach (var number in numbers)
            {
                total *= number;
            }
            return Math.Round(total, 2, MidpointRounding.AwayFromZero);
        }
    }
}