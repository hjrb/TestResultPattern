using BenchmarkDotNet.Attributes;
using OneOf;
using OneOf.Types;

using System.Numerics;

namespace TestResultPattern;


[RPlotExporter] // for R plots
[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class TestFluentResults
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
    public static bool QuadraticEquationUsingBoolAndOut(double a, double b, double c, ref double x1, ref double x2) 
        => ComputeX1X2(a, b, c, out x1, out x2);

    /// <summary>
    /// solve the quadratic equation and return the result using a Result object
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns>a Result object</returns>
    public static OneOf<(double, double), Error<string>> QuadraticEquationUsingResult(double a, double b, double c) 
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
    public static (double, double) QuadraticEquationUsingException(double a, double b, double c) 
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
    public static (Complex, Complex) QuadraticEquationUsingComplex(double a, double b, double c)
    {
        var x = Complex.Sqrt((b * b) - (4 * a * c));        
        var a2 = 2 * a;
        var x1 = (-b + x) / a2;
        var x2 = (-b - x) / a2;
        return (x1,x2);
    }

    public static OneOf<(double, double), (Complex, Complex)> QuadraticEquationUsingOneOf(double a, double b, double c)
    {
        var d = (b * b) - (4 * a * c);
        if (d < 0)
        {
            var x = Complex.Sqrt(d);
            var a2 = 2 * a;
            var x1 = (-b + x) / a2;
            var x2 = (-b - x) / a2;
            return (x1, x2);
        }
        else
        {
            var x = Math.Sqrt(d);
            var a2 = 2 * a;
            var x1 = (-b + x) / a2;
            var x2 = (-b - x) / a2;
            return (x1, x2);
        }
    }


    // the data for the benchmarks
    private (double,double, double)[] data=[];

    /// <summary>
    /// the number of equations to solve
    /// </summary>
    [Params(1000)]
    public int N;

    /// <summary>
    /// the maximum percentage of equations with complex solutions
    /// </summary>
    [Params(0.0, 0.01, 0.1)]
    public double ComlexSolutionPercentage;

    [GlobalSetup]
    public void Setup()
    {
        // produce random data using a fixed seed
        var random = new Random(42);
        data = new (double,double,double)[N];
        for (int i = 0; i < N; i++)
        {
            // make sure that the equation is solvable
            var makeSolveable = random.NextDouble() > ComlexSolutionPercentage;
            double a, b, c, delta;
            do
            {
                a = random.NextDouble();
                b = random.NextDouble();
                c = random.NextDouble();
                delta = (b * b) - (4 * a * c);
            } while (makeSolveable && delta < 0);
            data[i] = (a, b, c);
        }
    }

    public int failCounterResult = 0;
    [Benchmark]
    public void BenchmarkQuadraticEquationUsingResult()
    {
        for (int i = 0; i < N; i++)
        {
            var input=data[i];
            var result = QuadraticEquationUsingResult(input.Item1, input.Item2, input.Item3);
            result.Switch(
                success => { var avg = (success.Item1 + success.Item2) / 2; },
                error => { failCounterResult++; }
            );
        }
    }

    public int failCounterBoolAndOut = 0;
    [Benchmark]
    public void BenchmarkQuadraticEquationUsingBoolAndOut()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            double x1=0.0, x2=0.0;
            var result = QuadraticEquationUsingBoolAndOut(input.Item1, input.Item2, input.Item3,ref x1, ref x2);
            if (!result)
            {
                failCounterBoolAndOut++; // make sure the compiler does not optimize this away
                continue;
            }
            var avg = (x1 + x2) / 2; // make sure the compiler does not optimize this away
        }
    }


    public int failCounterException = 0;
    [Benchmark]
    public void BenchmarkQuadraticEquationUsingException()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            try
            {
                var result=QuadraticEquationUsingException(input.Item1, input.Item2, input.Item3);
                var avg = (result.Item1 + result.Item2) / 2; // make sure the compiler does not optimize this away
            }
            catch (ArgumentOutOfRangeException x)
            {
                ++failCounterException; // make sure the compiler does not optimize this away
            }
        }
    }

    [Benchmark]
    public void BenchmarkQuadraticEquationUsingComplex()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            var result = QuadraticEquationUsingComplex(input.Item1, input.Item2, input.Item3);
            var avg = (result.Item1 + result.Item2) / 2;
        }
    }

    [Benchmark]
    public void BenchmarkQuadraticEquationUsingOneOf()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            var result = QuadraticEquationUsingOneOf(input.Item1, input.Item2, input.Item3);
            var avg=result.Match(
                realResul => (realResul.Item1 + realResul.Item2) / 2,
                complexResult => (complexResult.Item1 + complexResult.Item2) / 2
            );
            
        }
    }
}
