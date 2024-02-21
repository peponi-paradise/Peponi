# GrpcClientGenerator.Errors


- [GrpcClientGenerator.Errors](#grpcclientgeneratorerrors)
  - [PNGCE002](#pngce002)
  - [PNGCE010](#pngce010)
  - [PNGCE020](#pngce020)


## PNGCE002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @"C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator")]
protected internal partial class CodeTest   // PNGCE002
{
    Channel _channel;
}
```


## PNGCE010


|Title|Severity|Message|Description|
|---|---|---|---|
|No protobuf found error|Error|Could not find protobuf files|Check ProtoRootPath and extension - '*.proto'|

```cs
// Error example

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @"C:\EmptyFolder")]  // PNGCE010
public partial class CodeTest
{
    Channel _channel;
}
```


## PNGCE020


|Title|Severity|Message|Description|
|---|---|---|---|
|Resolving protobuf error|Error|Could not resolve protobuf files|Exception has been raised while resolving protobuf files|

```cs
// Error example

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @"C:\NotExistPath")]  // PNGCE020
public partial class CodeTest
{
    Channel _channel;
}
```