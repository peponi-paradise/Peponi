namespace Peponi.SourceGenerators;

public enum PropertyMethodSection
{
    Setter,
    Getter
}

public enum NotifyType
{
    None,
    Notify
}

public enum Modifier
{
    Public,
    Protected,
    Internal,
    Private
}

[Flags]
public enum InjectionType
{
    Dependency = 0b_1,
    Model = 0b_10
}