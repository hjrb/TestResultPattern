```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | FailurePercentage | Mean         | Error       | StdDev    | Gen0    | Allocated |
|------------------------------------------ |----- |------------------ |-------------:|------------:|----------:|--------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                 |  **78,112.0 ns** |   **778.73 ns** | **728.43 ns** | **17.5781** |  **296000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                 |     883.8 ns |     3.87 ns |   3.43 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                 |   1,564.0 ns |     3.81 ns |   2.98 ns |       - |         - |
| BenchmarkQuadraticEquationUsingComplexe   | 1000 | 0                 |  12,207.5 ns |    33.17 ns |  25.89 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**              |  **82,392.1 ns** |   **740.27 ns** | **692.45 ns** | **17.5781** |  **297040 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01              |     950.5 ns |     2.57 ns |   2.28 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01              |  50,356.9 ns |   233.02 ns | 217.97 ns |  0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplexe   | 1000 | 0.01              |  12,302.4 ns |    64.41 ns |  57.10 ns |       - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**               |  **83,624.0 ns** |   **408.64 ns** | **341.24 ns** | **18.0664** |  **302960 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1               |     922.6 ns |     3.91 ns |   3.46 ns |       - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1               | 327,082.2 ns | 1,168.02 ns | 975.35 ns |  0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplexe   | 1000 | 0.1               |  12,265.4 ns |   172.39 ns | 161.26 ns |       - |         - |
