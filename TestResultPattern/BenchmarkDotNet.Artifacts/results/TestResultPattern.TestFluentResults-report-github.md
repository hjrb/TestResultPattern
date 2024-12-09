```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2454)
AMD Ryzen 5 5600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|-------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |   **9,489.0 ns** |   **144.47 ns** |   **128.07 ns** | **3.8147** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     891.5 ns |     6.77 ns |     6.00 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |   1,559.3 ns |    12.27 ns |    10.25 ns |      - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |  12,292.9 ns |    40.04 ns |    33.43 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0                        |  10,807.3 ns |    32.09 ns |    28.45 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |   **6,513.8 ns** |   **126.22 ns** |   **111.89 ns** | **3.8223** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     952.3 ns |     2.65 ns |     2.48 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  51,420.2 ns |   139.25 ns |   123.44 ns | 0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |  12,355.5 ns |    76.93 ns |    68.20 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.01                     |   4,930.5 ns |    29.97 ns |    26.56 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |   **6,744.9 ns** |   **134.57 ns** |   **188.64 ns** | **3.8223** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     920.1 ns |     5.79 ns |     5.13 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 344,907.3 ns | 6,726.91 ns | 8,980.23 ns | 0.9766 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |  12,602.2 ns |    95.78 ns |    79.98 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.1                      |   6,177.2 ns |    38.82 ns |    32.41 ns |      - |         - |
