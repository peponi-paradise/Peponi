namespace Peponi.CodeGenerators.SemanticTarget;

internal class MethodBase
{
    public string Name = string.Empty;
    public bool HasParameter;
    public bool IsAsync;
}

internal class MethodTarget : MethodBase, IEquatable<MethodTarget?>
{
    public CanExecuteTarget? CanExecuteTarget;

    public MethodTarget(string name, bool hasParameter, bool isAsync, CanExecuteTarget? canExecuteTarget)
    {
        Name = name;
        HasParameter = hasParameter;
        IsAsync = isAsync;
        CanExecuteTarget = canExecuteTarget;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as MethodTarget);
    }

    public bool Equals(MethodTarget? other)
    {
        return other is not null && Name == other.Name &&
                HasParameter == other.HasParameter && IsAsync == other.IsAsync &&
                CanExecuteTarget == other.CanExecuteTarget;
    }

    public override int GetHashCode()
    {
        return 4357 +
                EqualityComparer<string>.Default.GetHashCode(Name) +
                EqualityComparer<bool>.Default.GetHashCode(HasParameter) +
                EqualityComparer<bool>.Default.GetHashCode(IsAsync) +
                EqualityComparer<CanExecuteTarget?>.Default.GetHashCode(CanExecuteTarget);
    }
}

internal class CanExecuteTarget : MethodBase
{
    public CanExecuteTarget(string name, bool hasParameter, bool isAsync)
    {
        Name = name;
        HasParameter = hasParameter;
        IsAsync = isAsync;
    }
}