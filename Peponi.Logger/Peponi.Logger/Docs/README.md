# Peponi.Logger


- [Peponi.Logger](#peponilogger)
  - [1. Instruction](#1-instruction)
    - [1.1. About Peponi.Logger](#11-about-peponilogger)
      - [1.1.1. Peponi.Logger license](#111-peponilogger-license)
      - [1.1.2. Peponi.Logger install](#112-peponilogger-install)
  - [2. Peponi.Logger](#2-peponilogger)
    - [2.1. Quick start](#21-quick-start)
    - [2.2. Log](#22-log)
    - [2.3. LogOption](#23-logoption)
    - [2.4. RaiseCanExecuteChanged](#24-raisecanexecutechanged)
    - [2.5. RaisePropertyChanged](#25-raisepropertychanged)
    - [2.6. Command](#26-command)
    - [2.7. Inject](#27-inject)


## 1. Instruction


- This package is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About Peponi.Logger


```text
Peponi.Logger is a package for logging.
Base concepts are:

1. Fast return
   - Add log item and return immediately
2. High performance logger
   - Has processor & writer per each logger
```


#### 1.1.1. Peponi.Logger license


```text
The MIT License (MIT)

Copyright (c) 2023 peponi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```


#### 1.1.2. Peponi.Logger install


```text
NuGet\Install-Package Peponi.Logger
```


## 2. Peponi.Logger


### 2.1. Quick start


```cs
using Peponi.Logger;

internal class Program
{
    private static void Main(string[] args)
    {
        // Gets logger with default option
        Log log = Log.GetLogger();

        log.Write("Hello, World!");
    }
}
```
```cs
using Peponi.Logger;

internal class Program
{
    private static void Main(string[] args)
    {
        // Gets logger named "MyLog" with default option
        Log log = Log.GetLogger("MyLog");

        log.Write(LogType.Info, "Hello, World!");
    }
}
```


### 2.2. Log


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |LogOption|Option|Options for logging|
2. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |Log|GetLogger(string)|Gets logger for given name|
    |Log|GetLogger(LogOption?)|Gets logger for given option|
    |void|Write(string, DateTime?)|Write log|
    |void|Write(LogType, string, DateTime?)|Write log|
3. Example
    ```cs
    using Peponi.Logger;

    internal class Program
    {
        private static void Main(string[] args)
        {
            LogDirectoryOption directoryOption = new()
            {
                RootPath = $@"C:\Temp\Peponi.Log\",
                DirectoryTree = new()
                {
                    LogDirectoryTree.None
                }
            };

            LogFileOption fileOption = new()
            {
                LogFileSize = 20,
                FileCreatingRules = new()
                {
                    LogFileCreatingRule.DateTime_Year,
                    LogFileCreatingRule.DateTime_Month,
                    LogFileCreatingRule.DateTime_Day,
                    LogFileCreatingRule.Underbar,
                    LogFileCreatingRule.LoggerName
                },
                Extension = ".txt"
            };

            LogMessageOption messageOption = new()
            {
                MessagePatterns = new()
                {
                    LogMessagePattern.DateTime,
                    LogMessagePattern.LoggerName,
                    LogMessagePattern.LogType,
                    LogMessagePattern.Message,
                    LogMessagePattern.NewLine
                }
            };

            LogOption option = new("MyLog", directoryOption, fileOption, messageOption);

            Log logger = Log.GetLogger(option);
            logger.Write(LogType.Info, "Logger created");
        }
    }
    ```


### 2.3. LogOption


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |PropertySection|Section|Determine where is method<br/>`PropertySection.Setter` is default|
    |string|Name|Name of method|
    |string?|Args|Sets arguments of the method|
2. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |MethodCallAttribute|MethodCall(string)|Default constructor|
3. Description
    - Inject methods on getter or setter of property.
    - [2.2. Property](#22-property) is required to use this attribute.

    - Input and generated code looks like followings:
        ```cs
        // Input

        public partial class CodeTest
        {
            [Property]
            [MethodCall("MyMethod")]
            private bool _testBool = false;
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public bool TestBool
            {
                get
                {
                    return _testBool;
                }
                set
                {
                    if(_testBool != value)
                    {
                        _testBool = value;
                        OnPropertyChanged(nameof(TestBool));
                        OnTestBoolChanged();
                        MyMethod();
                    }
                }
            }

            partial void OnTestBoolChanged();
        }
        ```

    - As a result, user could use `MethodCall` attribute like followings:
        ```cs
        // Input

        public partial class CodeTest
        {
            [Property]
            [MethodCall("MyMethod", Section = PropertySection.Getter, Args = "TestBool, FieldA")]
            [MethodCall("OtherMethod", Args = "TestBool, FieldB")]
            private bool _testBool = false;
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public bool TestBool
            {
                get
                {
                    MyMethod(TestBool, FieldA);
                    return _testBool;
                }
                set
                {
                    if(_testBool != value)
                    {
                        _testBool = value;
                        OnPropertyChanged(nameof(TestBool));
                        OnTestBoolChanged();
                        OtherMethod(TestBool, FieldB);
                    }
                }
            }

            partial void OnTestBoolChanged();
        }
        ```


### 2.4. RaiseCanExecuteChanged


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |string|CommandName|Command's name that will be raised|
2. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |RaiseCanExecuteChangedAttribute|RaiseCanExecuteChanged(string)|Default constructor|
3. Description
    - This is an attribute for raising whether certain command could execute or not.
    - [2.2. Property](#22-property) is required to use this attribute.
    - Generated property will call `ICommandBase.RaiseCanExecuteChanged` at setter.

    - Input and generated code looks like followings:
        ```cs
        // Input

        public partial class CodeTest
        {
            [Property]
            [RaiseCanExecuteChanged("TestCommand")]
            private bool _testBool = false;
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public bool TestBool
            {
                get => _testBool;
                set
                {
                    if(_testBool != value)
                    {
                        _testBool = value;
                        OnPropertyChanged(nameof(TestBool));
                        OnTestBoolChanged();
                        TestCommand.RaiseCanExecuteChanged();
                    }
                }
            }

            partial void OnTestBoolChanged();
        }
        ```


### 2.5. RaisePropertyChanged


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |string|PropertyName|Property's name that will be raised|
2. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |RaisePropertyChangedAttribute|RaisePropertyChanged(string)|Default constructor|
3. Description
    - This is an attribute for raising `INotifyPropertyChanged.PropertyChanged` for other property.
    - [2.2. Property](#22-property) is required to use this attribute.
    - Generated property will call `INotifyPropertyChanged.PropertyChanged` at setter.

    - Input and generated code looks like followings:
        ```cs
        // Input

        public partial class CodeTest
        {
            [Property]
            [RaisePropertyChanged("TestParam")]
            private bool _testBool = false;
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public bool TestBool
            {
                get => _testBool;
                set
                {
                    if(_testBool != value)
                    {
                        _testBool = value;
                        OnPropertyChanged(nameof(TestBool));
                        OnTestBoolChanged();
                        OnPropertyChanged(nameof(TestParam));
                    }
                }
            }

            partial void OnTestBoolChanged();
        }
        ```


### 2.6. Command


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |string?|CustomName|Sets the name of command<br/>Basically, generated backing member's name is target method's name with "Command" suffix|
    |string?|CanExecute|Sets the name of member that will be invoked to check whether command could executed<br/>The member have to return bool value|
2. Description
    - Use this attribute for generating `ICommand` members.
    - Partial type declaration is required for using this attribute.
    - Generated method's name has "Command" suffix.

    - Input and generated code looks like followings:
        ```cs
        // Input - Sync

        public partial class CodeTest
        {
           [Command]
           private void Test()
           {
               return;
           }
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            private CommandBase? _testCommand;

            public ICommandBase TestCommand => _testCommand ??= new CommandBase(Test);
        }
        ```
        ```cs
        // Input - Async

        public partial class CodeTest
        {
            [Command]
            private async Task Test()
            {
                return;
            }
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            private CommandBase? _testCommand;

            public ICommandBase TestCommand => _testCommand ??= new CommandBase(async () => { await Test(); });
        }
        ```

    - As a result, user could use `Command` attribute like followings:
        ```cs
        // Input

        public partial class CodeTest
        {
            [Command(CustomName = "MyCommand", CanExecute = "CanExe")]
            private void Test(int a)
            {
                return;
            }

            private bool CanExe()
            {
                return true;
            }
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            private CommandBase<int>? _testCommand;

            public ICommandBase MyCommand => _testCommand ??= new CommandBase<int>(Test, _ => CanExe());
        }
        ```


### 2.7. Inject


1. Members
    |Type|Name|Description|
    |----|----|-----------|
    |Type|Type|Sets the type will be injected<br/>Class, record, struct types are supported|
    |InjectionType|InjectionMode|Sets the injecting mode<br/>Supports<br/>`InjectionType.Dependency`<br/>`InjectionType.Model`<br/>`InjectionType.Dependency \| InjectionType.Model`|
    |string?|CustomName|Sets the name of injecting target<br/>Basically, generated member's name is same as injecting target|
    |Modifier|Modifier|Sets the modifier of injecting target|
    |NotifyType|PropertyNotifyMode|Sets the notify mode of injected target's member<br/>This is valid for `InjectionType.Model`|
2. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |InjectAttribute|Inject(Type, InjectionType)|Default constructor|
3. Description
    - Use this attribute for injecting members by the selected object.
    - Partial type declaration is required for using this attribute.
    - Using multiple attributes is allowed.
    - Class, record, struct types are supported.

    - Input and generated code looks like followings:
        ```cs
        // Input

        public class BaseClass
        {
            public int TestIng = 0;
            public bool TestBool = false;
            public List<string> TestList = new();
        }

        [Inject(typeof(BaseClass), InjectionType.Dependency)]
        public partial class CodeTest
        {
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public global::GeneratorTest.BaseClass BaseClass;

            public CodeTest(global::GeneratorTest.BaseClass BaseClass)
            {
                this.BaseClass = BaseClass;
            }
        }
        ```

    - As a result, user could use `Inject` attribute like followings:
        ```cs
        // Input

        public class BaseClass
        {
            public int TestInt = 0;
            public bool TestBool = false;
            public List<string> TestList = new();
        }

        public record BaseRecord
        {
            public float TestFloat = 0;
            public string TestString = string.Empty;
            public Dictionary<string, string> TestDic = new();
        }

        public struct BaseStruct
        {
            public double TestDouble;
            public char TestChar;
            public long TestLong;
        }

        [Inject(typeof(BaseClass), InjectionType.Dependency)]
        [Inject(typeof(BaseRecord), InjectionType.Model, CustomName = "ChangedRecord", Modifier = Modifier.Internal)]
        [Inject(typeof(BaseStruct), InjectionType.Dependency | InjectionType.Model, PropertyNotifyMode = NotifyType.None)]
        public partial class CodeTest
        {
        }
        ```
        ```cs
        // Generated

        public partial class CodeTest
        {
            public global::GeneratorTest.BaseClass BaseClass;

            internal global::GeneratorTest.BaseRecord ChangedRecord;

            public float TestFloat
            {
                get => ChangedRecord.TestFloat;
                set
                {
                    if(ChangedRecord.TestFloat != value)
                    {
                        ChangedRecord.TestFloat = value;
                        OnPropertyChanged(nameof(TestFloat));
                        OnTestFloatChanged();
                    }
                }
            }

            public string TestString
            {
                get => ChangedRecord.TestString;
                set
                {
                    if(ChangedRecord.TestString != value)
                    {
                        ChangedRecord.TestString = value;
                        OnPropertyChanged(nameof(TestString));
                        OnTestStringChanged();
                    }
                }
            }

            public Dictionary<string, string> TestDic
            {
                get => ChangedRecord.TestDic;
                set
                {
                    if(ChangedRecord.TestDic != value)
                    {
                        ChangedRecord.TestDic = value;
                        OnPropertyChanged(nameof(TestDic));
                        OnTestDicChanged();
                    }
                }
            }

            partial void OnTestFloatChanged();
            partial void OnTestStringChanged();
            partial void OnTestDicChanged();

            public global::GeneratorTest.BaseStruct BaseStruct;

            public double TestDouble
            {
                get => BaseStruct.TestDouble;
                set
                {
                    if(BaseStruct.TestDouble != value)
                    {
                        BaseStruct.TestDouble = value;
                        OnTestDoubleChanged();
                    }
                }
            }

            public char TestChar
            {
                get => BaseStruct.TestChar;
                set
                {
                    if(BaseStruct.TestChar != value)
                    {
                        BaseStruct.TestChar = value;
                        OnTestCharChanged();
                    }
                }
            }

            public long TestLong
            {
                get => BaseStruct.TestLong;
                set
                {
                    if(BaseStruct.TestLong != value)
                    {
                        BaseStruct.TestLong = value;
                        OnTestLongChanged();
                    }
                }
            }

            partial void OnTestDoubleChanged();
            partial void OnTestCharChanged();
            partial void OnTestLongChanged();

            public CodeTest(global::GeneratorTest.BaseClass BaseClass, global::GeneratorTest.BaseStruct BaseStruct)
            {
                this.BaseClass = BaseClass;
                this.BaseStruct = BaseStruct;
            }
        }
        ```