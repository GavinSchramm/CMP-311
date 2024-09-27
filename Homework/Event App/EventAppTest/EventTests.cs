using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventInterface;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

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
        public void PriceCost_InputIsCapE()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("E");
            // assert
            Assert.AreEqual(unitPrice, 7.50);
        }

        [TestMethod]
        public void PriceCost_InputIsLowere()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("e");
            // assert
            Assert.AreEqual(unitPrice, 7.50);
        }

        [TestMethod]
        public void PriceCost_InputIsCapF()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("F");
            // assert
            Assert.AreEqual(unitPrice, 0);
        }

        [TestMethod]
        public void PriceCost_InputIsLowerf()
        {
            // arrange
            IOther test = new Event(1, "Desc", 10);
            // act
            double unitPrice = test.PriceChange("f");
            // assert
            Assert.AreEqual(unitPrice, 0.0);
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

        [TestMethod]
        public void CostEngine_PriceCost_InputIsCapD()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("D",10);
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsLowerd()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("d", 10);
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsCapL()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("L", 10);
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsLowerl()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("l", 10);
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsCapE()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("E", 10);
            // assert
            Assert.AreEqual(unitPrice, 7.5);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsLowere()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("e", 10);
            // assert
            Assert.AreEqual(unitPrice, 7.5);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsCapF()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("F", 10);
            // assert
            Assert.AreEqual(unitPrice, 0);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsLowerf()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("f", 10);
            // assert
            Assert.AreEqual(unitPrice, 0);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsInvalid()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("Hello Alec", 10);
            // assert
            Assert.AreEqual(unitPrice, 10);
        }

        [TestMethod]
        public void CostEngine_PriceCost_InputIsWrongChar()
        {
            // arrange
            CostEngine costEngine = new CostEngine();
            // act
            double unitPrice = costEngine.PriceChange("P", 10);
            // assert
            Assert.AreEqual(unitPrice, 10);
        }
    }
}