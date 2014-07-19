using System;

namespace Calculator.MathOperations.Exceptions
{
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
