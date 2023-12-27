# Peponi.Core


- [Peponi.Core](#peponicore)
  - [1. Instruction](#1-instruction)
    - [1.1. About Peponi.Core](#11-about-peponicore)
      - [1.1.1. Peponi.Core license](#111-peponicore-license)
      - [1.1.2. Peponi.Core install](#112-peponicore-install)
  - [2. Peponi.Core](#2-peponicore)
    - [2.1. Design pattern](#21-design-pattern)
      - [2.1.1. Singleton](#211-singleton)
    - [2.2. Utility](#22-utility)
      - [2.2.1. Helpers](#221-helpers)
        - [2.2.1.1. DirectoryHelper](#2211-directoryhelper)


## 1. Instruction


- This package is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About Peponi.Core


```text
Peponi.Core is a package for common usage of peponi library.
Included contents are:

1. Design pattern
   - Singleton
2. Utility
   - Helpers
      + Directory
      + Member
      + Process
      + Registry
      + Storage  
   - Minidump
```


#### 1.1.1. Peponi.Core license


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


#### 1.1.2. Peponi.Core install


```text
NuGet\Install-Package Peponi.Core
```


## 2. Peponi.Core


### 2.1. Design pattern


#### 2.1.1. Singleton<T>


1. Members
    |Type|Name|Description|
    |-------|-------|-------|
    |T|Instance|Singleton instance|
2. Example
    ```cs
    public class TestClass
    {
        public int X = 0;
    }
    ```
    ```cs
    Console.WriteLine(Singleton<TestClass>.Instance.X++);
    Console.WriteLine(Singleton<TestClass>.Instance.X++);
    Console.WriteLine(Singleton<TestClass>.Instance.X++);

    /* output:
    0
    1
    2
    */
    ```


### 2.2. Utility


#### 2.2.1. Helpers


##### 2.2.1.1. DirectoryHelper


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |void|CreateDirectory(string)|Create directory|
    |long|GetDirectorySize(string)|Return directory size as byte|
    |int|GetDirectorySizeMB(string)|Return directory size as mb|
    |List\<DirectoryInfo>|GetDirectoryInfos(string)|Return directory info including sub directories|
    |List\<FileInfo>|GetFileInfos(string)|Return file info for given directory|
    |List\<FileInfo>|GetFileInfosIncludingSubdirectories(string)|Return file info including sub directories|
2. 