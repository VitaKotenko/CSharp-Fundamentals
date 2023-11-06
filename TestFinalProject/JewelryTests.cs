using System.Drawing;

namespace FinalProject.Tests
{
    [TestClass]
    public class JewelryTests
    {
        [TestMethod]
        public void JewelryNotValid_ThrowsAplicationException()
        {
            Assert.ThrowsException<ApplicationException>(() => new Jewelry("gold", "gold", 2.0, 2000));
            Assert.ThrowsException<ApplicationException>(() => new Jewelry("ring", "ring", 2.0, 2000));
            Assert.ThrowsException<ApplicationException>(() => new Jewelry("ring", "gold", 0.0, 2000));
            Assert.ThrowsException<ApplicationException>(() => new Jewelry("ring", "gold", 2.0, 0));
        }

        [TestMethod]
        public void JewelryConstructor_CreateJewelryObject()
        {
            Jewelry j = new Jewelry("necklace", "gold", 2.0, 2000);
            Assert.IsNotNull(j);
            Assert.AreEqual("necklace", j.Name);
            Assert.AreEqual("gold", j.Metal);
            Assert.AreEqual(2.0, j.Weight);
            Assert.AreEqual(2000.00, j.Price);
        }

        [TestMethod]
        public void JewelryToString()
        {
            Jewelry j = new Jewelry("necklace", "gold", 2.0, 2000);
            string expected = "Jewelry: necklace was made from gold, price: 2000 and weight: 2 g.";
            string actual = j.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}