using System;

namespace Calculator.MathOperations.Exceptions
{
    class ExpressionNotParseableException : Exception
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
