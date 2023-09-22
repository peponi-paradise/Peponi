namespace Peponi.CodeGenerators.SemanticTarget;

internal class MethodBase
{
    public string Name = string.Empty;
    public string ParameterType = string.Empty;
    public bool IsAsync;
}

internal class MethodTarget : MethodBase, IEquatable<MethodTarget?>
{
    public CanExecuteTarget? CanExecuteTarget;
    public string? CustomMethodName;

    public MethodTarget(string name, string parameterType, bool isAsync, CanExecuteTarget? canExecuteTarget)
    {
        Name = name;
        ParameterType = parameterType;
        IsAsync = isAsync;
        CanExecuteTarget = canExecuteTarget;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as MethodTarget);
    }

    public bool Equals(MethodTarget? other)
    {
        return other is not null && Name == other.Name && CustomMethodName == other.CustomMethodName &&
                ParameterType == other.ParameterType && IsAsync == other.IsAsync &&
                CanExecuteTarget == other.CanExecuteTarget;
    }

    public override int GetHashCode()
    {
        return 4357 +
                EqualityComparer<string>.Default.GetHashCode(Name) +
                EqualityComparer<string?>.Default.GetHashCode(CustomMethodName) +
                EqualityComparer<string>.Default.GetHashCode(ParameterType) +
                EqualityComparer<bool>.Default.GetHashCode(IsAsync) +
                EqualityComparer<CanExecuteTarget?>.Default.GetHashCode(CanExecuteTarget);
    }
}

internal class CanExecuteTarget : MethodBase
{
    public string? CustomArg;

    public CanExecuteTarget(string name, string parameterType, bool isAsync, string? customArg = null)
    {
        Name = name;
        ParameterType = parameterType;
        IsAsync = isAsync;
        CustomArg = customArg;
    }
}