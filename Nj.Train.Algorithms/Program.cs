using Nj.Train.Algorithms;

// PRUEBAS ALGORITMOS ORDENACIÓN

//int[] arrToTest = { 4, 7, 3, 1, 8, 12, 6, 2, 7, 4, 8, 0 };

//Console.WriteLine(string.Join(",", Exercises.SortByInsertion(arrToTest)));

//arrToTest = new int[] { 4, 7, 3, 1, 8, 12, 6, 2, 7, 4, 8, 0 };
//Console.WriteLine(string.Join(",", Exercises.SortBySelection(arrToTest)));

//arrToTest = new int[] { 4, 7, 3, 1, 8, 12, 6, 2, 7, 4, 8, 0 };
//Console.WriteLine(string.Join(",", Exercises.SortByBubble(arrToTest)));

//arrToTest = new int[] { 4, 7, 3, 1, 8, 12, 6, 2, 7, 4, 8, 0 };
//Console.WriteLine(string.Join(",", Exercises.QuickSortExtremePivot(arrToTest, 0, arrToTest.Length - 1)));

//VariableSwap vs = new();
//vs.SwapValuesUsingOperations();

// BENCHMARKS

//BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<Exercises>();

//Console.ForegroundColor = ConsoleColor.Cyan;
//Console.WriteLine("Benchmark ended!. Press any key to close");
//Console.ResetColor();
//Console.ReadKey();

// CALCULO DE POTENCIA
Exercises ex = new();

Console.WriteLine(Environment.NewLine);
Console.WriteLine("n=0");
ex.Potencia2(2, 0);

Console.WriteLine(Environment.NewLine);
Console.WriteLine("n=5");
ex.Potencia2(2, 5);

Console.WriteLine(Environment.NewLine);
Console.WriteLine("n=10");
ex.Potencia2(2, 10);

Console.WriteLine(Environment.NewLine);
Console.WriteLine("n=15");
ex.Potencia2(2, 15);

Console.WriteLine(Environment.NewLine);
Console.WriteLine("n=20");
ex.Potencia2(2, 20);
Console.WriteLine(Environment.NewLine);

// 50 VALORES

//|                    Method |        Mean |     Error |     StdDev |      Median | Rank |   Gen0 | Allocated |
//|-------------------------- |------------:|----------:|-----------:|------------:|-----:|-------:|----------:|
//|              SortByBubble |    32.75 ns |  0.707 ns |   1.220 ns |    33.30 ns |    1 |      - |         - |
//|           SortByInsertion |    44.70 ns |  0.945 ns |   1.952 ns |    43.64 ns |    2 |      - |         - |
//|                  LinqSort |   286.99 ns |  5.731 ns |   9.416 ns |   285.39 ns |    3 | 0.0305 |     256 B |
//|  TestQuickSortMiddlePivot |   352.66 ns |  6.993 ns |   9.093 ns |   351.62 ns |    4 |      - |         - |
//|           SortBySelection | 1,162.84 ns | 15.413 ns |  13.663 ns | 1,162.37 ns |    5 |      - |         - |
//| TestQuickSortExtremePivot | 1,338.67 ns | 26.807 ns |  40.124 ns | 1,338.71 ns |    6 |      - |         - |
//|       TestQuickSortMedian | 4,777.81 ns | 94.193 ns | 164.972 ns | 4,791.63 ns |    7 | 0.4120 |    3472 B |

// 500 VALORES

//|                    Method |         Mean |       Error |      StdDev |       Median | Rank |   Gen0 | Allocated |
//|-------------------------- |-------------:|------------:|------------:|-------------:|-----:|-------:|----------:|
//|              SortByBubble |     249.0 ns |     5.03 ns |    10.94 ns |     243.4 ns |    1 |      - |         - |
//|           SortByInsertion |     606.9 ns |    12.06 ns |    24.09 ns |     594.8 ns |    2 |      - |         - |
//|                  LinqSort |   3,862.2 ns |    75.91 ns |   132.95 ns |   3,792.6 ns |    3 | 0.2441 |    2056 B |
//|  TestQuickSortMiddlePivot |   4,351.3 ns |    64.02 ns |    85.47 ns |   4,314.4 ns |    4 |      - |         - |
//|       TestQuickSortMedian |  42,054.7 ns |   838.91 ns | 1,823.72 ns |  41,417.9 ns |    5 | 3.4790 |   29344 B |
//| TestQuickSortExtremePivot |  92,600.7 ns | 1,764.45 ns | 1,473.40 ns |  92,096.2 ns |    6 |      - |         - |
//|           SortBySelection | 123,911.1 ns | 2,429.25 ns | 4,680.35 ns | 121,714.8 ns |    7 |      - |         - |