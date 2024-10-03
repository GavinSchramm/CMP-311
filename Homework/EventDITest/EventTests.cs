using EventDI;
namespace EventDITest
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void Wedding_CalcPrice_InputD()
        {
            // arrange
            Wedding test = new Wedding(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("D");
            // assert
            Assert.AreEqual(unitPrice, 8.5);
        }

        [TestMethod]
        public void Wedding_CalcPrice_Inputd()
        {
            // arrange
            Wedding test = new Wedding(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("d");
            // assert
            Assert.AreEqual(unitPrice, 8.5);
        }

        [TestMethod]
        public void Wedding_CalcPrice_InputL()
        {
            // arrange
            Wedding test = new Wedding(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("L");
            // assert
            Assert.AreEqual(unitPrice, 13.50);
        }

        [TestMethod]
        public void Wedding_CalcPrice_Inputl()
        {
            // arrange
            Wedding test = new Wedding(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("l");
            // assert
            Assert.AreEqual(unitPrice, 13.5);
        }

        [TestMethod]
        public void Wedding_SeeGuestList()
        {
            // arrange
            Wedding test = new Wedding(1, "Desc", 10);
            GuestEngine ge = new GuestEngine(test);
            // act
            ge.AddGuest("Sally");
            string expected = ge.SeeGuestList();
            // assert
            Assert.AreEqual(expected, "Sally\n");
        }

        //copy from above but for birthday
        [TestMethod]
        public void Birthday_CalcPrice_InputD()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("D");
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void Birthday_CalcPrice_Inputd()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("d");
            // assert
            Assert.AreEqual(unitPrice, 9);
        }

        [TestMethod]
        public void Birthday_CalcPrice_InputL()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("L");
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void Birthday_CalcPrice_Inputl()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("l");
            // assert
            Assert.AreEqual(unitPrice, 11);
        }

        [TestMethod]
        public void Birthday_CalcPrice_InputE()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("E");
            // assert
            Assert.AreEqual(unitPrice, 7.5);
        }

        [TestMethod]
        public void Birthday_CalcPrice_Inpute()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("e");
            // assert
            Assert.AreEqual(unitPrice, 7.5);
        }

        [TestMethod]
        public void Birthday_CalcPrice_InputF()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("F");
            // assert
            Assert.AreEqual(unitPrice, 0.0);
        }

        [TestMethod]
        public void Birthday_CalcPrice_Inputf()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            CostEngine ce = new CostEngine(test);
            // act
            double unitPrice = ce.CalcCost("f");
            // assert
            Assert.AreEqual(unitPrice, 0);
        }

        [TestMethod]
        public void Birthday_SeeGuestList()
        {
            // arrange
            Birthday test = new Birthday(1, "Desc", 10);
            GuestEngine ge = new GuestEngine(test);
            // act
            ge.AddGuest("Keely");
            string expected = ge.SeeGuestList();
            // assert
            Assert.AreEqual(expected, "Keely\n");
        }
    }
}