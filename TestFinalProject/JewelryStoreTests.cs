using System.Collections.Generic;
using System.Drawing;

namespace FinalProject.Tests
{
    [TestClass]
    public class JewelryStoreTests
    {
        [TestMethod]
        public void JewelryStoreNotValid_ThrowsAplicationException()
        {
            Assert.ThrowsException<ApplicationException>(() => new JewelryStore(
                                                                1, "Lvivska,10", new List<Jewelry> { 
                                                                                 new Jewelry("gold", "gold", 2.0, 2000) }));
        }

        [TestMethod]
        public void JewelryStoreConstructor_CreateJewelryStoreObject()
        {
            JewelryStore st = new JewelryStore(2, "Lvivska,10", new List<Jewelry> {
                                                                new Jewelry("ring", "gold", 2.0, 2000),
                                                                new Jewelry("ring", "gold", 3.0, 1000)});
            Assert.IsNotNull(st);
            Assert.AreEqual("Lvivska,10", st.Address);
            Assert.AreEqual(2, st.AmountOfJewelries);     
        }

        [TestMethod]
        public void InputFromFile_CreateJewelryStoreObject()
        {
            string testFilePath = @"D:\C# Fundamentals\FinalProject\Data\TestInput.txt"; 
            string testAddress = "Lvivska,10";

            using (StreamWriter sw = new StreamWriter(testFilePath, false))
            {
                sw.WriteLine("Lvivska,10 necklace gold 3,0 2000,00");
                sw.WriteLine("Lvivska ring silver 2,5 150,00");
            }
            JewelryStore st = JewelryStore.InputFromFile(testFilePath, testAddress);

            Assert.IsNotNull(st);
            Assert.AreEqual(1, st.AmountOfJewelries);
            Assert.AreEqual(testAddress, st.Address);
            Assert.AreEqual("necklace", st.JewelryList[0].Name);
            Assert.AreEqual("gold", st.JewelryList[0].Metal);
            Assert.AreEqual(3.0, st.JewelryList[0].Weight);
            Assert.AreEqual(2000, st.JewelryList[0].Price);
            
        }



    }
}