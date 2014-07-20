using System;

namespace Calculator.MathOperations.Exceptions
{
    /// <summary>
    /// Should be throwed when expression is not parseable.
    /// </summary>
    public class ExpressionNotParseableException : Exception
    {
        public ExpressionNotParseableException(string message)
            : base(message)
        {
            
        }

        public ExpressionNotParseableException()
        {
            
        }
    }
}
