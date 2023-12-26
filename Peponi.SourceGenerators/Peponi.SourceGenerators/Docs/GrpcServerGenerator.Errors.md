# GrpcServerGenerator.Errors


- [GrpcServerGenerator.Errors](#grpcservergeneratorerrors)
  - [PNGSE002](#pngse002)
  - [PNGSE010](#pngse010)


## PNGSE002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

[GrpcServer(GrpcServerMode.Standalone)]
protected internal partial class CodeTest : HelloWorld.HelloWorldBase   // PNGSE002
{
}
```


## PNGSE010


|Title|Severity|Message|Description|
|---|---|---|---|
|Object not found error|Error|Could not find proper target|Could not find proper gRPC target. Check a gRPC target contains 'BindService'|

```cs
// Error example

namespace GeneratorTest
{
    [GrpcServer(GrpcServerMode.Standalone)]
    public partial class CodeTest : HelloWorld.HelloWorldBase
    {
    }
}

namespace ServerContext
{
    public static partial class HelloWorld
    {
        // public static ServerServiceDefinition BindService(HelloWorldBase base)  // PNGSE010
        // {
        // }

        public abstract partial class HelloWorldBase
        {
        }
    }
}
```