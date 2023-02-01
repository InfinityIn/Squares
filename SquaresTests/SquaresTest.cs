using Squares;

namespace SquaresTests
{
    public class SquaresTest
    {
        [TestCase("01 Circle Square, R = 1", 1, 3.14)]
        [TestCase("02 Circle Square, R = 10", 10, 314.16)]
        
        public void CalcSquare(string _, double radius, double result)
        {
            ISquareable circle = new Circle(radius);
            Assert.That(circle.Square(), Is.EqualTo(result));
        }

        [TestCase("03 Circle Square, R = 0", 0)]
        [TestCase("03 Circle Square, R = -5", -5)]
        public void CalcSquareWithThrow(string _, double radius)
        {
            Assert.Throws<Exception>(() => new Circle(radius));
        }

        [TestCase("04 Triangle Sqaure: 5,5,6", 5, 5, 6, 12)]
        [TestCase("05 Triangle Sqaure: 12,10,3", 12, 10, 3, 12.18)]
        [TestCase("06 Triangle Sqaure: 3,4,5", 3, 4, 5, 6)]
        public void TriangleSquare(string _, double firstSide, double secondSide, double thirdSide, double result)
        {
            ISquareable triangle = new Triangle(firstSide,secondSide,thirdSide);
            Assert.That(triangle.Square(), Is.EqualTo(result));
        }

        [TestCase("07 Triangle Sqaure: 5,5,30", 5, 5, 30)]
        [TestCase("08 Triangle Sqaure: 5,0,5", 5, 0, 5)]
        [TestCase("09 Triangle Sqaure: 5,-5,-30", 5, -5, -30)]
        public void TriangleSquareWithThrow(string _, double firstSide, double secondSide, double thirdSide)
        {
            Assert.Throws<Exception>(() => new Triangle(firstSide, secondSide, thirdSide));
        }
    }
}