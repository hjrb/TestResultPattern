```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean         | Error       | StdDev      | Gen0   | Allocated |
|------------------------------------------ |----- |------------------------- |-------------:|------------:|------------:|-------:|----------:|
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0**                        |  **10,220.0 ns** |   **201.31 ns** |   **341.84 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0                        |     621.4 ns |     2.75 ns |     2.30 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0                        |     905.4 ns |     3.18 ns |     2.82 ns |      - |         - |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0                        |   6,552.8 ns |    20.11 ns |    18.81 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0                        |   9,246.9 ns |    53.58 ns |    50.11 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.01**                     |   **4,904.7 ns** |    **60.31 ns** |    **50.36 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.01                     |     650.0 ns |     2.82 ns |     2.50 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.01                     |  34,951.7 ns |   236.65 ns |   221.37 ns | 0.1831 |    3120 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.01                     |   6,663.1 ns |   101.59 ns |   108.70 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.01                     |   2,968.7 ns |    15.21 ns |    14.23 ns |      - |         - |
| **BenchmarkQuadraticEquationUsingResult**     | **1000** | **0.1**                      |   **5,388.7 ns** |   **107.14 ns** |   **206.43 ns** | **4.0741** |   **64000 B** |
| BenchmarkQuadraticEquationUsingBoolAndOut | 1000 | 0.1                      |     631.8 ns |     8.30 ns |     7.77 ns |      - |         - |
| BenchmarkQuadraticEquationUsingException  | 1000 | 0.1                      | 230,297.2 ns | 2,467.18 ns | 2,307.80 ns | 1.2207 |   20880 B |
| BenchmarkQuadraticEquationUsingComplex    | 1000 | 0.1                      |   7,006.7 ns |    44.07 ns |    41.22 ns |      - |         - |
| BenchmarkQuadraticEquationUsingOneOf      | 1000 | 0.1                      |   3,522.3 ns |    14.07 ns |    13.16 ns |      - |         - |
