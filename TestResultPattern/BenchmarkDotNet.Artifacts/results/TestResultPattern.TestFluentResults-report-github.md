```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|-------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |   **9,593.5 ns** |    **65.00 ns** |    **54.28 ns** | **3.8147** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     890.8 ns |     4.10 ns |     3.83 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   1,542.1 ns |     4.33 ns |     3.38 ns |      - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |  12,449.1 ns |   182.62 ns |   161.88 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |   **6,508.3 ns** |   **122.41 ns** |   **120.22 ns** | **3.8223** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     967.1 ns |     8.14 ns |     6.80 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  51,127.6 ns |   585.51 ns |   519.04 ns | 0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |  12,431.4 ns |   141.62 ns |   125.54 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |   **6,849.5 ns** |   **135.61 ns** |   **190.10 ns** | **3.8223** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     923.4 ns |     3.94 ns |     3.29 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 328,193.3 ns | 2,823.63 ns | 2,641.23 ns | 0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |  12,665.3 ns |   201.93 ns |   179.01 ns |      - |         - |
