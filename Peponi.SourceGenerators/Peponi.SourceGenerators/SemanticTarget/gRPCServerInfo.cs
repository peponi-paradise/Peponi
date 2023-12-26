namespace Peponi.SourceGenerators.SemanticTarget;

internal class GrpcServerInfo : IEquatable<GrpcServerInfo?>
{
    public GrpcServerMode ServerMode { get; set; }

    public string ServiceNamespace { get; set; }
    public string ServiceFullName { get; set; }

    public string ServiceBaseNamespace { get; set; }
    public string ServiceBaseFullName { get; set; }

    public GrpcServerInfo(GrpcServerMode mode, string serviceNamespace, string serviceFullName, string serviceBaseNamespace, string serviceBaseFullName)
    {
        ServerMode = mode;
        ServiceNamespace = serviceNamespace;
        ServiceFullName = serviceFullName;
        ServiceBaseNamespace = serviceBaseNamespace;
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
               ServiceBaseNamespace == other.ServiceBaseNamespace &&
               ServiceBaseFullName == other.ServiceBaseFullName;
    }

    public override int GetHashCode()
    {
        int hashCode = 314002317;
        hashCode = hashCode * -1521134295 + ServerMode.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceNamespace);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceFullName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceBaseNamespace);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ServiceBaseFullName);
        return hashCode;
    }
}