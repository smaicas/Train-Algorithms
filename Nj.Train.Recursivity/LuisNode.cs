namespace Nj.Train.Recursivity;

public class LuisNode
{
    public LuisNode(int value) => Value = value;

    public int Value { get; set; }
    public List<LuisNode> Childs { get; set; } = new();
}