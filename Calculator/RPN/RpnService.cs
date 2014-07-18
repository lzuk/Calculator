using System.Collections.Generic;
using Calculator.MathOperations;
using Calculator.MathOperations.Exceptions;

namespace Calculator.RPN
{
    public class RpnService : IRpn
    {
        public string CreateRpn(string expression)
        {
            throw new System.NotImplementedException();
        }

        public double CalculateRpn(string rpn)
        {
            var rpnStrings = rpn.Split(' ');
            var stack = new Stack<double>();
            var mappings = OperationsMapper.Get();

            foreach (var token in rpnStrings)
            {
                double value;
                if (double.TryParse(token, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    var mathOperation = (IMathOperation)mappings[token];
                    if (mathOperation == null)
                    {
                        throw new OperationNotSupportedException("Not supported operation");
                    }

                    stack.Push(mathOperation.PerformOperation(stack.Pop(), stack.Pop()));
                }
            }
            return stack.Pop();
        }


    }
}
