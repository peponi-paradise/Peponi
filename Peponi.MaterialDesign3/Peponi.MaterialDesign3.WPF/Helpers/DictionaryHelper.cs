namespace Peponi.MaterialDesign3.WPF;

public static class DictionaryHelper
{
    public static bool CheckResourceKeys(this System.Collections.ICollection keys, System.Windows.ResourceDictionary resource)
    {
        if (resource is null) return false;
        foreach (var key in keys)
        {
            if (key is null || !resource.Contains(key)) return false;
        }
        return true;
    }
}