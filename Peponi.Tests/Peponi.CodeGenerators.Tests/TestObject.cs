namespace TestNamespace;

public partial record MyModel
{
    public int _aaa;
}

public static class TestStaticModel
{
    public static double _double = 12;
}

public struct MyStruct
{
    public DateTime DateTime { get; set; }

    public static string Name;
}