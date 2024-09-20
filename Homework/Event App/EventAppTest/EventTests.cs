using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventInterface;

namespace EventAppTest
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void PriceCost_InputIsCapD()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("D");
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void PriceCost_InputIsLowerd()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("d");
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void PriceCost_InputIsCapL()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("L");
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void PriceCost_InputIsLowerl()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("l");
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void PriceCost_InputIsInvalid()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("Hello Alec");
            // assert
            Assert.AreEqual(unitPrice, 10);
        }

        [TestMethod]
        public void PriceCost_InputIsWrongChar()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("C");
            // assert
            Assert.AreEqual(unitPrice, 10);
        }
    }
}