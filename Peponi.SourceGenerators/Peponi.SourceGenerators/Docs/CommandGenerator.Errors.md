# CommandGenerator.Errors


- [CommandGenerator.Errors](#commandgeneratorerrors)
  - [PNCMD002](#pncmd002)
  - [PNCMD003](#pncmd003)
  - [PNCMD010](#pncmd010)
  - [PNCMD020](#pncmd020)
  - [PNCMD021](#pncmd021)


## PNCMD002


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper object|Supported objects are - class, record, struct|

```cs
// Error example

public partial interface ITest
{
    [Command]
    void GenTest() {}  // PNCMD002
}
```


## PNCMD003


|Title|Severity|Message|Description|
|---|---|---|---|
|Object declaration error|Error|Could not find proper modifier|Supported modifiers are - public, protected, internal, private|

```cs
// Error example

protected internal partial class TestClass
{
    [Command]
    void GenTest() {}  // PNCMD003
}
```


## PNCMD010


|Title|Severity|Message|Description|
|---|---|---|---|
|Method return type error|Error|Not supported return type|Supported return types are - void, Task, Task<T>|

```cs
// Error example

public partial class TestClass
{
    [Command]
    int GenTest() {}  // PNCMD010
}
```


## PNCMD020

|Title|Severity|Message|Description|
|---|---|---|---|
|CanExecute return type error|Error|Not supported CanExecute return type|Supported return type is `bool`|

```cs
// Error example

public partial class TestClass
{
    [Command(CanExecute = "CanExe")]
    void GenTest() {}  // PNCMD020

    int CanExe()
    {
        return 0;
    }
}
```


## PNCMD021


|Title|Severity|Message|Description|
|---|---|---|---|
|CanExecute parameter type error|Error|Not supported CanExecute parameter type|Parameter type should be void or matched with command parameter|

```cs
// Error example

public partial class TestClass
{
    [Command(CanExecute = "CanExe")]
    void GenTest() {}  // PNCMD021

    bool CanExe(int a)
    {
        return false;
    }
}
```