namespace Peponi.SourceGenerators.SemanticTarget;

internal class MethodBase
{
    public string Name = string.Empty;
    public string ParameterType = string.Empty;
}

internal class CanExecuteTarget : MethodBase
{
    public CanExecuteTarget(string name, string parameterType)
    {
        Name = name;
        ParameterType = parameterType;
    }
}

internal class MethodTarget : MethodBase, IEquatable<MethodTarget?>
{
    public CanExecuteTarget? CanExecuteTarget;
    public string? CustomMethodName;
    public bool IsAsync;

    public MethodTarget(string name, string parameterType, bool isAsync, CanExecuteTarget? canExecuteTarget)
    {
        Name = name;
        ParameterType = parameterType;
        IsAsync = isAsync;
        CanExecuteTarget = canExecuteTarget;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MethodTarget);
    }

    public bool Equals(MethodTarget? other)
    {
        return other is not null &&
               Name == other.Name &&
               ParameterType == other.ParameterType &&
               EqualityComparer<CanExecuteTarget?>.Default.Equals(CanExecuteTarget, other.CanExecuteTarget) &&
               CustomMethodName == other.CustomMethodName &&
               IsAsync == other.IsAsync;
    }

    public override int GetHashCode()
    {
        int hashCode = -366949162;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ParameterType);
        hashCode = hashCode * -1521134295 + EqualityComparer<CanExecuteTarget?>.Default.GetHashCode(CanExecuteTarget);
        hashCode = hashCode * -1521134295 + EqualityComparer<string?>.Default.GetHashCode(CustomMethodName);
        hashCode = hashCode * -1521134295 + IsAsync.GetHashCode();
        return hashCode;
    }
}