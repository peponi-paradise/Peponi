using Microsoft.Win32;
using System.Runtime.Versioning;

namespace Peponi.Core.Utility.Helpers;

[SupportedOSPlatform("windows")]
public static class RegistryHelper
{
    public static void AppendCurrentUser(string key, string name, string value)
    {
        RegistryKey regKey = Registry.CurrentUser.CreateSubKey(key);
        if (regKey != null) regKey.SetValue(name, value);
    }

    public static string? GetCurrentUser(string key, string name)
    {
        RegistryKey? regKey = Registry.CurrentUser.OpenSubKey(key);
        if (regKey != null) return (string)regKey.GetValue(name)!;
        else return null;
    }

    /// <summary>
    /// Required Admin
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public static void AppendLocalMachine(string key, string name, string value)
    {
        RegistryKey regKey = Registry.LocalMachine.CreateSubKey(key);
        if (regKey != null) regKey.SetValue(name, value);
    }

    /// <summary>
    /// Required Admin
    /// </summary>
    /// <param name="key"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string? GetLocalMachine(string key, string name)
    {
        RegistryKey? regKey = Registry.LocalMachine.OpenSubKey(key);
        if (regKey != null) return (string)regKey.GetValue(name)!;
        else return null;
    }
}