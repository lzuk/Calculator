using System;

namespace Calculator.MathOperations.Operations
{
    public class Division : IMathOperation
    {
        public double PerformOperation(double param1, double param2)
        {
            if (param1 == 0)
            {
                throw new DivideByZeroException();
            }

            return param2 / param1;
        }
    }
}
