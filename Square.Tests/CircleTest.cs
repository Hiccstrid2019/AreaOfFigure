using NUnit.Framework;

namespace Square.Tests
{   
    [TestFixture]
    public class CircleTest
    {
        [Test]
        public void CircleNotExists()
        {
            Circle circle = null;
            Assert.Throws<FigureNotExistException>(() => circle = new Circle(-5));
        }
        
        [TestCase(1, 3.14159)]
        [TestCase(6, 113.09734)]
        [TestCase(111, 38707.56308)]
        [DefaultFloatingPointTolerance(0.00001)]
        public void CircleSquare(double r, double square)
        {
            var circle = new Circle(r);
            Assert.AreEqual(square, circle.Square);
        }
    }
}