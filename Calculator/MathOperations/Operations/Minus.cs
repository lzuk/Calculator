namespace Calculator.MathOperations.Operations
{
    public class Minus : IMathOperation
    {
        public double PerformOperation(double param1, double param2)
        {
            return param2 - param1;
        }

        public string Mark()
        {
            return "-";
        }

        public int Priority()
        {
            return 1;
        }
    }
}
