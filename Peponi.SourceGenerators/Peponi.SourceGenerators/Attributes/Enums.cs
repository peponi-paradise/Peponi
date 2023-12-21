namespace Peponi.SourceGenerators;

public enum PropertySection
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

public enum GrpcClientMode
{
    Standalone,
    ClientFactory
}