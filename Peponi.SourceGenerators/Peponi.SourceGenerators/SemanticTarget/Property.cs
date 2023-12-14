namespace Peponi.SourceGenerators.SemanticTarget;

internal class PropertyTarget : IEquatable<PropertyTarget?>
{
    public string FieldName;
    public string PropertyName;
    public string Type;
    public bool IsReadOnly;
    public bool IsStatic;
    public NotifyType NotifyType;
    public List<PropertyMethodCallTarget> PropertyMethods;
    public List<CanExecuteChangedTarget> CanExecuteChangedTargets;
    public List<RaisePropertyChangedTarget> RaisePropertyChangedTargets;

    public PropertyTarget(string fieldName, string propertyName, string type, bool isReadOnly, bool isStatic, NotifyType notifyType, List<PropertyMethodCallTarget> propertyMethods, List<CanExecuteChangedTarget> canExecuteTargets, List<RaisePropertyChangedTarget> raisePropertyChangedTargets)
    {
        FieldName = fieldName;
        PropertyName = propertyName;
        Type = type;
        IsReadOnly = isReadOnly;
        IsStatic = isStatic;
        NotifyType = notifyType;
        PropertyMethods = propertyMethods;
        CanExecuteChangedTargets = canExecuteTargets;
        RaisePropertyChangedTargets = raisePropertyChangedTargets;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PropertyTarget);
    }

    public bool Equals(PropertyTarget? other)
    {
        return other is not null &&
               FieldName == other.FieldName &&
               PropertyName == other.PropertyName &&
               Type == other.Type &&
               IsReadOnly == other.IsReadOnly &&
               IsStatic == other.IsStatic &&
               NotifyType == other.NotifyType &&
               EqualityComparer<List<PropertyMethodCallTarget>>.Default.Equals(PropertyMethods, other.PropertyMethods) &&
               EqualityComparer<List<CanExecuteChangedTarget>>.Default.Equals(CanExecuteChangedTargets, other.CanExecuteChangedTargets) &&
               EqualityComparer<List<RaisePropertyChangedTarget>>.Default.Equals(RaisePropertyChangedTargets, other.RaisePropertyChangedTargets);
    }

    public override int GetHashCode()
    {
        int hashCode = 1958544934;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FieldName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PropertyName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
        hashCode = hashCode * -1521134295 + IsReadOnly.GetHashCode();
        hashCode = hashCode * -1521134295 + IsStatic.GetHashCode();
        hashCode = hashCode * -1521134295 + NotifyType.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<List<PropertyMethodCallTarget>>.Default.GetHashCode(PropertyMethods);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<CanExecuteChangedTarget>>.Default.GetHashCode(CanExecuteChangedTargets);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<RaisePropertyChangedTarget>>.Default.GetHashCode(RaisePropertyChangedTargets);
        return hashCode;
    }
}

internal class PropertyMethodCallTarget : IEquatable<PropertyMethodCallTarget?>
{
    public PropertySection Section;
    public string MethodName;
    public string MethodArgs;

    public PropertyMethodCallTarget(PropertySection section, string methodName, string methodArgs)
    {
        Section = section;
        MethodName = methodName;
        MethodArgs = methodArgs;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PropertyMethodCallTarget);
    }

    public bool Equals(PropertyMethodCallTarget? other)
    {
        return other is not null &&
               Section == other.Section &&
               MethodName == other.MethodName &&
               MethodArgs == other.MethodArgs;
    }

    public override int GetHashCode()
    {
        int hashCode = -105004156;
        hashCode = hashCode * -1521134295 + Section.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MethodName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MethodArgs);
        return hashCode;
    }
}

internal class CanExecuteChangedTarget : IEquatable<CanExecuteChangedTarget?>
{
    public string CommandName;

    public CanExecuteChangedTarget(string commandName)
    {
        CommandName = commandName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CanExecuteChangedTarget);
    }

    public bool Equals(CanExecuteChangedTarget? other)
    {
        return other is not null &&
               CommandName == other.CommandName;
    }

    public override int GetHashCode()
    {
        return -365693919 + EqualityComparer<string>.Default.GetHashCode(CommandName);
    }
}

internal class RaisePropertyChangedTarget : IEquatable<RaisePropertyChangedTarget?>
{
    public string PropertyName;

    public RaisePropertyChangedTarget(string propertyName)
    {
        PropertyName = propertyName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as RaisePropertyChangedTarget);
    }

    public bool Equals(RaisePropertyChangedTarget? other)
    {
        return other is not null &&
               PropertyName == other.PropertyName;
    }

    public override int GetHashCode()
    {
        return 487910435 + EqualityComparer<string>.Default.GetHashCode(PropertyName);
    }
}