# Peponi.Utility


- [Peponi.Utility](#peponiutility)
  - [1. Instruction](#1-instruction)
    - [1.1. About Peponi.Utility](#11-about-peponiutility)
      - [1.1.1. Peponi.Utility license](#111-peponiutility-license)
      - [1.1.2. Peponi.Utility install](#112-peponiutility-install)
  - [2. API information](#2-api-information)
    - [2.1. Helpers](#21-helpers)
    - [2.2. namespace Peponi.Utility.MiniDump](#22-namespace-peponiutilityminidump)
      - [2.2.1. static class MiniDumpWriter](#221-static-class-minidumpwriter)



## 1. Instruction


- This package is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About Peponi.Utility


```text
Peponi.Utility is:

1. a package for Helpers, Minidump and so on...
2. for common usage of 'Peponi' library
```


#### 1.1.1. Peponi.Utility license


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


#### 1.1.2. Peponi.Utility install


## 2. API information


### 2.1. Helpers


### 2.2. namespace Peponi.Utility.MiniDump


#### 2.2.1. static class MiniDumpWriter


1. Methods

|Return type|Method|Description|
|---|---|---|
|void|Dump()|Make minidumps. (Dividen mini and full dump files)<br>Dump type information:<br>1. *.mini.dmp : MiniDumpType.Normal (0x0)<br>2. *.full.dmp : MiniDumpType.Normal (0x0) \|<br>MiniDumpType.WithFullMemory (0x2) \|<br>MiniDumpType.WithHandleData (0x4) \|<br>MiniDumpType.WithProcessThreadData (0x100) \|<br>MiniDumpType.WithThreadInfo (0x1000) \|<br>MiniDumpType.WithCodeSegs (0x2000)|

2. Example

```cs
using Peponi.Utility.MiniDump;

namespace Peponi.Utility.Tests;

[TestClass]
public class Minidump
{
    [TestMethod]
    public void Dump()
    {
        try
        {
            // Assume an exception occurred.
            throw new Exception("Test");
        }
        catch (Exception ex)
        {
            // Write dump files
            MiniDumpWriter.Dump();
        }
    }
}
```