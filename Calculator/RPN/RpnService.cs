using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Calculator.Extensions;
using Calculator.MathOperations;
using Calculator.MathOperations.Exceptions;

namespace Calculator.RPN
{
    public class RpnService : IRpn
    {
        public string CreateRpn(string expression)
        {
            expression = ValidateExpression(expression);

            var tokenList = TokenList(expression);

            var operatorsStack = new Stack<IMathOperation>();
            var output = new Queue<object>();

            foreach (var token in tokenList)
            {
                double value;
                if (double.TryParse(token, out value))
                {
                    output.Enqueue(value);
                }
                else
                {
                    var mathOperation = CheckIsMathOperation(OperationsMapper.Get(), token);

                    while (operatorsStack.Count > 0 && (int)OperationsPrioritier.Get()[operatorsStack.Peek().Mark()] >= (int)OperationsPrioritier.Get()[mathOperation.Mark()])
                    {
                        output.Enqueue(operatorsStack.Pop());
                    }

                    operatorsStack.Push(mathOperation);
                }
            }

            return CreateRpnFromOperatiopnStackAndOutput(output, operatorsStack);
        }

        public double CalculateRpn(string rpn)
        {
            var rpnStrings = rpn.Split(' ');
            var stack = new Stack<double>();

            foreach (var token in rpnStrings)
            {
                double value;
                if (double.TryParse(token, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    var mathOperation = CheckIsMathOperation(OperationsMapper.Get(), token);

                    stack.Push(mathOperation.PerformOperation(stack.Pop(), stack.Pop()));
                }
            }
            return stack.Pop();
        }

        private static IMathOperation CheckIsMathOperation(Hashtable mappings, string token)
        {
            var mathOperation = (IMathOperation) mappings[token];
            if (mathOperation == null)
            {
                throw new OperationNotSupportedException("Not supported operation");
            }

            return mathOperation;
        }

        private static string CreateRpnFromOperatiopnStackAndOutput(Queue<object> output, Stack<IMathOperation> operatorsStack)
        {
            var builder = new StringBuilder();
            while (output.Count > 0)
            {
                var obj = output.Dequeue();
                if (obj is IMathOperation)
                {
                    builder.Append((obj as IMathOperation).Mark());
                }
                else
                {
                    builder.Append(obj);
                }

                builder.Append(' ');
            }

            while (operatorsStack.Count > 0)
            {
                builder.Append(operatorsStack.Pop().Mark());
                builder.Append(' ');
            }

            return builder.ToString().TrimEnd(' ');
        }

        private static string ValidateExpression(string expression)
        {
            if (expression.IsParseable())
            {
                return expression;
            }

            throw new ExpressionNotParseableException();
        }

        private static IEnumerable<string> TokenList(string expression)
        {
            var splitCharactersRegex = new Regex(@"([\+\-\*\/])");
            var tokenList = splitCharactersRegex.Split(expression).Select(t => t.Trim()).Where(t => t != "").ToList();
            return tokenList;
        }
    }
}
