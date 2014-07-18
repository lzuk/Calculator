using System;
using System.Collections;
using Calculator.MathOperations;
using Calculator.MathOperations.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MathOperations
    {
        private IMathOperation _operation;
        private readonly Hashtable mapper = OperationsMapper.Get();

        [TestMethod]
        public void ShouldReturnSum()
        {
            //given
            _operation = new Plus();

            //when
            double result = _operation.PerformOperation(2, 2);

            //then
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void ShouldReturnDifference()
        {
            //given
            _operation = new Minus();

            //when
            double result = _operation.PerformOperation(2, 3);

            //then
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void ShouldReturnRatio()
        {
            //given
            _operation = new Multiply();

            //when
            double result = _operation.PerformOperation(2, 3);

            //then
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void ShouldReturnQuotient()
        {
            //given
            _operation = new Division();

            //when
            double result = _operation.PerformOperation(2, 1);

            //then
            Assert.AreEqual(0.5 , result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ShouldThrowDivisionByZeroException()
        {
            //given
            _operation = new Division();

            //when
            _operation.PerformOperation(0, 1);
        }

        [TestMethod]
        public void ShouldReturnValidObjectMultiply()
        {
            //when
            _operation = (IMathOperation) mapper["*"];

            //then
            Assert.AreEqual(typeof(Multiply), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectDivision()
        {
            //when
            _operation = (IMathOperation)mapper["/"];

            //then
            Assert.AreEqual(typeof(Division), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectPlus()
        {
            //when
            _operation = (IMathOperation)mapper["+"];

            //then
            Assert.AreEqual(typeof(Plus), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidObjectMinus()
        {
            //when
            _operation = (IMathOperation)mapper["-"];

            //then
            Assert.AreEqual(typeof(Minus), _operation.GetType());
        }

        [TestMethod]
        public void ShouldReturnValidNullWhenThereIsNoSuchType()
        {
            //when
            _operation = (IMathOperation)mapper["?"];

            //then
            Assert.AreEqual(null, _operation);
        }
    }
}
