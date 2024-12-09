using OneOf;
using OneOf.Types;

using System.Numerics;

namespace TestResultPattern;
public class QuadraticEquation
{
    /// <summary>
    /// internal helper function to compute the real solutions of a quadratic equation
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="x1"></param>
    /// <param name="x2"></param>
    /// <returns></returns>
    private static bool ComputeX1X2(double a, double b, double c, out double x1, out double x2)
    {
        var delta = (b * b) - (4 * a * c);
        if (delta < 0)
        {
            x1 = x2 = 0;
            return false;
        }
        var x = Math.Sqrt(delta);
        var a2 = 2 * a;
        x1 = (-b + x) / a2;
        x2 = (-b - x) / a2;
        return true;
    }

    /// <summary>
    /// solve the quadratic equation and retourn the result using out parameters
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <param name="x1">the first real solution, only valid if the return value is true</param>
    /// <param name="x2">the second real solution, only valid if the return value is true</param>
    /// <returns>true if a real solution exists else false</returns>
    public static bool SolveUsingBoolAndOut(double a, double b, double c, out double x1, out double x2) 
        => ComputeX1X2(a, b, c, out x1, out x2);

    /// <summary>
    /// solve the quadratic equation and return the result using a Result object
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns>a Result object</returns>
    public static OneOf<(double, double), Error<string>> SolveRealUsingResult(double a, double b, double c) 
        => !ComputeX1X2(a, b, c, out var x1, out var x2)
            ? new Error<string>("This equation has only complex solutions")
            : (x1, x2);

    /// <summary>
    /// solve the quadratic equation and return the result as tuple. in the case there a no real solutions throw and ArgumentOutOfRangeException
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns>a tuple with the results</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static (double, double) SolveRealUsingException(double a, double b, double c) 
        => !ComputeX1X2(a, b, c, out var x1, out var x2)
            ? throw new ArgumentOutOfRangeException("This equation has only complex solutions")
            : (x1, x2);

    /// <summary>
    /// compute the result of a quadratic equation using complex numbers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns>a tuple with the results</returns>
    public static (Complex, Complex) SolveUsingComplex(double a, double b, double c)
    {
        var x = Complex.Sqrt((b * b) - (4 * a * c));        
        var a2 = 2 * a;
        return ((-b + x) / a2, (-b - x) / a2);
    }


    /// <summary>
    /// depending on the value of the discriminant return the real or complex solutions
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static OneOf<(double, double), (Complex, Complex)> Solve(double a, double b, double c)
    {
        var a2 = 2 * a;
        var d = (b * b) - (4 * a * c);
        if (d < 0)
        {
            var x = Complex.Sqrt(d);
            return ((-b + x) / a2, (-b - x) / a2);
        }
        else
        {
            var x = Math.Sqrt(d);
            return ((-b + x) / a2, (-b - x) / a2);
        }
    }


    
}
