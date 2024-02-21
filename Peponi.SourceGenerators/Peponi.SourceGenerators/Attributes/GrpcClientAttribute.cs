namespace Peponi.SourceGenerators;

/// <summary>
/// Use this attribute for creating gRPC services.<br/>
/// Partial type declaration is required for using this attribute.<br/>
/// gRPC client generator will find all `*.proto` files under `ProtoRootPath`
/// <para>
/// - Example proto:
/// <code>
/// syntax = "proto3";
/// package HelloWorld;
///
/// service HelloWorldCommunication
/// {
///     rpc HelloRequest(CommunicationMessage) returns (CommunicationMessage);
/// }
///
/// message CommunicationMessage
/// {
///         	string Sender = 1;
///         	string Message = 2;
/// }
/// </code>
/// </para>
/// <para>
/// - Input and generated code looks like followings:
/// <code>
/// <see cref="GrpcClientMode.Standalone"/>
/// </code>
/// <code>
/// // Input
///
/// [GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @"C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.
/// Tests\GrpcGenerator")]
/// public partial class CodeTest
/// {
///     Channel _channel;
/// }
/// </code>
/// <code>
/// // Generated
///
/// using Grpc.Core;
/// using HelloWorld;
///
/// namespace GeneratorTest
/// {
///     public partial class CodeTest
///     {
///         private HelloWorldCommunication.HelloWorldCommunicationClient _HelloWorldCommunication
///
///                     private bool CreateServices()
///         {
///             bool rtn = true;
///             try
///             {
///                 _HelloWorldCommunication = new HelloWorldCommunication.HelloWorldCommunicationClient(_channel);
///             }
///             catch
///             {
///                 rtn = false;
///             }
///             return rtn;
///         }
///     }
/// }
/// </code>
/// </para>
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.SourceGenerators"/>
/// </remarks>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class GrpcClientAttribute : Attribute
{
    /// <summary>
    /// Sets the Client mode<br/>
    /// Supports<br/>
    /// 1. <see cref="GrpcClientMode.Standalone"/><br/>
    /// 2. <see cref="GrpcClientMode.ClientFactory"/>
    /// <para>
    /// Generated code looks like followings:
    /// <code>
    /// 1. <see cref="GrpcClientMode.Standalone"/><br/><br/>
    /// using Grpc.Core;
    /// using HelloWorld;
    ///
    /// namespace GeneratorTest
    /// {
    ///     public partial class CodeTest
    ///     {
    ///         private HelloWorldCommunication.HelloWorldCommunicationClient _HelloWorldCommunication
    ///
    ///         private bool CreateServices()
    ///         {
    ///             bool rtn = true;
    ///             try
    ///             {
    ///                 _HelloWorldCommunication = new HelloWorldCommunication.HelloWorldCommunicationClient(_channel);
    ///             }
    ///             catch
    ///             {
    ///                 rtn = false;
    ///             }
    ///             return rtn;
    ///         }
    ///     }
    /// }
    /// </code>
    /// <code>
    /// 2. <see cref="GrpcClientMode.ClientFactory"/><br/><br/>
    /// using Microsoft.Extensions.DependencyInjection;
    /// using HelloWorld;
    ///
    /// namespace GeneratorTest
    /// {
    ///     public partial class CodeTest
    ///     {
    ///         private IServiceCollection AddClientsFactory(IServiceCollection services)
    ///         {
    ///             services
    ///             .AddGrpcClient&lt;HelloWorldCommunication.HelloWorldCommunicationClient&gt;(o => { o.Address = new Uri("https://localhost:9091"); })
    ///             ;
    ///             return services;
    ///         }
    ///     }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public GrpcClientMode GrpcClientMode { get; set; }

    /// <summary>
    /// Sets the<br/>
    /// 1. Member name of channel <see cref="GrpcClientMode.Standalone"/><br/>
    /// 2. Uri <see cref="GrpcClientMode.ClientFactory"/>
    /// <para>
    /// Input code looks like followings:
    /// <code>
    /// 1. <see cref="GrpcClientMode.Standalone"/><br/><br/>
    /// [GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @"C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator")]
    /// public partial class CodeTest
    /// {
    ///     Channel _channel;
    /// }
    /// </code>
    /// <code>
    /// 2. <see cref="GrpcClientMode.ClientFactory"/><br/><br/>
    /// [GrpcClient(GrpcClientMode.ClientFactory, "https://localhost:9091", @"C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator")]
    /// public partial class CodeTest
    /// {
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public string Remote { get; set; }

    /// <summary>
    /// Sets the root path of `*.proto` files<br/>
    /// gRPC client generator will find all `*.proto` files under <see cref="ProtoRootPath"/>
    /// </summary>
    public string ProtoRootPath { get; set; }

    public GrpcClientAttribute(GrpcClientMode clientMode, string remote, string protoRootPath)
    {
        GrpcClientMode = clientMode;
        Remote = remote;
        ProtoRootPath = protoRootPath;
    }
}