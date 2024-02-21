# Peponi.FreeSpaceManagement


- [Peponi.FreeSpaceManagement](#peponifreespacemanagement)
  - [1. Instruction](#1-instruction)
    - [1.1. About Peponi.FreeSpaceManagement](#11-about-peponifreespacemanagement)
      - [1.1.1. Peponi.FreeSpaceManagement license](#111-peponifreespacemanagement-license)
      - [1.1.2. Peponi.FreeSpaceManagement install](#112-peponifreespacemanagement-install)
  - [2. Peponi.FreeSpaceManagement](#2-peponifreespacemanagement)
    - [2.1. FreeSpaceManager](#21-freespacemanager)


## 1. Instruction


- This package is under MIT License.
- GitHub : [Peponi](https://github.com/peponi-paradise/Peponi)
- Blog : [Peponi](https://peponi-paradise.tistory.com)
- Instruction & API information is on following section


### 1.1. About Peponi.FreeSpaceManagement


```text
Peponi.FreeSpaceManagement is a package for maintaining free space of storage.
Base concepts are:

1. Remove oldest file
    - Automatically remove oldest file when free space is under setted disk preserve percent value
```


#### 1.1.1. Peponi.FreeSpaceManagement license


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


#### 1.1.2. Peponi.FreeSpaceManagement install


```text
NuGet\Install-Package Peponi.FreeSpaceManagement
```


## 2. Peponi.FreeSpaceManagement


### 2.1. FreeSpaceManager


1. Members

    |Type|Name|Description|
    |----|----|-----------|
    |string|RootPath|File management base folder|
    |int|DiskPreservePercent|Minimum free space %|
    |bool|IsRunning|Indicates manager thread is running|

2. Methods

    |Return type|Name|Description|
    |-----------|----|-----------|
    |FreeSpaceManager|FreeSpaceManager(string, int)|Default constructor|
    |void|StartManager()|Start manager thread|
    |void|StopManager()|Stop manager thread|

3. Example

    ```cs
    using Peponi.StorageManagement;

    internal class Program
    {
        private static void Main(string[] args)
        {
            FreeSpaceManager manager = new(@"C:\Temp\test\", 30);
            
            manager.StartManager();

            manager.StopManager();
        }
    }
    ```