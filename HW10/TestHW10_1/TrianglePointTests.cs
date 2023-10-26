namespace HW10_1.Tests
{
    [TestClass]
    public class TriangleTests

    {
        [TestMethod]
        public void TestSquare_9returned()
        {
            Triangle t = new Triangle(new Point(1, 9), new Point(2, 3), new Point(3, 15));
            double expected = 9.0;
            double actual = Math.Round(t.Square(), 2);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestPerimeter_returned()
        {
            Triangle t = new Triangle(new Point(1, 9), new Point(2, 3), new Point(3, 15));
            double expected = 24.45;
            double actual = Math.Round(t.Perimeter(),2);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TriangleIsValid()
        {
            Triangle t = new Triangle(new Point(1, 9), new Point(-1, 3), new Point(1, 15));
            bool isValid = t.IsValid();

            Assert.IsTrue(isValid);

        }
        [TestMethod]
        public void TriangleNotValid_ThrowsAplicationException()
        {
            Assert.ThrowsException<ApplicationException>(() => new Triangle(new Point(1, 9), new Point(1, 3), new Point(1, 15)));
        }

    }

    [TestClass]
    public class PointTests

    {
        [TestMethod]
        public void TestToString()
        {
            Point p = new Point(1, 9);
            string actual = p.ToString();
            string expected = "(1,9)";

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestDistance_3_61returned()
        {
            Point p = new Point(1, 2);
            double actual = Math.Round(p.Distance(new Point(3,5)),2);
            double expected = 3.61;

            Assert.AreEqual(expected, actual);

        }

    }
}