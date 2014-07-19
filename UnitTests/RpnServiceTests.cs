using Calculator.MathOperations.Exceptions;
using Calculator.RPN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RpnServiceTests
    {
        readonly IRpnService _service = new RpnService();

        [TestMethod]
        public void ShouldReturnValue1()
        {
            //given
            const string rpn = "12 2 3 4 * 10 5 / + * +";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void ShouldReturnValue2()
        {
            //given
            const string rpn = "2 3 + 5 *";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void ShouldReturnValue3()
        {
            //given
            const string rpn = "2 7 + 3 / 14 3 - 4 * + 2 /";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(-20.5, result);
        }

        [TestMethod]
        public void ShouldReturnValue4()
        {
            //given
            const string rpn = "3 4 + 2 +";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void ShouldReturnValue5()
        {
            //given
            const string rpn = "3 4 2 * +";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void ShouldReturnValue6()
        {
            //given
            const string rpn = "3 4 2 * 1 / +";

            //when
            double result = _service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void ShouldReturnRNPExpression1()
        {
            //given
            const string expression = "3+4*2/1";

            //when
            string result = _service.CreateRpn(expression);

            //then
            Assert.AreEqual("3 4 2 * 1 / +", result);
        }

        [TestMethod]
        public void ShouldReturnRNPExpression2()
        {
            //given
            const string expression = "3+4";

            //when
            string result = _service.CreateRpn(expression);

            //then
            Assert.AreEqual("3 4 +", result);

        }

        [TestMethod]
        public void ShouldReturnRNPExpression3()
        {
            //given
            const string expression = "3+4+2";

            //when
            string result = _service.CreateRpn(expression);

            //then
            Assert.AreEqual("3 4 + 2 +", result);
        }



        [TestMethod]
        public void ShouldReturnValueFromExpression1()
        {
            //given
            const string expression = "3+ 4*2 / 1";

            //when
            double result = _service.CalucalteValue(expression);

            //then
            Assert.AreEqual(11, result);

        }

        [TestMethod]
        public void ShouldReturnValueFromExpression2()
        {
            //given
            const string expression = "3*5*10/15+3*2";

            //when
            double result = _service.CalucalteValue(expression);

            //then
            Assert.AreEqual(16, result);

        }

        [TestMethod]
        public void ShouldReturnValueFromExpression3()
        {
            //given
            const string expression = "3*5*10/15+3*2+10*2/2+7*3+1+6+19+5/1+7*3+1";

            //when
            double result = _service.CalucalteValue(expression);

            //then
            Assert.AreEqual(100, result);

        }

        [TestMethod]
        public void ShouldReturnValueFromExpression4()
        {
            //given
            const string expression = "3*5 *10 /15+3 *2+10 *2/2+7*3 +1+6+19+5/ 1+7*3+1";

            //when
            double result = _service.CalucalteValue(expression);

            //then
            Assert.AreEqual(100, result);

        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionNotParseableException))]
        public void ShoulThrowExpressionNotParseableException()
        {
            //given
            const string expression = "2?2";

            //when
            string rpn = _service.CreateRpn(expression);

            //then

        }
    }
}
