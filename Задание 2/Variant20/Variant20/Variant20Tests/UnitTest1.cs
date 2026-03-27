using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Variant20;

namespace Variant20Tests
{
    [TestClass]
    public class ExpressionCalculatorTests
    {
        // ТЕСТЫ С ДОПУСТИМЫМИ ЗНАЧЕНИЯМИ

        [TestMethod]
        public void TestSimpleAddition()
        {
            double result = ExpressionCalculator.Calculate("2+3");
            Assert.AreEqual(5, result, 0.001, "2+3 должно быть равно 5");
        }

        [TestMethod]
        public void TestSimpleSubtraction()
        {
            double result = ExpressionCalculator.Calculate("10-4");
            Assert.AreEqual(6, result, 0.001, "10-4 должно быть равно 6");
        }

        [TestMethod]
        public void TestMultiplication()
        {
            double result = ExpressionCalculator.Calculate("6*7");
            Assert.AreEqual(42, result, 0.001, "6*7 должно быть равно 42");
        }

        [TestMethod]
        public void TestDivision()
        {
            double result = ExpressionCalculator.Calculate("15/3");
            Assert.AreEqual(5, result, 0.001, "15/3 должно быть равно 5");
        }

        [TestMethod]
        public void TestPower()
        {
            double result = ExpressionCalculator.Calculate("2^3");
            Assert.AreEqual(8, result, 0.001, "2^3 должно быть равно 8");
        }

        [TestMethod]
        public void TestOperatorPrecedence()
        {
            double result = ExpressionCalculator.Calculate("2+3*4");
            Assert.AreEqual(14, result, 0.001, "2+3*4 должно быть равно 14");
        }

        [TestMethod]
        public void TestParentheses()
        {
            double result = ExpressionCalculator.Calculate("(2+3)*4");
            Assert.AreEqual(20, result, 0.001, "(2+3)*4 должно быть равно 20");
        }

        [TestMethod]
        public void TestDecimalNumbers()
        {
            double result = ExpressionCalculator.Calculate("2.5*4.2");
            Assert.AreEqual(10.5, result, 0.001, "2.5*4.2 должно быть равно 10.5");
        }

        [TestMethod]
        public void TestNegativeNumbers()
        {
            double result = ExpressionCalculator.Calculate("-5+3");
            Assert.AreEqual(-2, result, 0.001, "-5+3 должно быть равно -2");
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            double result = ExpressionCalculator.Calculate("-13.5*7 - 21.6/3.2/0.15 + 1.5^3 - 98.5");
            Assert.AreEqual(-234.625, result, 0.001, "Результат должен быть -234.625");
        }

        [TestMethod]
        public void TestExpressionWithSpaces()
        {
            double result = ExpressionCalculator.Calculate("  2 + 3 * 4  ");
            Assert.AreEqual(14, result, 0.001, "Выражение с пробелами должно корректно вычисляться");
        }

        [TestMethod]
        public void TestNestedParentheses()
        {
            double result = ExpressionCalculator.Calculate("(2*(3+4))^2");
            Assert.AreEqual(196, result, 0.001, "(2*(3+4))^2 должно быть равно 196");
        }

        // ТЕСТЫ С ГРАНИЧНЫМИ ЗНАЧЕНИЯМИ

        [TestMethod]
        public void TestVerySmallNumber()
        {
            double result = ExpressionCalculator.Calculate("0.0001*10000");
            Assert.AreEqual(1, result, 0.001, "0.0001*10000 должно быть равно 1");
        }

        [TestMethod]
        public void TestVeryLargeNumber()
        {
            double result = ExpressionCalculator.Calculate("1000000*1000000");
            Assert.AreEqual(1e12, result, 1e6, "1000000*1000000 должно быть примерно 1e12");
        }

        // НЕГАТИВНЫЕ ТЕСТЫ (С ОШИБКАМИ)

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEmptyExpression()
        {
            ExpressionCalculator.Calculate("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullExpression()
        {
            ExpressionCalculator.Calculate(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivisionByZero()
        {
            ExpressionCalculator.Calculate("10/0");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestUnbalancedParentheses()
        {
            ExpressionCalculator.Calculate("(2+3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidCharacters()
        {
            ExpressionCalculator.Calculate("2+3a");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTwoOperatorsInRow()
        {
            ExpressionCalculator.Calculate("2++3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOperatorAtStart()
        {
            ExpressionCalculator.Calculate("*2+3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOperatorAtEnd()
        {
            ExpressionCalculator.Calculate("2+3*");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMultipleDecimalPoints()
        {
            ExpressionCalculator.Calculate("2.5.3+1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMissingOperand()
        {
            ExpressionCalculator.Calculate("(2+)*3");
        }
    }
}