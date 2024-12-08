﻿using BenchmarkDotNet.Attributes;

using FluentResults;

using System.Numerics;


namespace TestResultPattern;

[RPlotExporter]
[HtmlExporter]
[MemoryDiagnoser]
[KeepBenchmarkFiles]
public class TestFluentResults
{
    public static bool QuadraticEquationUsingBoolAndOut(double a, double b, double c, ref double x1, ref double x2)
    {
        double delta = (b * b) - (4 * a * c);
        if (delta < 0)
        {
            return false;
        }
        var x = Math.Sqrt(delta);
        var a2 = 2 * a;
        x1 = (-b + x) / a2;
        x2 = (-b - x) / a2;
        return true;
    }

    public static Result<(double,double)> QuadraticEquationUsingResult(double a, double b, double c)
    {
        double delta = (b * b) - (4 * a * c);
        if (delta < 0)
        {
            return Result.Fail<(double,double)>("This equation has only complex solutions");
        }
        var x = Math.Sqrt(delta);
        var a2 = 2 * a;
        double x1 = (-b + x) / a2;
        double x2 = (-b - x) / a2;
        return Result.Ok((x1,x2));
    }

    public static (double, double) QuadraticEquationUsingException(double a, double b, double c)
    {
        double delta = (b * b) - (4 * a * c);
        if (delta < 0)
        {
            throw new ArgumentOutOfRangeException("This equation has only complex solutions");
        }
        var x = Math.Sqrt(delta);
        var a2 = 2 * a;
        double x1 = (-b + x) / a2;
        double x2 = (-b - x) / a2;
        return (x1, x2);
    }

    public static (Complex, Complex) QuadraticEquationUsingComplex(double a, double b, double c)
    {
        var x = Complex.Sqrt((b * b) - (4 * a * c));        
        var a2 = 2 * a;
        var x1 = (-b + x) / a2;
        var x2 = (-b - x) / a2;
        return (x1,x2);
    }


    (double,double, double)[] data=[];
    [Params(1000)]
    public int N;
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
            // make at least 90% of the equations solvable
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
            if (result.IsFailed)
            {
                failCounterResult++;
                continue;
            }
            var avg = (result.Value.Item1 + result.Value.Item2) / 2;
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
                failCounterBoolAndOut++;
                continue;
            }
            var avg = (x1 + x2) / 2;
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
                var avg = (result.Item1 + result.Item2) / 2;
            }
            catch (ArgumentOutOfRangeException x)
            {
                ++failCounterException;
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

}
