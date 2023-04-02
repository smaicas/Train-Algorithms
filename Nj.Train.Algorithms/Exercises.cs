using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Nj.Train.Algorithms;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Exercises
{
    /// <summary>
    ///     Swap values using math operations (+,-,*,/)
    /// </summary>
    public Exercises()
    {
        List<int> list = new();
        Random rnd = new();
        for (int i = 0; i < 500; i++) list.Add(rnd.Next(0, 9999));
        ArrayToTest = list.ToArray();
    }

    public static int[]? ArrayToTest { get; set; }

    /// <summary>
    ///     Sort by Insertion
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    // Caso mejor: O(n)
    // Caso peor: O(n^2)
    [Benchmark]
    public int[]? SortByInsertion()
    {
        int[]? arr1 = ArrayToTest;
        int i;

        if (arr1 != null)
            for (i = 1; i < arr1.Length; i++)
            {
                int x = arr1[i];
                int j = i - 1;
                while (j >= 0 && arr1[j] > x)
                {
                    arr1[j + 1] = arr1[j];
                    j--;
                }

                arr1[j + 1] = x;
            }

        return arr1;
    }

    /// <summary>
    ///     Sort by Selection
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    // Caso mejor y peor: O(n^2)
    [Benchmark]
    public int[]? SortBySelection()
    {
        int[]? arr2 = ArrayToTest;

        int i;

        if (arr2 != null)
            for (i = 0; i < arr2.Length; i++)
            {
                int menor = i;
                int j;
                for (j = i + 1; j < arr2.Length; j++)
                {
                    if (arr2[j] < arr2[menor]) menor = j;

                    if (i == menor) continue;

                    (arr2[i], arr2[menor]) = (arr2[menor], arr2[i]);
                }
            }

        return arr2;
    }

    /// <summary>
    ///     Sort By Bubble method
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    // Caso mejor : O(n)
    // Caso peor: O(n^2)
    [Benchmark]
    public int[]? SortByBubble()
    {
        int[]? arr3 = ArrayToTest;

        int i = 0;
        bool mod = true;
        while (arr3 != null && i < arr3.Length - 1 && mod)
        {
            mod = false;
            int j;
            for (j = arr3.Length - 1; j > i; j--)
            {
                if (arr3[j] >= arr3[j - 1]) continue;

                (arr3[j], arr3[j - 1]) = (arr3[j - 1], arr3[j]);
                mod = true;
            }
        }

        return arr3;
    }

    /// <summary>
    ///     Quicksort estandar con pivote en el extremo -> O(n^2)
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    [Benchmark]
    public int[]? TestQuickSortExtremePivot()
    {
        int[]? arr4 = ArrayToTest;

        return QuickSortExtremePivot(arr4, 0, arr4!.Length - 1);
    }

    public static int[]? QuickSortExtremePivot(int[]? arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = PartitionExtremePivot(arr, left, right);
            QuickSortExtremePivot(arr, left, pivotIndex - 1);
            QuickSortExtremePivot(arr, pivotIndex + 1, right);
        }

        return arr;
    }

    private static int PartitionExtremePivot(int[]? arr, int left, int right)
    {
        if (arr != null)
        {
            int pivotValue = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
                if (arr[j] < pivotValue)
                {
                    i++;
                    Swap(arr, i, j);
                }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        return 0;
    }

    /// <summary>
    ///     Quicksort middle pivot.
    ///     This has the worst case when pivot correspond to lower value of the array to sort -> O(n^2) en ese caso
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    [Benchmark]
    public int[]? TestQuickSortMiddlePivot()
    {
        int[]? arr5 = ArrayToTest;

        if (arr5 != null) return QuickSortMiddlePivot(arr5, 0, arr5.Length - 1);
        return null;
    }

    public static int[]? QuickSortMiddlePivot(int[]? arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = PartitionMiddlePivot(arr, left, right);
            QuickSortMiddlePivot(arr, left, pivotIndex - 1);
            QuickSortMiddlePivot(arr, pivotIndex + 1, right);
        }

        return arr;
    }

    private static int PartitionMiddlePivot(int[]? arr, int left, int right)
    {
        // selecciona el elemento del medio como pivote
        int pivotIndex = (left + right) / 2;
        if (arr != null)
        {
            int pivotValue = arr[pivotIndex];

            // coloca el pivote al final del array
            Swap(arr, pivotIndex, right);

            // realiza el particionado
            int i = left;
            for (int j = left; j < right; j++)
                if (arr[j] < pivotValue)
                {
                    Swap(arr, i, j);
                    i++;
                }

            // coloca el pivote en su posición final
            Swap(arr, i, right);
            return i;
        }

        throw new InvalidOperationException();
    }

    /// <summary>
    ///     This implementation uses the median of 3 values of the array to calculate the pivot
    ///     that evades the worst case of the "middle pivot" implementation. -> O(n*logn)
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    [Benchmark]
    public int[] TestQuickSortMedian()
    {
        int[]? arr6 = ArrayToTest;

        return QuickSortMedian(arr6, 0, arr6.Length - 1);
    }

    private static int[]? QuickSortMedian(int[]? arr, int left, int right)
    {
        if (left < right)
        {
            int? pivotIndex = PartitionMedian(arr, left, right);
            QuickSortMedian(arr, left, (int)(pivotIndex - 1));
            QuickSortMedian(arr, (int)(pivotIndex + 1), right);
        }

        return arr;
    }

    private static int PartitionMedian(int[]? arr, int left, int right)
    {
        // elige la mediana de tres valores aleatorios como pivote
        int[] pivots = { left, (left + right) / 2, right };
        Shuffle(pivots);
        int pivotIndex = MedianOfThree(arr, pivots[0], pivots[1], pivots[2]);

        if (arr != null)
        {
            int pivotValue = arr[pivotIndex];

            // coloca el pivote al final del array
            Swap(arr, pivotIndex, right);

            // realiza el particionado
            int i = left;
            for (int j = left; j < right; j++)
                if (arr[j] < pivotValue)
                {
                    Swap(arr, i, j);
                    i++;
                }

            // coloca el pivote en su posición final
            Swap(arr, i, right);
            return i;
        }

        throw new ArgumentException();
    }

    private static void Shuffle(int[]? arr)
    {
        Random rand = new();
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            Swap(arr, i, j);
        }
    }

    private static int MedianOfThree(int[]? arr, int i, int j, int k)
    {
        if (arr[i] < arr[j])
        {
            if (arr[j] < arr[k])
                return j;
            if (arr[i] < arr[k])
                return k;
            return i;
        }

        if (arr[i] < arr[k])
            return i;
        if (arr[j] < arr[k])
            return k;
        return j;
    }

    [Benchmark]
    public int[]? LinqSort()
    {
        int[]? arr7 = ArrayToTest ?? throw new ArgumentNullException(nameof(ArrayToTest));
        arr7.ToList().Sort();
        return arr7;
    }

    private static void Swap(int[]? arr, int i, int j)
    {
        if (arr != null) (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    /// <summary>
    ///     Calculate pow -> O(logn)
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    public int Potencia2(int n, int m)
    {
        int p = 1;
        while (m > 0)
        {
            Console.Write("|");
            if (m % 2 != 0) p = p * n;
            m = m / 2;
            n = n * n;
        }

        return p;
    }
}