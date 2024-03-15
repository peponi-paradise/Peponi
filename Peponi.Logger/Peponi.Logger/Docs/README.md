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
      - [2.3.1. LogDirectoryOption](#231-logdirectoryoption)
      - [2.3.2. LogFileOption](#232-logfileoption)
      - [2.3.3. LogMessageOption](#233-logmessageoption)


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

Copyright (c) 2024 peponi

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

3. LogType (Flags)

    |LogType|Description|
    |-------|-------|
    |General|General|
    |Info|Information|
    |Notify|Notify|
    |Warning|Warning|
    |Error|Error|
    |Exception|Exception|

4. Example

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
            logger.Write(LogType.Error | LogType.Exception, "Logger Error & Exception");
        }
    }
    ```


### 2.3. LogOption


1. Members

    |Type|Name|Description|
    |----|----|-----------|
    |string|LoggerName|Logging base key name|
    |[LogDirectoryOption](#231-logdirectoryoption)|DirectoryOption|Configure directory tree|
    |[LogFileOption](#232-logfileoption)|FileOption|Configure log file size and creating rule|
    |[LogMessageOption](#233-logmessageoption)|MessageOption|Configure log message format|

2. Description
    - Configure logger options.
    - Logger will work by given options.
    - Concrete options are on following sections.


#### 2.3.1. LogDirectoryOption


1. Members

    |Type|Name|Description|
    |-------|-------|-------|
    |string|RootPath|Root path of log|
    |List\<LogDirectoryTree>|DirectoryTree|Configure directory tree|

2. Example

    ```cs
    LogDirectoryOption directoryOption = new()
    {
        RootPath = $@"C:\Temp\Peponi.Log\",
        DirectoryTree = new()
        {
            LogDirectoryTree.DateTime_Year,
            LogDirectoryTree.DateTime_Month,
            LogDirectoryTree.DateTime_Day,
            LogDirectoryTree.LoggerName,
        }
    };

    /* 
    This option will create following folder tree:

    C
    |- Temp
    |    |- Peponi.Log
    |    |    |- 2023
    |    |    |    |- 12
    |    |    |    |   |- 26
    |    |    |    |   |   |- MyLog
    */
    ```

3. LogDirectoryTree

    |LogDirectoryTree|Description|
    |-------|-------|
    |None|No additional folder|
    |LoggerName|Given logger name|
    |DateTime_Second|DateTime format `ss`|
    |DateTime_Minute|DateTime format `mm`|
    |DateTime_Hour|DateTime format `HH`|
    |DateTime_Day|DateTime format `dd`|
    |DateTime_Month|DateTime format `MM`|
    |DateTime_Year|DateTime format `yy`|


#### 2.3.2. LogFileOption


1. Members

    |Type|Name|Description|
    |-------|-------|-------|
    |uint|LogFileSize|- Unit : mb<br/>- Value :<br/>0 = Inf<br/>X = X mb<br/>- Default : 0|
    |List\<LogFileCreatingRule>|FileCreatingRules|Configure log file's creating rule|
    |string|Extension|Log file's extension<br/>Default : `.log`|

2. Example

    ```cs
    LogFileOption fileOption = new()
    {
        LogFileSize = 5,
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

    /*
    This option will create following log file :
    
    20231226_MyLog.txt (5 mb)
    20231226_MyLog_1.txt (5 mb)
    20231226_MyLog_2.txt (2 mb)
    */
    ```

3. LogFileCreatingRule

    |LogFileCreatingRule|Description|
    |-------|-------|
    |LoggerName|Given logger name|
    |DateTime_Second|DateTime format `ss`|
    |DateTime_Minute|DateTime format `mm`|
    |DateTime_Hour|DateTime format `HH`|
    |DateTime_Day|DateTime format `dd`|
    |DateTime_Month|DateTime format `MM`|
    |DateTime_Year|DateTime format `yyyy`|
    |Dot|`.`|
    |Space|` `|
    |Underbar|`_`|
    |Dash|`-`|


#### 2.3.3. LogMessageOption


1. Members

    |Type|Name|Description|
    |-------|-------|-------|
    |List\<LogMessagePattern>|MessagePatterns|Configure log message|

2. Example

    ```cs
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

    /*
    This option will create following log message :
    
    [2023-12-26 16.02.35.006] [MyLog] [General] Log message
    [2023-12-26 16.02.35.106] [MyLog] [General] Log message 2

    */
    ```

3. LogMessagePattern

    |LogMessagePattern|Description|
    |-------|-------|
    |None|No message|
    |LoggerName|Given logger name<br/>`[LoggerName] `|
    |DateTime|`[yyyy.MM.dd HH:mm:ss.fff] `|
    |LogType|`[LogType] `|
    |Message|`Message `|
    |NewLine|`Environment.NewLine`|