```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0    | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|--------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |  **75,639.8 ns** |   **731.39 ns** |   **648.36 ns** | **17.5781** |  **296000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     888.9 ns |     6.51 ns |     5.77 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   1,569.3 ns |    31.19 ns |    32.03 ns |       - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |  12,498.3 ns |   131.03 ns |   116.15 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |  **82,041.6 ns** |   **726.14 ns** |   **606.36 ns** | **17.7002** |  **297040 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     968.6 ns |    13.12 ns |    11.63 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  51,765.7 ns |   551.15 ns |   460.24 ns |  0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |  12,541.4 ns |   141.30 ns |   110.32 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |  **93,667.3 ns** | **1,857.65 ns** | **2,999.76 ns** | **18.0664** |  **302960 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     954.2 ns |    16.04 ns |    15.00 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 340,249.0 ns | 2,592.25 ns | 2,297.96 ns |  0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |  12,792.5 ns |   109.92 ns |    97.44 ns |       - |         - |
