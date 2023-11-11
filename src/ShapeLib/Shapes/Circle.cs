using ShapeLib.Contract;

namespace ShapesLib.Shapes;

public class Circle : IShape
{
    public double Radius { get; init; }
    public Circle(double radius)
    {
        if (!CheckChape(radius))
        {
            throw new ArgumentException("Incorrect radius value.");
        }

        Radius = radius;
    }

    public static bool CheckChape(double radius) =>
       radius > 0;

    public double GetArea() =>
        Math.Pow(Radius, 2) * Math.PI;
}