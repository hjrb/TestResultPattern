This repo demonstrates the effects to performance when using the Results pattern.

- It users C# as programming language.
- It references [https://github.com/altmann/FluentResults](https://github.com/mcintyre321/OneOf/) for an implementation of the Results pattern.
- Benchmarks are implemented using BenchmarkDotNet https://github.com/dotnet/BenchmarkDotNet
- It uses VS 2022 as development environment. But one can easily also use the dotnet cli and any test editor.
  
The task is to solve the quadratic equation 0 = a*x*x + b*x + c

With ```d=b*b - 4*a*c``` one gets two possible solutions ```x1=(-b+sqrt(d))/2a and x2=(-b-sqrt(d))/2a```, assuming a is not zero.

The general solution requires Complex number for the case that d<0.

Very often only then non complex solutions are of interest. So one would first compute d and check if it is less then zero.

In that case there are no real solutions.

This could be handled in the following ways:
1.) BenchmarkQuadraticEquationUsingBoolAndOut: Return a bool that indicates if real solutions exists and return the two solutions using ref parameters
2.) BenchmarkQuadraticEquationUsingResult: Return a Results object which is either an instance of Error (with an optional message) or an instance of Result<(double, double>).
3.) BenchmarkQuadraticEquationUsingException: Return a tuple (double, double) if d is >=0 or throw an argument exception.
4.) BenchmarkQuadraticEquationUsingComplex: Return a tuple (Complex, Complex) which will always work
5.) BenchmarkQuadraticEquationOneOf: Return a tuple (double,double) or (Complex, Complex) depending if a real solutions exists. This saves computing the complex square root

The test code allows to define N (the number of test) cases and the parameter ComplexSolutionPercentage. ComplexSolutionPercentage is the upper limit how man test inputs will yield a complex solution.

Here are some test results:
```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComplexSolutionPercentage | Mean       | Error     | StdDev    | Median     | Gen0   | Allocated |
|------------------------------------------ |----- |------------------------- |-----------:|----------:|----------:|-----------:|-------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |   **7.224 μs** | **0.1405 μs** | **0.1173 μs** |   **7.228 μs** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |   2.820 μs | 0.0138 μs | 0.0122 μs |   2.820 μs |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   2.952 μs | 0.0147 μs | 0.0123 μs |   2.951 μs |      - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |   7.188 μs | 0.1436 μs | 0.2477 μs |   7.304 μs |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0                        |   7.152 μs | 0.0607 μs | 0.0568 μs |   7.162 μs |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |   **7.971 μs** | **0.1593 μs** | **0.1705 μs** |   **8.004 μs** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |   2.854 μs | 0.0135 μs | 0.0126 μs |   2.857 μs |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  44.743 μs | 0.2147 μs | 0.1904 μs |  44.683 μs | 0.2441 |    4680 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |   7.132 μs | 0.0495 μs | 0.0438 μs |   7.122 μs |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.01                     |   7.994 μs | 0.0497 μs | 0.0465 μs |   7.982 μs |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |   **8.568 μs** | **0.1705 μs** | **0.1595 μs** |   **8.565 μs** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |   2.797 μs | 0.0087 μs | 0.0082 μs |   2.798 μs |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 284.535 μs | 1.6312 μs | 1.5258 μs | 284.861 μs | 1.9531 |   31320 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |   8.114 μs | 0.0555 μs | 0.0492 μs |   8.125 μs |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.1                      |   7.950 μs | 0.0542 μs | 0.0481 μs |   7.967 μs |      - |         - |
