```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK 9.0.101
  [Host] : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                | N    | ComplexSolutionPercentage | Mean | Error |
|-------------------------------------- |----- |-------------------------- |-----:|------:|
| BenchmarkQuadraticEquationUsingResult | 1000 | 0                         |   NA |    NA |

Benchmarks with issues:
  TestFluentResults.BenchmarkQuadraticEquationUsingResult: DefaultJob [N=1000, ComplexSolutionPercentage=0]
