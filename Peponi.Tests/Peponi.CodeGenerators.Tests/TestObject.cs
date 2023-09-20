namespace TestNamespace;

public partial record MyModel
{
    public int _aaa;
}

public static class TestStaticModel
{
    public static double _double = 12;
    private static string _string = string.Empty;
    public static bool _bool = false;

    public delegate int TestEventHandler();

    public static event TestEventHandler _ewrt;
}

public struct MyStruct
{
    public DateTime DateTime { get; set; }

    public static string Name = string.Empty;
}