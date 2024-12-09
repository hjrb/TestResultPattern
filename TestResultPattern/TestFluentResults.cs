using BenchmarkDotNet.Attributes;
using OneOf;
using OneOf.Types;

using System.Numerics;
using System.Runtime.CompilerServices;

namespace TestResultPattern;


[RPlotExporter] // for R plots
[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class TestFluentResults
{


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
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void BenchmarkQuadraticEquationUsingResult()
    {
        for (int i = 0; i < N; i++)
        {
            var input=data[i];
            var result = QuadraticEquation.SolveRealUsingResult(input.Item1, input.Item2, input.Item3);
            result.Switch(
                success => { var avg = (success.Item1 + success.Item2) / 2; },
                error => { failCounterResult++; }
            );
        }
    }

    public int failCounterBoolAndOut = 0;
    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void BenchmarkQuadraticEquationUsingBoolAndOut()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            var result = QuadraticEquation.SolveUsingBoolAndOut(input.Item1, input.Item2, input.Item3,out var x1, out var x2);
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
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void BenchmarkQuadraticEquationUsingException()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            try
            {
                var result=QuadraticEquation.SolveRealUsingException(input.Item1, input.Item2, input.Item3);
                var avg = (result.Item1 + result.Item2) / 2; // make sure the compiler does not optimize this away
            }
            catch (ArgumentOutOfRangeException x)
            {
                ++failCounterException; // make sure the compiler does not optimize this away
            }
        }
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void BenchmarkQuadraticEquationUsingComplex()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            var result = QuadraticEquation.SolveUsingComplex(input.Item1, input.Item2, input.Item3);
            var avg = (result.Item1.Real + result.Item2.Real) / 2;
        }
    }

    [Benchmark]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void BenchmarkQuadraticEquationUsingOneOf()
    {
        for (int i = 0; i < N; i++)
        {
            var input = data[i];
            var result = QuadraticEquation.Solve(input.Item1, input.Item2, input.Item3);
            var avg=result.Match(
                realResul => (realResul.Item1 + realResul.Item2) / 2,
                complexResult => (complexResult.Item1.Real + complexResult.Item2.Real) / 2
            );
            
        }
    }
}
