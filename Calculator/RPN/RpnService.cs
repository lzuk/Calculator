using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Calculator.MathOperations;
using Calculator.MathOperations.Exceptions;

namespace Calculator.RPN
{
    public class RpnService : IRpn
    {
        public string CreateRpn(string expression)
        {
            Regex splitCharactersRegex = new Regex(@"([\+\-\*\(\)\/])");
            List<String> tokenList = splitCharactersRegex.Split(expression).Select(t => t.Trim()).Where(t => t != "").ToList();
            var operatorsStack = new Stack<IMathOperation>();
            var output = new Queue<object>();
            object opsToken = "";

            foreach (var token in tokenList)
            {
                double value;
                if (double.TryParse(token, out value)) //number
                {
                    output.Enqueue(value);
                }
                else //operator
                {
                    while (operatorsStack.Count > 0)
                    {
                        
                    }
                }
            }

            StringBuilder builder = new StringBuilder();
            while (output.Count > 1)
            {
                builder.Append(output.Dequeue());
                builder.Append(" ");
            }

            builder.Append(output.Dequeue());

            return builder.ToString();
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

        private string ValidateExpression(string expression)
        {
            return expression;
        }
    }
}
