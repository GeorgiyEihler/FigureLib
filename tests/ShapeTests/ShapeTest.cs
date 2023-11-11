using ShapesLib.Shapes;

namespace ShapeTests;

public class ShapeTest
{
    [Fact]
    public void Triangle_ValidSides_ShouldCreate()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.Equal(3, triangle.SideA);
        Assert.Equal(4, triangle.SideB);
        Assert.Equal(5, triangle.SideC);
    }

    [Theory]
    [InlineData(0, 4, 5)]
    [InlineData(3, -4, 5)]
    [InlineData(3, 4, 10)]
    public void Triangle_InvalidSides_ShouldThrowArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Fact]
    public void Triangle_GetArea_ShouldReturnCorrectValue()
    {
        var triangle = new Triangle(3, 4, 5);
        double expectedArea = 6;
        Assert.Equal(expectedArea, triangle.GetArea(), 1);
    }

    [Fact]
    public void Circle_ValidRadius_ShouldCreate()
    {
        var circle = new Circle(5);
        Assert.Equal(5, circle.Radius);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Circle_InvalidRadius_ShouldThrowArgumentException(double radius)
    {
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    [Fact]
    public void Circle_GetArea_ShouldReturnCorrectValue()
    {
        var circle = new Circle(5);
        double expectedArea = Math.PI * 25;
        Assert.Equal(expectedArea, circle.GetArea(), 1);
    }
}