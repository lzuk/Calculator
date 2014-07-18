namespace Calculator.MathOperations.Operations
{
    public class Minus : IMathOperation
    {
        public double PerformOperation(double param1, double param2)
        {
            return param1 - param2;
        }
    }
}
