using System.Collections;
using Calculator.MathOperations;
using Calculator.MathOperations.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MapperValidationsTests
    {
        private readonly Hashtable _mapper = OperationsMapper.Get();
        private IMathOperation _operation;

        [TestMethod]
        public void ShouldReturnValidObjectMultiply()
        {
            //when
            _operation = (IMathOperation)_mapper["*"];

            //then
            Assert.AreEqual(typeof(Multiply), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectDivision()
        {
            //when
            _operation = (IMathOperation)_mapper["/"];

            //then
            Assert.AreEqual(typeof(Division), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectPlus()
        {
            //when
            _operation = (IMathOperation)_mapper["+"];

            //then
            Assert.AreEqual(typeof(Plus), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectMinus()
        {
            //when
            _operation = (IMathOperation)_mapper["-"];

            //then
            Assert.AreEqual(typeof(Minus), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidNullWhenThereIsNoSuchType()
        {
            //when
            _operation = (IMathOperation)_mapper["?"];

            //then
            Assert.AreEqual(null, _operation);
        }
    }
}
