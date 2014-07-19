using Calculator.RPN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class RpnServiceTests
    {
        IRpn service = new RpnService();

        [TestMethod]
        public void ShouldReturnValue1()
        {
            //given
            const string rpn = "12 2 3 4 * 10 5 / + * +";

            //when
            double result = service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void ShouldReturnValue2()
        {
            //given
            const string rpn = "2 3 + 5 *";

            //when
            double result = service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void ShouldReturnValue3()
        {
            //given
            const string rpn = "2 7 + 3 / 14 3 - 4 * + 2 /";

            //when
            double result = service.CalculateRpn(rpn);

            //then
            Assert.AreEqual(-20.5, result);
        }

        [TestMethod]
        public void ShouldReturnRNPExpression1()
        {
            //given
            const string expression = "3+4*2/(1-5)";

            //when
            string result = service.CreateRpn(expression);

            //then
        }

        [TestMethod]
        public void ShouldReturnRNPExpression2()
        {
            //given
            const string expression = "3+4";

            //when
            string result = service.CreateRpn(expression);

            //then
            Assert.AreEqual("3 4", result);

        }

        [TestMethod]
        public void ShouldReturnRNPExpression3()
        {
            //given
            const string expression = "3+4+2";

            //when
            string result = service.CreateRpn(expression);

            //then
            Assert.AreEqual("3 4", result);

        }
    }
}
