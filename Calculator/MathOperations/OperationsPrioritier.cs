using System.Collections;

namespace Calculator.MathOperations
{
    class OperationsPrioritier
    {
        private static Hashtable _proritier;
        public static Hashtable Get()
        {
            if (_proritier == null)
            {
                _proritier = new Hashtable
                {
                    {"+", 1},
                    {"-", 1},
                    {"*", 2},
                    {"/", 2}
                };
            }
            return _proritier;
        }
    }
}
