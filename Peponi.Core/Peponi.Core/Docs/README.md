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
        - [2.2.1.2. MemberHelper](#2212-memberhelper)
        - [2.2.1.3. ProcessHelper](#2213-processhelper)
        - [2.2.1.4. RegistryHelper](#2214-registryhelper)
        - [2.2.1.5. StorageHelper](#2215-storagehelper)
      - [2.2.2. MiniDump](#222-minidump)


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
    |DirectoryInfo|GetDirectoryInfo(string)|Return directory info|
    |List\<DirectoryInfo>|GetSubDirectoryInfos(string)|Return sub directory infos|
    |List\<FileInfo>|GetFileInfos(string)|Return file infos for given directory|
    |List\<FileInfo>|GetFileInfosIncludingSubDirectories(string)|Return file infos including sub directories|
    |List\<FileInfo>|FindFiles(this List\<FileInfo>,string)|Returns files with the specified name|
2. Example
    ```cs
    using Peponi.Core.Utility.Helpers;

    public class Program
    {
        private static void Main()
        {
            DirectoryHelper.CreateDirectory(@"C:\Temp\TestFolder");

            // Create dummy files and sub directories
            for (int i = 0; i < 2; i++)
            {
                File.WriteAllText($@"C:\Temp\TestFolder\{i}.txt", DummyContents);
                DirectoryHelper.CreateDirectory($@"C:\Temp\TestFolder\{i}");
                for (int j = 0; j < 2; j++) File.Create($@"C:\Temp\TestFolder\{i}\{j}.txt");
            }

            var byteSize = DirectoryHelper.GetDirectorySize(@"C:\Temp\TestFolder");
            Console.WriteLine(byteSize);    // 804

            var mbSize = DirectoryHelper.GetDirectorySizeMB(@"C:\Temp\TestFolder");
            Console.WriteLine(mbSize);     // 0

            var dirInfo = DirectoryHelper.GetDirectoryInfo(@"C:\Temp\TestFolder");
            Console.WriteLine(dirInfo.Name);     // TestFolder

            var subDirInfos = DirectoryHelper.GetSubDirectoryInfos(@"C:\Temp\TestFolder");
            Console.WriteLine(string.Join(", ", subDirInfos.Select(x => x.Name)));     // 0, 1

            var fileInfos = DirectoryHelper.GetFileInfos(@"C:\Temp\TestFolder");
            Console.WriteLine(string.Join(", ", fileInfos.Select(x => x.Name)));    // 0.txt, 1.txt

            var allFileInfos = DirectoryHelper.GetFileInfosIncludingSubDirectories(@"C:\Temp\TestFolder");
            Console.WriteLine(string.Join(", ", allFileInfos.Select(x => x.Name))); // 0.txt, 1.txt, 0.txt, 1.txt, 0.txt, 1.txt

            var foundFiles = allFileInfos.FindFiles("0");
            Console.WriteLine(string.Join(",", foundFiles.Select(x => x.Name)));    // 0.txt, 0.txt, 0.txt
        }
    }
    ```


##### 2.2.1.2. MemberHelper


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |void|CopyAllFieldsAndProperties\<T>(in T, in T)|Copy all fields and properties|
    |bool|GetParameter\<T>(string, ref T, object)|Get the field or property value|
    |bool|SetParameter\<T>(string, T, object)|Set the field or property value|
2. Example
    ```cs
    public class CartesianCoordinate
    {
        public int X = 0;
        public int Y { get; set; } = 0;

        public CartesianCoordinate(int x, int y)
        {
            X = x; Y = y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
    ```
    ```cs
    public class Program
    {
        private static void Main()
        {
            var coordinate1 = new CartesianCoordinate(1, 1);
            var coordinate2 = new CartesianCoordinate(2, 2);

            MemberHelper.CopyAllFieldsAndProperties(coordinate1, coordinate2);
            Console.WriteLine(coordinate2);     // 1, 1

            int x = 0;
            var isSuccess = MemberHelper.GetParameter("X", ref x, coordinate2);
            if (isSuccess) Console.WriteLine(x);    // 1

            isSuccess = MemberHelper.SetParameter("Y", 5, coordinate1);
            if (isSuccess) Console.WriteLine(coordinate1);      // 1, 5
        }
    }
    ```


##### 2.2.1.3. ProcessHelper


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |bool|Execute(string)|Execute process|
    |void|Terminate(string)|Terminate process|
2. Example
    ```cs
    public class Program
    {
        private static void Main()
        {
            ProcessHelper.Execute("osk.exe");

            Thread.Sleep(5000);     // Wait for a while

            ProcessHelper.Terminate("osk.exe");
        }
    }
    ```


##### 2.2.1.4. RegistryHelper


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |void|AppendCurrentUser(string, string, string)|Append registry value under `HKEY_CURRENT_USER`|
    |string?|GetCurrentUser(string, string)|Get value from `HKEY_CURRENT_USER`|
    |void|AppendLocalMachine(string, string, string)|Append registry value under `HKEY_LOCAL_MACHINE`<br/>This need Admin access authority|
    |string?|GetLocalMachine(string, string)|Get value from `HKEY_LOCAL_MACHINE`<br/>This need Admin access authority|
2. Example
    ```cs
    public class Program
    {
        private static void Main()
        {
            RegistryHelper.AppendCurrentUser(@"SOFTWARE\MyKey", "Key001", "TestValue");
            Console.WriteLine(RegistryHelper.GetCurrentUser(@"SOFTWARE\MyKey", "Key001"));  // TestValue

            RegistryHelper.AppendLocalMachine(@"SOFTWARE\MyKey", "Key001", "TestValue");
            Console.WriteLine(RegistryHelper.GetLocalMachine(@"SOFTWARE\MyKey", "Key001"));  // TestValue
        }
    }
    ```


##### 2.2.1.5. StorageHelper


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |double|GetDiskSizeGB(string)|Get total disk size|
    |double|GetFreeSpaceGB(string)|Get free space size of disk|
    |int|GetFreeSpacePercent(string)|Get free space size of disk|
2. Example
    ```cs
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine(StorageHelper.GetDiskSizeGB(@"C:\"));         // 476.3041458129883
            Console.WriteLine(StorageHelper.GetFreeSpaceGB(@"C:\"));       // 175.6037826538086
            Console.WriteLine(StorageHelper.GetFreeSpacePercent(@"C:\"));  // 36
        }
    }
    ```


#### 2.2.2. MiniDump


1. Methods
    |Return type|Name|Description|
    |-----------|----|-----------|
    |void|Dump()|Write dump|
2. Example
    ```cs
    public class Program
    {
        private static void Main()
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch
            {
                MiniDumpWriter.Dump();
            }
        }
    }
    ```