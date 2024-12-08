```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0    | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|--------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |  **75,155.8 ns** | **1,266.28 ns** | **1,184.48 ns** | **17.5781** |  **296000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     910.3 ns |    11.60 ns |    10.85 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   1,559.0 ns |    27.92 ns |    27.42 ns |       - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |  12,405.0 ns |   113.49 ns |   100.60 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |  **82,634.6 ns** | **1,609.17 ns** | **2,035.09 ns** | **17.5781** |  **297040 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     959.8 ns |     6.14 ns |     5.74 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  52,933.4 ns |   430.92 ns |   359.84 ns |  0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |  12,437.0 ns |    58.80 ns |    49.10 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |  **85,967.3 ns** | **1,586.27 ns** | **1,324.61 ns** | **18.0664** |  **302960 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     939.8 ns |     9.54 ns |     8.92 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 338,560.8 ns | 2,854.54 ns | 2,670.14 ns |  0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |  12,316.4 ns |    89.90 ns |    70.19 ns |       - |         - |
