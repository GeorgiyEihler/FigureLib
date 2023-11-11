using ShapeLib.Contract;
using ShapesLib.Shapes;

namespace ShapeLib.Infrastructure;

public static class AreaCalculator
{
    public static double GetArea(IShape shape) =>
        shape.GetArea();

    public static double GetTriangleArea(double sideA, double sideB, double sideC) =>
        new Triangle(sideA, sideB, sideC).GetArea();

    public static double GetCircleArea(double radius) =>
        new Circle(radius).GetArea();
}
