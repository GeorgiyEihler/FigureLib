using ShapeLib.Contract;

namespace ShapesLib.Shapes;

public class Triangle : IShape
{
    public double SideA { get; init; }
    public double SideB { get; init; }
    public double SideC { get; init; }

    public Triangle(double sideA, double sideB, double sideC)
    {

        if (!CheckShape(sideA, sideB, sideC))
        {
            throw new ArgumentException("Side lengths do not adhere to the triangle inequality theorem.");
        }

        (SideA, SideB, SideC) = (sideA, sideB, sideC);
    }

    public static bool IsRightTriangle(Triangle traingle)
    {
        var max = new[] { traingle.SideA, traingle.SideB, traingle.SideC }.OrderByDescending(x => x).ToArray();
        return Math.Pow(max[0], 2) == Math.Pow(max[1], 2) + Math.Pow(max[2], 2);
    }

    public static bool CheckShape(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            return false;
        }

        if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
        {
            return false;
        }

        return true;
    }
   
    public double GetArea()
    {
        var halfPerimetr = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(halfPerimetr * (halfPerimetr - SideA) * (halfPerimetr - SideB) * (halfPerimetr - SideC));
    }
}