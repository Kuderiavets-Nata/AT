using System;
namespace Lab1MSTest
{
    public class FormulaImplementation
    {
        public FormulaImplementation()
        {
        }

        public static double FormulaImpl(int x) => (Math.Sqrt(x - 1) / (x - 1));
        public static double FormulaImpl(double x) => (Math.Sqrt(x - 1) / (x - 1));
    }
}
