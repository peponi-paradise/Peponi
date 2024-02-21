using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Peponi.Core.Utility.Helpers;

public static class ProcessHelper
{
    // SysWow64 리다이렉트 중지
    [DllImport("kernel32.dll")] private static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

    // SysWow64 리다이렉트 재개
    [DllImport("kernel32.dll")] private static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

    public static bool Execute(string executableName)
    {
        // Check already opened
        if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(executableName)).Length > 0)
        {
            return false;
        }

        IntPtr ptr = default;

        if (Environment.Is64BitOperatingSystem)
        {
            Wow64DisableWow64FsRedirection(ref ptr);
        }

        ProcessStartInfo procinfo = new ProcessStartInfo();
        procinfo.FileName = executableName;
        procinfo.UseShellExecute = true;
        procinfo.Verb = "runas";

        var process = new Process();
        process.StartInfo = procinfo;

        process.Start();

        if (Environment.Is64BitOperatingSystem)
        {
            Wow64RevertWow64FsRedirection(ptr);
        }

        return true;
    }

    public static void Terminate(string executableName)
    {
        var processes = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(executableName));

        if (processes.Length > 0)
        {
            Array.ForEach(processes, process => process.Kill());
        }
    }
}