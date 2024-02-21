namespace Peponi.Core.DesignPattern;

public class Singleton<T> where T : class, new()
{
    private static readonly Lazy<T> _lazy = new(() => new T());

    /// <summary>
    /// Singleton instance
    /// </summary>
    public static T Instance => _lazy.Value;
}