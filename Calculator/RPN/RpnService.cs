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

            foreach (var token in tokenList)
            {
                double value;
                if (double.TryParse(token, out value)) //number
                {
                    output.Enqueue(value);
                }
                else //operator
                {
                    var mathOperation = (IMathOperation)OperationsMapper.Get()[token];
                    if (mathOperation == null)
                    {
                        throw new OperationNotSupportedException("Not supported operation");
                    }
                    while (operatorsStack.Count > 0 && (int)OperationsPrioritier.Get()[operatorsStack.Peek().Mark()] >= (int)OperationsPrioritier.Get()[mathOperation.Mark()])
                    {
                        output.Enqueue(operatorsStack.Pop());
                    }

                    operatorsStack.Push(mathOperation);
                }
            }

            StringBuilder builder = new StringBuilder();
            while (output.Count > 0)
            {
                object obj = output.Dequeue();
                if (obj is IMathOperation)
                {
                    builder.Append((obj as IMathOperation).Mark());
                }
                else
                {
                    builder.Append(obj); 
                }
                
                builder.Append(" ");
            }

            builder.Append(operatorsStack.Pop().Mark());

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
