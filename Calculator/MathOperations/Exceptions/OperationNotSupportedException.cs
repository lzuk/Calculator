using System;

namespace Calculator.MathOperations.Exceptions
{
    /// <summary>
    /// Throws when operation is not found
    /// </summary>
    public class OperationNotSupportedException : Exception
    {
        public OperationNotSupportedException(string message)
            : base(message)
        {
            
        }
    }
}