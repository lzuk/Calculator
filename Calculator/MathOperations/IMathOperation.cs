namespace Calculator.MathOperations
{
    public interface IMathOperation
    {
        /// <summary>
        /// Perform operation on two selected parameters
        /// </summary>
        /// <param name="param1">First argument</param>
        /// <param name="param2">Second argument</param>
        /// <returns></returns>
       double PerformOperation(double param1, double param2);

        /// <summary>
        /// Mark of operation
        /// </summary>
        /// <returns>Mark of operation used in expression parser to decide which math operation should be used</returns>
       string Mark();

        /// <summary>
        /// Priority of operation. Higher priority means the operation will be performed in first place.
        /// </summary>
        /// <returns>Priority of application</returns>
       int Priority();
    }
}
