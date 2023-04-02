namespace Nj.Train.Algorithms;

public class VariableSwap
{
    public void SwapValuesUsingOperations()
    {
        Random rnd = new();

        for (int i = 0; i < 100; i++)
        {
            int a = rnd.Next(1, 9999);
            int b = rnd.Next(1, 9999);

            int x = a;
            int y = b;

            y = x * y;
            x = y / x;
            y = y / x;

            Console.WriteLine(a == y);
            Console.WriteLine(b == x);
        }

        for (int i = 0; i < 100; i++)
        {
            int a = rnd.Next(1, 9999);
            int b = rnd.Next(1, 9999);

            int x = a;
            int y = b;

            y = x + y;
            x = y - x;
            y = y - x;

            Console.WriteLine(a == y);
            Console.WriteLine(b == x);
        }

        for (int i = 0; i < 100; i++)
        {
            int a = rnd.Next(1, 9999);
            int b = rnd.Next(1, 9999);

            int x = a;
            int y = b;

            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine(a == y);
            Console.WriteLine(b == x);
        }
    }
}