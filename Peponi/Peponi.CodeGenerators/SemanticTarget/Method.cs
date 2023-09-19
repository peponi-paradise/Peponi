using System.Collections.Immutable;

namespace Peponi.CodeGenerators.SemanticTarget;

internal class MethodBase
{
    public string Name = string.Empty;
    public string Parameter = string.Empty;
    public bool IsAsync;
}

internal class MethodTarget : MethodBase, IEquatable<MethodTarget?>
{
    public CanExecuteTarget? CanExecuteTarget;

    public MethodTarget(string name, string parameter, bool isAsync, CanExecuteTarget? canExecuteTarget)
    {
        Name = name;
        Parameter = parameter;
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
                Parameter == other.Parameter && IsAsync == other.IsAsync &&
                CanExecuteTarget == other.CanExecuteTarget;
    }

    public override int GetHashCode()
    {
        return 4357 +
                EqualityComparer<string>.Default.GetHashCode(Name) +
                EqualityComparer<string>.Default.GetHashCode(Parameter) +
                EqualityComparer<bool>.Default.GetHashCode(IsAsync) +
                EqualityComparer<CanExecuteTarget?>.Default.GetHashCode(CanExecuteTarget);
    }
}

internal class CanExecuteTarget : MethodBase
{
    public CanExecuteTarget(string name, string parameter, bool isAsync)
    {
        Name = name;
        Parameter = parameter;
        IsAsync = isAsync;
    }
}