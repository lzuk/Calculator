using System;
using System.Collections;
using System.Linq;

namespace Calculator.MathOperations
{
    public static class OperationsMapper
    {
        private static Hashtable _mapper;
        public static Hashtable Get()
        {
            if (_mapper == null)
            {
                _mapper = new Hashtable();
                var iMathOperationsTypes =
                    System.Reflection.Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(mytype => mytype.GetInterfaces().Contains(typeof (IMathOperation)));

                foreach (Type mathType in iMathOperationsTypes)
                {
                    var instance = (IMathOperation)Activator.CreateInstance(mathType);
                    _mapper.Add(instance.Mark(), instance);
                };
            }
            return _mapper;
        }
    }
}
