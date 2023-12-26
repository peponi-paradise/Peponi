namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class GrpcServerAttribute : Attribute
{
    public GrpcServerMode GrpcServerMode { get; set; }

    public GrpcServerAttribute(GrpcServerMode serverMode)
    {
        GrpcServerMode = serverMode;
    }
}