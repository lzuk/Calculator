namespace Calculator.MathOperations.Operations
{
    public class Multiply : IMathOperation
    {
        public double PerformOperation(double param1, double param2)
        {
            return param1 * param2;
        }

        public string Mark()
        {
            return "*";
        }
    }
}
