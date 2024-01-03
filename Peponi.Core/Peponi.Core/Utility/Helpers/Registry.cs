using Microsoft.Win32;

//using System.Runtime.Versioning;

namespace Peponi.Core.Utility.Helpers;

//[UnsupportedOSPlatform("windows")]
public static class RegistryHelper
{
#pragma warning disable CA1416

    /// <summary>
    /// Append registry value under `HKEY_CURRENT_USER`
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public static void AppendCurrentUser(string key, string name, string value)
    {
        CheckOSPlatform();
        RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key);
        if (regKey != null) regKey.SetValue(name, value);
    }

    /// <summary>
    /// Get value from `HKEY_CURRENT_USER`
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string? GetCurrentUser(string key, string name)
    {
        CheckOSPlatform();
        RegistryKey? regKey = Registry.CurrentUser.OpenSubKey(key);
        if (regKey != null) return (string)regKey.GetValue(name)!;
        else return null;
    }

    /// <summary>
    /// Append registry value under `HKEY_LOCAL_MACHINE`<br/>This need Admin access authority
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public static void AppendLocalMachine(string key, string name, string value)
    {
        CheckOSPlatform();
        RegistryKey regKey = Registry.LocalMachine.CreateSubKey(key);
        if (regKey != null) regKey.SetValue(name, value);
    }

    /// <summary>
    /// Get value from `HKEY_LOCAL_MACHINE`<br/>This need Admin access authority
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string? GetLocalMachine(string key, string name)
    {
        CheckOSPlatform();
        RegistryKey? regKey = Registry.LocalMachine.OpenSubKey(key);
        if (regKey != null) return (string)regKey.GetValue(name)!;
        else return null;
    }

    private static void CheckOSPlatform()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException("This method is working on windows only.");
        }
    }

#pragma warning restore CA1416
}