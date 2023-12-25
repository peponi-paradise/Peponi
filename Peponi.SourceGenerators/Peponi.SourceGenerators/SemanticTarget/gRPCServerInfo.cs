namespace Peponi.SourceGenerators.SemanticTarget;

internal class GrpcServerInfo : IEquatable<GrpcServerInfo?>
{
    public GrpcServerMode ServerMode { get; set; }

    public string ServiceNamespace { get; set; }
    public string ServiceFullName { get; set; }
    public string ServiceBaseFullName { get; set; }

    public GrpcServerInfo(GrpcServerMode mode, string serviceNamespace, string serviceFullName, string serviceBaseFullName)
    {
        ServerMode = mode;
        ServiceNamespace = serviceNamespace;
        ServiceFullName = serviceFullName;
        ServiceBaseFullName = serviceBaseFullName;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as GrpcServerInfo);
    }

    public bool Equals(GrpcServerInfo? other)
    {
        return other is not null &&
               ServerMode == other.ServerMode &&
               ServiceNamespace == other.ServiceNamespace &&
               ServiceFullName == other.ServiceFullName &&
               ServiceBaseFullName == other.ServiceBaseFullName;
    }

    public override int GetHashCode()
    {
        int hashCode = 562648665;
        hashCode = hashCode * -1521134295 + ServerMode.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceNamespace);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceFullName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceBaseFullName);
        return hashCode;
    }
}