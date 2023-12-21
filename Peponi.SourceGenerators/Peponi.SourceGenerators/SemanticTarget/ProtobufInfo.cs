namespace Peponi.SourceGenerators.SemanticTarget;

internal class ProtobufInfo : IEquatable<ProtobufInfo?>
{
    public GrpcClientMode ClientMode { get; set; }
    public string Remote { get; set; } = string.Empty;
    public List<ProtobufData> ProtobufDatas { get; set; } = new();

    public ProtobufInfo(GrpcClientMode clientMode, string remote, List<ProtobufData> protobufDatas)
    {
        ClientMode = clientMode;
        Remote = remote;
        ProtobufDatas = protobufDatas;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ProtobufInfo);
    }

    public bool Equals(ProtobufInfo? other)
    {
        return other is not null &&
               ClientMode == other.ClientMode &&
               Remote == other.Remote &&
               EqualityComparer<List<ProtobufData>>.Default.Equals(ProtobufDatas, other.ProtobufDatas);
    }

    public override int GetHashCode()
    {
        int hashCode = 1750520235;
        hashCode = hashCode * -1521134295 + ClientMode.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Remote);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<ProtobufData>>.Default.GetHashCode(ProtobufDatas);
        return hashCode;
    }
}

internal class ProtobufData : IEquatable<ProtobufData?>
{
    public string Namespace { get; set; } = string.Empty;
    public List<string> ServiceNames { get; set; } = new();

    public ProtobufData(string @namespace, List<string> serviceNames)
    {
        Namespace = @namespace;
        ServiceNames = serviceNames;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ProtobufData);
    }

    public bool Equals(ProtobufData? other)
    {
        return other is not null &&
               Namespace == other.Namespace &&
               EqualityComparer<List<string>>.Default.Equals(ServiceNames, other.ServiceNames);
    }

    public override int GetHashCode()
    {
        int hashCode = 435777668;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Namespace);
        hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(ServiceNames);
        return hashCode;
    }
}