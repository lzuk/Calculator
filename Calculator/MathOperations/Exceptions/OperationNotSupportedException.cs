using System;

namespace Calculator.MathOperations.Exceptions
{
    /// <summary>
    /// Should be throwed when operation is not found.
    /// </summary>
    public class OperationNotSupportedException : Exception
    {
        public OperationNotSupportedException(string message)
            : base(message)
        {
            
        }
    }
}