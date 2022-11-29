using Area;
using NUnit.Framework;

namespace Area.Tests
{
    [TestFixture]
    public class TriangleTest
    {
        [TestCase(1, 5, 4)]
        [TestCase(3, 2, 1)]
        [TestCase(4, 6, 2)]
        public void TriangleNotExist(double a, double b, double c)
        {
            Assert.Throws<FigureNotExistException>(() => new Triangle(a, b, c));
        }
        
        [TestCase(2, 3, 4, 2.90474)]
        [TestCase(5, 7, 3, 6.49519)]
        [TestCase(110, 80, 75, 2999.94141)]
        [DefaultFloatingPointTolerance(0.00001)]
        public void TriangleSquare(double a, double b, double c, double square)
        {
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(square, triangle.Area);
        }

        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(2, 3, 4, ExpectedResult = false)]
        [TestCase(10, 6, 8, ExpectedResult = true)]
        public bool TriangleIsRectangular(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            return triangle.IsRectangular;
        }
    }
}