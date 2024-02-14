using System.Windows;
using System.Windows.Media;

namespace Peponi.MaterialDesign3.WPF.Colors;

public class Indexer
{
    public ResourceDictionary Resource => _resource;
    private readonly ResourceDictionary _resource;

    public Indexer(ResourceDictionary resource)
    {
        _resource = resource;
    }

    /// <summary>
    /// Gets or Sets <see cref="Color"/>, <see cref="SolidColorBrush"/> by given key<br/>
    /// Default keys are defined on <see cref="MaterialColor"/>, <see cref="MaterialBrush"/>
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public object this[string key]
    {
        get
        {
            if (_resource.Contains($"{key}"))
            {
                if (_resource[key] is Color || _resource[key] is SolidColorBrush) return _resource[$"{key}"];
                else throw new InvalidOperationException($"{key} is not Color or SolidColorBrush");
            }
            else throw new ArgumentException($"{key} is not exist in resource");
        }
        set
        {
            _resource![$"{key}"] = value;
        }
    }
}