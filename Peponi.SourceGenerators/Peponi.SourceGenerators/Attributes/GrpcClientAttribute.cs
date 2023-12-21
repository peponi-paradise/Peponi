namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class GrpcClientAttribute : Attribute
{
    public GrpcClientMode GrpcClientMode { get; set; }
    public string Remote { get; set; }
    public string ProtoRootPath { get; set; }

    public GrpcClientAttribute(GrpcClientMode clientMode, string remote, string protoRootPath)
    {
        GrpcClientMode = clientMode;
        Remote = remote;
        ProtoRootPath = protoRootPath;
    }
}