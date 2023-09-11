using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Peponi.Utility.MiniDump;

/// <summary>
/// <code>
/// Non-UI thread : AppDomain.CurrentDomain.UnhandledException
/// WinForm UI thread : Application.ThreadException
/// WPF UI thread : Application.Current.DispatcherUnhandledException
/// ASP.NET HttpApplication request exception : HttpApplication.Error
/// </code>
/// </summary>
public static class MiniDumpWriter
{
    [Flags]
    private enum MiniDumpType
    {
        Normal = 0x00000000,
        WithDataSegs = 0x00000001,
        WithFullMemory = 0x00000002,
        WithHandleData = 0x00000004,
        FilterMemory = 0x00000008,
        ScanMemory = 0x00000010,
        WithUnloadedModules = 0x00000020,
        WithIndirectlyReferencedMemory = 0x00000040,
        FilterModulePaths = 0x00000080,
        WithProcessThreadData = 0x00000100,
        WithPrivateReadWriteMemory = 0x00000200,
        WithoutOptionalData = 0x00000400,
        WithFullMemoryInfo = 0x00000800,
        WithThreadInfo = 0x00001000,
        WithCodeSegs = 0x00002000,
        WithoutAuxiliaryState = 0x00004000,
        WithFullAuxiliaryState = 0x00008000
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    private struct MinidumpExceptionInformation
    {
        public uint ThreadId;
        public IntPtr ExceptionPointers;
        public int ClientPointers;
    }

    [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump",
        CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode,
        ExactSpelling = true, SetLastError = true)]
    private static extern bool MiniDumpWriteDump(
                                IntPtr hProcess,
                                Int32 processId,
                                IntPtr fileHandle,
                                uint dumpType,
                                ref MinidumpExceptionInformation exceptionInfo,
                                IntPtr userInfo,
                                IntPtr extInfo);

    [DllImport("kernel32.dll")]
    private static extern uint GetCurrentThreadId();

    public static void Dump()
    {
        MakeMiniDump();
        MakeFullDump();
    }

    private static void MakeMiniDump()
    {
        var dumpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"{DateTime.Now.ToString("yyMMdd-HHmmss")}.mini.dmp");
        var dumpType = MiniDumpType.Normal;
        MinidumpExceptionInformation exceptionInfo = new();
        exceptionInfo.ClientPointers = 1;
        exceptionInfo.ExceptionPointers = Marshal.GetExceptionPointers();
        exceptionInfo.ThreadId = GetCurrentThreadId();

        using (FileStream stream = new FileStream(dumpPath, FileMode.Create))
        {
            Process process = Process.GetCurrentProcess();

            MiniDumpWriteDump(process.Handle,
                                       process.Id,
                                       stream.SafeFileHandle.DangerousGetHandle(),
                                       (uint)dumpType,
                                       ref exceptionInfo,
                                       IntPtr.Zero,
                                       IntPtr.Zero);
        }
    }

    private static void MakeFullDump()
    {
        var dumpPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $@"{DateTime.Now.ToString("yyMMdd-HHmmss")}.full.dmp");
        var dumpType = MiniDumpType.Normal |
                             MiniDumpType.WithFullMemory |
                             MiniDumpType.WithHandleData |
                             MiniDumpType.WithProcessThreadData |
                             MiniDumpType.WithThreadInfo |
                             MiniDumpType.WithCodeSegs;
        MinidumpExceptionInformation exceptionInfo = new();
        exceptionInfo.ClientPointers = 1;
        exceptionInfo.ExceptionPointers = Marshal.GetExceptionPointers();
        exceptionInfo.ThreadId = GetCurrentThreadId();

        using (FileStream stream = new FileStream(dumpPath, FileMode.Create))
        {
            Process process = Process.GetCurrentProcess();

            MiniDumpWriteDump(process.Handle,
                                       process.Id,
                                       stream.SafeFileHandle.DangerousGetHandle(),
                                       (uint)dumpType,
                                       ref exceptionInfo,
                                       IntPtr.Zero,
                                       IntPtr.Zero);
        }
    }
}