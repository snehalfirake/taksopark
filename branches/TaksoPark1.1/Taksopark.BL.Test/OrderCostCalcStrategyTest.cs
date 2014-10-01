using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taksopark.BL.Interfaces;

namespace Taksopark.BL.Test
{
    [TestClass]
    public class OrderCostCalcStrategyTest
    {
        #region Validation Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_1()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(0, false, null, false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_2()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(3, false, 0, false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_3()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(3, false, 71, false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_4()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(3, true, 50, false);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_5()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(3, true, null, true);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCalcCost_Validation_6()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            strategy.CalcCost(3, false, 10, true);
        }

        #endregion

        #region Constants checking

        [TestMethod]
        public void TestCheckConstant_1()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 15m;
            decimal actual = OrderCostCalcStrategy.ORDER_COST;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_2()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 2m;
            decimal actual = OrderCostCalcStrategy.MIN_DISTANCE;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_3()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 3m;
            decimal actual = OrderCostCalcStrategy.MIN_DISTANCE_COST;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_4()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 3m;
            decimal actual = OrderCostCalcStrategy.ONE_KILOMETER_COST;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_5()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 2m;
            decimal actual = OrderCostCalcStrategy.TRACKING_COEFFICIENT;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_6()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 20m;
            decimal actual = OrderCostCalcStrategy.AVERAGE_ANIMAL_WEIGHT;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_7()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 30m;
            decimal actual = OrderCostCalcStrategy.MIN_ANIMAL_WEIGHT_COST;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_8()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 50m;
            decimal actual = OrderCostCalcStrategy.MAX_ANIMAL_WEIGHT_COST;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCheckConstant_9()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 30m;
            decimal actual = OrderCostCalcStrategy.ONE_KILOMETER_HAULAGE_COST;
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Functionality Tests

        [TestMethod]
        public void TestCalcCost_1()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 18m;
            decimal actual = strategy.CalcCost(1.5m, false, null, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_2()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 27m;
            decimal actual = strategy.CalcCost(4m, false, null, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_3()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 36m;
            decimal actual = strategy.CalcCost(1.5m, true, null, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_4()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 90m;
            decimal actual = strategy.CalcCost(10m, true, null, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_5()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 48m;
            decimal actual = strategy.CalcCost(1.5m, false, 10, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_6()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 75m;
            decimal actual = strategy.CalcCost(10m, false, 10, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_7()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 68m;
            decimal actual = strategy.CalcCost(1.5m, false, 25, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_8()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 95m;
            decimal actual = strategy.CalcCost(10m, false, 25, false);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCalcCost_9()
        {
            IOrderCostCalcStrategy strategy = new OrderCostCalcStrategy();
            decimal expected = 315m;
            decimal actual = strategy.CalcCost(10m, false, null, true);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
