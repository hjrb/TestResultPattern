```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i9-12900K, 1 CPU, 24 logical and 16 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                                    | N    | ComlexSolutionPercentage | Mean       | Error     | StdDev    | Median     | Gen0   | Allocated |
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
