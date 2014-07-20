using System;
using Calculator.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfStringParseable()
        {
            //given
            const string expression = "2 + 2";
            //when
            bool result = expression.IsParseable();
            //then
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void ShouldReturnFalseIfStringNotParseable()
        {
            //given
            const string expression = "2 +? 2";
            //when
            bool result = expression.IsParseable();
            //then
            Assert.AreEqual(false, result);

        }
    }
}
