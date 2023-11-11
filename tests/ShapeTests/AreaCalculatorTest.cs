using Moq;
using ShapeLib.Contract;
using ShapeLib.Infrastructure;

namespace ShapeTests;

public class AreaCalculatorTest
{
    public class AreaCalculatorTests
    {
        [Fact]
        public void GetArea_WithMockShape_ShouldCallGetArea()
        {
            var mockShape = new Mock<IShape>();
            mockShape.Setup(s => s.GetArea()).Returns(10);

            double area = AreaCalculator.GetArea(mockShape.Object);

            mockShape.Verify(s => s.GetArea(), Times.Once);
            Assert.Equal(10, area);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        public void GetTriangleArea_ValidDimensions_ShouldReturnCorrectArea(double a, double b, double c, double expectedArea)
        {
            double area = AreaCalculator.GetTriangleArea(a, b, c);
            Assert.Equal(expectedArea, area, 1);
        }

        [Theory]
        [InlineData(-1, 4, 5)]
        [InlineData(3, 4, 10)]
        public void GetTriangleArea_InvalidDimensions_ShouldThrowArgumentException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.GetTriangleArea(a, b, c));
        }

        [Theory]
        [InlineData(5, Math.PI * 25)]
        public void GetCircleArea_ValidRadius_ShouldReturnCorrectArea(double radius, double expectedArea)
        {
            double area = AreaCalculator.GetCircleArea(radius);
            Assert.Equal(expectedArea, area, 1);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetCircleArea_InvalidRadius_ShouldThrowArgumentException(double radius)
        {
            Assert.Throws<ArgumentException>(() => AreaCalculator.GetCircleArea(radius));
        }
    }
}
