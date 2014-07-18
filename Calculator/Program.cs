using System;
using Calculator.RPN;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string rpn = "12 2 3 4 * 10 5 / + * +";
            Console.WriteLine(rpn);

            IRpn service = new RpnService();

            double result = service.CalculateRpn(rpn);
            Console.WriteLine("Result: {0}", result);
            Console.ReadKey();
        }
    }
}
