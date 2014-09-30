using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taksopark.BL.Interfaces;

namespace Taksopark.BL.Test
{
    [TestClass]
    public class OrderCostCalcStrategyTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_1()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(0, false, null, false);
        }


        [TestMethod]
        public void TestCalcCost_1()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 30;
            decimal actual = strategy.CalcCost(10, false, null, false);
            Assert.AreEqual(expected, actual);
        }
    }
}
