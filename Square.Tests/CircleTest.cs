using NUnit.Framework;

namespace Square.Tests
{   
    [TestFixture]
    public class CircleTest
    {
        [TestCase(0)]
        [TestCase(-5)]
        public void CircleNotExists(double r)
        {
            Assert.Throws<FigureNotExistException>(() => new Circle(-5));
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