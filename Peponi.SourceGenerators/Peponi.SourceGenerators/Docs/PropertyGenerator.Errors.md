# PropertyGenerator.Errors


- [PropertyGenerator.Errors](#propertygeneratorerrors)
  - [PNPTY002](#pnpty002)


## PNPTY002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

protected internal partial class TestClass  // PNPTY002
{
    [Property]
    private int testInt;
}
```