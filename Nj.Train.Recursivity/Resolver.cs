namespace Nj.Train.Recursivity;

public class Resolver
{
    /// <summary>
    ///     Sumar los números números naturales hasta N (se lo damos nosotros) de forma recursiva.
    /// </summary>
    /// <returns></returns>
    public void Exercise1()
    {
        const int n = 10;
        Console.WriteLine(Sumar(n));
    }

    private int Sumar(int n)
    {
        if (n < 0) throw new ArgumentException(nameof(n));
        if (n > 0) return n + Sumar(n - 1);
        return 0;
    }

    /// <summary>
    ///     Factorial de un número.
    /// </summary>
    public void Exercise2()
    {
        const int n = 10;
        Console.WriteLine($"Factorial de {n} : {Factorial(n)}");
    }

    private int Factorial(int n)
    {
        if (n < 0) throw new ArgumentException(nameof(n));
        if (n > 0) return n * Factorial(n - 1);
        return 1;
    }

    /// <summary>
    ///     Recorrer un array de forma recursiva.
    /// </summary>
    public void Exercise3()
    {
        Console.WriteLine($"Sumatorio de array: {SumArray(new[] { 1, 2, 3, 4 })}");
        Console.WriteLine($"Sumatorio de array: {SumArray(new[] { 1, 2, 3, 4 })}", 0);
    }

    private int SumArray(int[] arr)
    {
        if (arr.Length > 0) return arr[0] + SumArray(arr.Skip(1).Take(arr.Length).ToArray());

        return 0;
    }

    private int SumArray(int[] arr, int n)
    {
        if (n < arr.Length) return arr[n] + SumArray(arr, n + 1);

        return 0;
    }

    /// <summary>
    ///     Buscar un elemento de un array de forma recursiva.
    /// </summary>
    public void Exercise4() => Console.WriteLine($"Busqueda: {SearchIndex(new[] { 1, 2, 3, 4 }, 3, 0)}");

    private int SearchIndex(int[] ints, int num, int index)
    {
        if (index > ints.Length - 1) return -1;

        if (ints[index] == num) return index;

        return SearchIndex(ints, num, index + 1);
    }

    /// <summary>
    ///     Pintar matrix
    /// </summary>
    public void Exercise5()
    {
        Console.WriteLine("Recorrer Matriz :");
        WriteMatrix(new[,] { { 1, 2, 3 }, { 4, 5, 6 } }, 0, 0);
    }

    private void WriteMatrix(int[,] ints, int row, int col)
    {
        if (col < ints.GetLength(1) && row < ints.GetLength(0))
        {
            Console.Write(ints[row, col]);
            col++;
            if (col + 1 > ints.GetLength(1))
            {
                col = 0;
                row++;
                Console.Write(Environment.NewLine);
            }

            WriteMatrix(ints, row, col);
        }
    }

    /// <summary>
    ///     Sumatorio de árbol y sumatorio hojas del árbol
    /// </summary>
    public void Exercise6()
    {
        LuisNode n1 = new(10);
        LuisNode n2 = new(5);
        LuisNode n3 = new(15);
        LuisNode n4 = new(20);
        LuisNode n5 = new(25);
        LuisNode n6 = new(5);
        LuisNode n7 = new(30);
        LuisNode n8 = new(20);
        LuisNode n9 = new(15);
        LuisNode n10 = new(10);
        LuisNode n11 = new(50);
        n1.Childs = new List<LuisNode> { n11, n2 };
        n2.Childs = new List<LuisNode> { n3, n4 };
        n3.Childs = new List<LuisNode> { n5, n6 };
        n4.Childs = new List<LuisNode> { n7, n8 };
        n5.Childs = new List<LuisNode> { n9, n10 };

        Console.WriteLine($"Sum tree: {SumTree(n1)}");
        Console.WriteLine($"Sum tree: {SumLeafs(n1)}");
    }

    private static int SumTree(LuisNode n1) => n1.Value + n1.Childs.Sum(SumTree);

    private static int SumLeafs(LuisNode n1) => n1.Childs.Count == 0 ? n1.Value : n1.Childs.Sum(SumLeafs);

    /// <summary>
    ///     Buscar el máximo en un array
    ///     Escribe una función recursiva que encuentre el valor máximo en un array de enteros.
    /// </summary>
    public void Exercise7()
    {
        Console.WriteLine($"Maximo: {Maximo(new[] { 5, 2, 8, 4, 0, 1, 7, 6 }, 0, 0)}");
        Console.WriteLine($"Maximo Sadow: {MaximoSadow(new[] { 5, 2, 8, 4, 0, 1, 7, 6 }, 0)}");
    }

    private int Maximo(int[] ints, int index, int max)
    {
        if (index == ints.Length - 1) return ints[max];

        if (ints[index] > ints[max]) max = index;
        //return num=array[i]>Maximo(array, i+1)?array[i]:Maximo(array, i+1)
        return Maximo(ints, index + 1, max);
    }

    private int MaximoSadow(int[] ints, int index)
    {
        if (index >= ints.Length - 1) return ints[index];
        return ints[index] >
               MaximoSadow(ints,
                   index + 1)
            ? ints[index]
            : MaximoSadow(ints,
                index + 1);
    }

    /// <summary>
    ///     Ordenar un array
    ///     Escribe una función recursiva que ordene un array de enteros en orden ascendente o descendente.
    /// </summary>
    public void Exercise8() => Console.WriteLine($"Ordenado: {string.Join(",", Ordenar(new[] { 5, 2, 8, 4, 0, 1, 7, 6 }, 0))}");

    private int[] Ordenar(int[] ints, int index)
    {
        for (int i = 0; i < ints.Length - 1; i++)
            if (ints[i] > ints[i + 1])
                (ints[i], ints[i + 1]) = (ints[i + 1], ints[i]);

        return index < ints.LongLength ? Ordenar(ints, index + 1) : ints;
    }

    /// <summary>
    ///     Búsqueda binaria en un array ordenado
    ///     Escribe una función recursiva que busque un elemento en un array ordenado de enteros utilizando el algoritmo de
    ///     búsqueda binaria.
    /// </summary>
    public void Exercise9() => Console.WriteLine(SearchBinary(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2));

    private int SearchBinary(int[] ints, int i)
    {
        if (ints.Length == 1) return -1;
        int mid = ints[ints.Length / 2];
        if (i == mid) return ints.Length / 2;

        if (i < mid) return SearchBinary(ints.Take(ints.Length / 2).ToArray(), i);
        return ints.Length / 2 + SearchBinary(ints.Skip(ints.Length / 2).Take(ints.Length / 2 + 1).ToArray(), i);
    }
}