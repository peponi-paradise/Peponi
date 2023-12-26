namespace Peponi.SourceGenerators.Tests.GrpcGenerator;

#nullable disable

[TestClass]
public class GrpcClientTestClass
{
    [TestMethod]
    public void GrpcCore()
    {
        Assert.IsTrue(GrpcClientCompare.CompareCode(
            @"using Peponi.SourceGenerators;

namespace GeneratorTest;

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @""C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator"")]
public partial class CodeTest
{
    Channel _channel;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using Grpc.Core;
using HelloWorld;

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        private HelloWorldCommunication.HelloWorldCommunicationClient _HelloWorldCommunication

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        private bool CreateServices()
        {
            bool rtn = true;
            try
            {
                _HelloWorldCommunication = new HelloWorldCommunication.HelloWorldCommunicationClient(_channel);
            }
            catch
            {
                rtn = false;
            }
            return rtn;
        }
    }
}"));
    }

    [TestMethod]
    public void ClientFactory()
    {
        Assert.IsTrue(GrpcClientCompare.CompareCode(
            @"using Peponi.SourceGenerators;

namespace GeneratorTest;

[GrpcClient(GrpcClientMode.ClientFactory, ""https://localhost:9091"", @""C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator"")]
public partial class CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

using Microsoft.Extensions.DependencyInjection;
using HelloWorld;

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        private IServiceCollection AddClientsFactory(IServiceCollection services)
        {
            services
            .AddGrpcClient<HelloWorldCommunication.HelloWorldCommunicationClient>(o => { o.Address = new Uri(""https://localhost:9091""); })
            ;
            return services;
        }
    }
}"));
    }
}