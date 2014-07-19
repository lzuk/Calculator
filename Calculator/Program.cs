using System;
using Calculator.MathOperations.Exceptions;
using Calculator.RPN;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Write expression");
            Console.WriteLine("To quit type q");

            IRpn service = new RpnService();

            while (true)
            {
                Console.Write("Expression: ");
                string expression = Console.ReadLine();

                if (expression == "q")
                    return;

                try
                {
                    double result = service.CalucalteValue(expression);
                    Console.WriteLine("Result: {0}", result);
                }
                catch (ExpressionNotParseableException)
                {
                    Console.WriteLine("Exception not parseable");
                }
                catch (OperationNotSupportedException)
                {
                    Console.WriteLine("Not supported operation");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid operation");
                }
            }
        }
    }
}
