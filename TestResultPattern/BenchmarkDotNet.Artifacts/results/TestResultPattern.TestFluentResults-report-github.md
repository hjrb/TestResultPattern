```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComplexSolutionPercentage | Mean         | Error     | StdDev    | Gen0   | Allocated |
|------------------------------------------ |----- |-------------------------- |-------------:|----------:|----------:|-------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                         |   **9,721.4 ns** | **176.50 ns** | **322.75 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                         |     617.8 ns |   2.74 ns |   2.57 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                         |     918.2 ns |   4.24 ns |   3.96 ns |      - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                         |   4,715.7 ns |  24.34 ns |  22.77 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0                         |   9,668.0 ns | 119.98 ns | 106.35 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                      |   **4,688.7 ns** |  **93.34 ns** | **107.49 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                      |     621.3 ns |   3.66 ns |   3.42 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                      |  27,350.0 ns | 248.09 ns | 219.92 ns | 0.1526 |    2400 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                      |   4,795.5 ns |  30.04 ns |  26.63 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.01                      |   2,902.5 ns |  12.82 ns |  11.99 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                       |   **4,840.5 ns** |  **90.83 ns** | **185.54 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                       |     704.6 ns |   9.22 ns |   7.70 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                       | 259,796.3 ns | 699.92 ns | 620.46 ns | 1.4648 |   24000 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                       |   4,765.5 ns |  31.11 ns |  29.10 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.1                       |   3,293.6 ns |  20.30 ns |  18.99 ns |      - |         - |
