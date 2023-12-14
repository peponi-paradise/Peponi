# NotifyInterfaceGenerator.Errors


- [NotifyInterfaceGenerator.Errors](#notifyinterfacegeneratorerrors)
  - [PNNTI002](#pnnti002)


## PNNTI002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

[NotifyInterface]
protected internal partial class TestClass  // PNNTI002
{
    void GenTest() {}
}
```