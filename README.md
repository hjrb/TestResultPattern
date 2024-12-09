This repo demonstrates the effects to performance when using the Results pattern.

- It users C# as programming language.
- It references [https://github.com/altmann/FluentResults](https://github.com/mcintyre321/OneOf/) for an implementation of the Results pattern.
- Benmarks are implemented using BenmarkDotNet https://github.com/dotnet/BenchmarkDotNet
- It uses VS 2022 as development evironment. But one can easily also use the dotnet cli and any test editor.
  
The task is to solve the quadratic equation 0 = a*x*x + b*x + c

With ```d=b*b - 4*a*c``` one gets two possible soultions ```x1=(-b+sqrt(d))/2a and x2=(-b-sqrt(d))/2a```, assuming a is not zero.

The genral soultion requires Complex number for the case that d<0.

Very often only then non complex solutions are of interest. So one would first compute d and check if it is less then zero.

In that case there are no real solutions.

This could be handled in the following ways:
1.) BenchmarkQuadraticEquationUsingBoolAndOut: Return a bool that indicates if real solutions exists and return the two solutions using ref parameters
2.) BenchmarkQuadraticEquationUsingResult: Return a Results object which is either an instance of Error (with an optional message) or an instance of Result<(double, double>).
3.) BenchmarkQuadraticEquationUsingException: Return a tuple (double, double) if d is >=0 or throw an argument exception.
4.) BenchmarkQuadraticEquationUsingComplex: Return a tuple (Complex, Complex) which will always work
5.) BenchmarkQuadraticEquationOneOf: Return a tuple (double,double) or (Complex, Complex) depind if real solutions exists. This saves computing the complex square root

The test code allows to define N (the number of test) cases and the parameter ComlexSolutionPercentage. ComlexSolutionPercentage is the upper limit how man test inputs will yield a complex solution.

Here are some test results:
```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0    | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|--------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |  **78,603.3 ns** | **1,492.77 ns** | **1,597.25 ns** | **17.5781** |  **296000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     904.2 ns |    18.00 ns |    25.82 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   1,584.2 ns |    16.17 ns |    15.12 ns |       - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |  12,145.9 ns |    35.29 ns |    29.47 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |  **85,330.9 ns** | **1,631.41 ns** | **1,602.26 ns** | **17.5781** |  **297040 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     957.5 ns |     8.07 ns |     7.15 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  51,227.8 ns |   783.93 ns |   733.29 ns |  0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |  12,376.9 ns |   152.80 ns |   142.92 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |  **89,740.4 ns** | **1,112.76 ns** |   **986.44 ns** | **18.0664** |  **302960 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     926.9 ns |     9.48 ns |     8.86 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 324,375.0 ns |   729.28 ns |   646.49 ns |  0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |  12,496.4 ns |   241.85 ns |   226.23 ns |       - |         - |

- BenchmarkQuadraticEquationUsingBoolAndOut: is by the far the most performant approach and does never require memory allocation but wil only solve the problem for non complex cases. If a caller does not evaluate the boolean return parameter wrong results might be used.
- BenchmarkQuadraticEquationUsingResult: allays requires memory allocation but has a pretty good performance. Depening on the use case the high memory allocation might cause performance issue or out of memory failures.
- BenchmarkQuadraticEquationUsingException: is a little slower if the number of cases that requires a complex solution is zero. But for e.g. 10% of the test cases yielding complex results the peformance is the worst.
- BenchmarkQuadraticEquationUsingComplex: works in all cases but requires extra handling logic by the caller.

