namespace TestNamespace;

public partial record MyModel
{
    public int _aaa;

    public double _bbb
    {
        get; set;
    }

    public static string _star = string.Empty;
}

public static class TestStaticModel
{
    public static double _double = 12;
    private static string _string = string.Empty;
    public static bool _bool = false;

    public static bool _boolGetter
    {
        get => _bool;
    }

    public delegate int TestEventHandler();

    public static event TestEventHandler? Ewrt;
}

public struct MyStruct
{
    public DateTime DateTime { get; set; }

    public static string Name = string.Empty;
}