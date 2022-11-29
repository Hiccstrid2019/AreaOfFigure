using NUnit.Framework;

namespace Area.Tests
{
    [TestFixture]
    public class AutoDetectAreaTest
    {
        [Test]
        [DefaultFloatingPointTolerance(0.00001)]
        public void AutoDetectArea()
        {
            var circle = new Circle(1);
            Figure figure = circle;
            Assert.AreEqual(3.14159, figure.AutoDetectArea());

            var triangle = new Triangle(5, 7, 3);
            Figure figure2 = triangle;
            Assert.AreEqual(6.49519, figure2.AutoDetectArea());
        }
    }
}