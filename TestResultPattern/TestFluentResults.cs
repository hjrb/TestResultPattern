using BenchmarkDotNet.Attributes;

using FluentResults;

using Perfolizer.Mathematics.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestResultPattern
{
    [RPlotExporter]
    [HtmlExporter]
    [MemoryDiagnoser]
    [KeepBenchmarkFiles]
    public class TestFluentResults
    {
        public static Result<(double,double)> QuadraticEquationUsingResult(double a, double b, double c)
        {
            double delta = (b * b) - (4 * a * c);
            if (delta < 0)
            {
                return Result.Fail<(double,double)>("This equation has only complex solutions");
            }
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return Result.Ok((x1,x2));
        }
        public static (double, double) QuadraticEquationUsingException(double a, double b, double c)
        {
            double delta = (b * b) - (4 * a * c);
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("This equation has only complex solutions");
            }
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return (x1, x2);
        }

        (double,double, double)[] data=[];
        [Params(1000, 10000)]
        public int N;
        [Params(0.01, 0.1)]
        public double FailurePercentage;

        [GlobalSetup]
        public void Setup()
        {
            // produce random data using a fixed seed
            var random = new Random(42);
            data = new (double,double,double)[N];
            for (int i = 0; i < N; i++)
            {
                // make at least 90% of the equations solvable
                var makeSolveable = random.NextDouble() <= FailurePercentage;
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

        int failCounterResult = 0;
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
                }
            }
        }

        int failCounterException = 0;
        [Benchmark]
        public void BenchmarkQuadraticEquationUsingException()
        {
            for (int i = 0; i < N; i++)
            {
                var input = data[i];
                try
                {
                    var result=QuadraticEquationUsingException(input.Item1, input.Item2, input.Item3);
                }
                catch (ArgumentOutOfRangeException)
                {
                    ++failCounterException;
                }
            }
        }
    }
}
