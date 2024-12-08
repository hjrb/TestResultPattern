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
