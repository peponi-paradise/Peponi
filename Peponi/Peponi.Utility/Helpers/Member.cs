namespace Peponi.Utility.Helpers;

public static class MemberHelper
{
    public static void CopyAllFieldsAndProperties<T>(in T from, in T to) where T : class
    {
        foreach (var toInfo in to.GetType().GetFields())
        {
            foreach (var fromInfo in from.GetType().GetFields())
            {
                if (toInfo.Name == fromInfo.Name && toInfo.FieldType == fromInfo.FieldType)
                {
                    toInfo.SetValue(to, fromInfo.GetValue(from));
                    break;
                }
            }
        }
        foreach (var toInfo in to.GetType().GetProperties())
        {
            foreach (var fromInfo in from.GetType().GetProperties())
            {
                if (toInfo.Name == fromInfo.Name && toInfo.PropertyType == fromInfo.PropertyType)
                {
                    toInfo.SetValue(to, fromInfo.GetValue(from));
                    break;
                }
            }
        }
    }

    public static bool GetParameter<T>(string paramName, ref T paramValue, object dataObj)
    {
        foreach (var fieldInfo in dataObj.GetType().GetFields())
        {
            if (fieldInfo.Name == paramName && fieldInfo.FieldType == typeof(T))
            {
                paramValue = (T)Convert.ChangeType(fieldInfo.GetValue(dataObj), typeof(T))!;
                return true;
            }
        }
        foreach (var propertyInfo in dataObj.GetType().GetProperties())
        {
            if (propertyInfo.Name == paramName && propertyInfo.PropertyType == typeof(T))
            {
                paramValue = (T)Convert.ChangeType(propertyInfo.GetValue(dataObj), typeof(T))!;
                return true;
            }
        }
        return false;
    }

    public static bool SetParameter<T>(string paramName, T paramValue, object dataObj)
    {
        foreach (var fieldInfo in dataObj.GetType().GetFields())
        {
            if (fieldInfo.Name == paramName && fieldInfo.FieldType == typeof(T))
            {
                fieldInfo.SetValue(dataObj, paramValue);
                return true;
            }
        }
        foreach (var propertyInfo in dataObj.GetType().GetProperties())
        {
            if (propertyInfo.Name == paramName && propertyInfo.PropertyType == typeof(T))
            {
                propertyInfo.SetValue(dataObj, paramValue);
                return true;
            }
        }
        return false;
    }
}