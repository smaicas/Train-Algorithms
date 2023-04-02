int value = int.Parse(Console.ReadLine());

Console.WriteLine(IsHappy(value));
Console.WriteLine(IsHappyRec(value, new List<int>()));

static bool IsHappy(int number)
{
    IEnumerable<char> digits = number.ToString().ToCharArray();

    List<int> results = new();
    while (true)
    {
        int last = digits.Select(x => (int)Math.Pow(int.Parse(x.ToString()), 2)).Sum();
        if (last == 1) return true;
        if (results.Contains(last)) return false;
        digits = last.ToString().ToCharArray();
        results.Add(last);
    }
}

static bool IsHappyRec(int number, List<int> res)
{
    if (res.Contains(number)) return false;
    if (number == 1) return true;

    int next = number.ToString().ToCharArray().Select(x => (int)Math.Pow(int.Parse(x.ToString()), 2)).Sum();
    res.Add(number);
    return IsHappyRec(next, res);
}