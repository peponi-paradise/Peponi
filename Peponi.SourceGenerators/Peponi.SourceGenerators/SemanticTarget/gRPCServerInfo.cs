namespace Peponi.SourceGenerators.SemanticTarget;

internal class GrpcServerInfo : IEquatable<GrpcServerInfo?>
{
    public GrpcServerMode ServerMode { get; set; }
    public string ServiceFullName { get; set; }
    public string ServiceBaseFullName { get; set; }

    public GrpcServerInfo(GrpcServerMode mode, string service, string serviceBase)
    {
        ServerMode = mode;
        ServiceFullName = service;
        ServiceBaseFullName = serviceBase;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as GrpcServerInfo);
    }

    public bool Equals(GrpcServerInfo? other)
    {
        return other is not null &&
               ServerMode == other.ServerMode &&
               ServiceFullName == other.ServiceFullName &&
               ServiceBaseFullName == other.ServiceBaseFullName;
    }

    public override int GetHashCode()
    {
        int hashCode = -461864426;
        hashCode = hashCode * -1521134295 + ServerMode.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceFullName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceBaseFullName);
        return hashCode;
    }
}