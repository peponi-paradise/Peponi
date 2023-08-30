namespace Peponi.Core.DesignPattern;

public class Singleton<T> where T : class, new()
{
    private static readonly Lazy<T> _lazy = new(() => new T());

    public static T Instance => _lazy.Value;
}