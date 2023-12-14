# InjectGenerator.Errors


- [InjectGenerator.Errors](#injectgeneratorerrors)
  - [PNIJT002](#pnijt002)
  - [PNIJT003](#pnijt003)
  - [PNIJT004](#pnijt004)


## PNIJT002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency)]
protected internal partial class TestClass {}  // PNIJT002
```


## PNIJT003


|Title|Severity|Message|Description|
|---|---|---|---|
|Inject target resolve error|Error|Failed to resolve inject object|Please check inject object|

```cs
// Error example

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(null, InjectionType.Dependency)]
public partial class TestClass {} // PNIJT003
```


## PNIJT004


|Title|Severity|Message|Description|
|---|---|---|---|
|Inject target modifier error|Error|Not supported modifier - Could not use 'protected' to 'struct' object|Please check inject modifier|

```cs
// Error example

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency, Modifier = Modifier.Protected)]
public partial struct TestClass {} // PNIJT004
```