// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable UnusedMember.Global

namespace MDSoft.NetUtilsTests;

/// <summary>
/// Enumeration of values.
/// </summary>
internal static class MdEnumValues
{
    /// <summary>
    /// List of bool values.
    /// </summary>
    /// <returns></returns>
    public static List<bool> GetBool()
    {
        return new() { false, true };
    }

    /// <summary>
    /// List of string values.
    /// </summary>
    /// <returns></returns>
    public static List<string> GetString()
    {
        return new() { "", string.Empty };
    }

    /// <summary>
    /// List of ushort values.
    /// </summary>
    /// <returns></returns>
    public static List<ushort> GetUshort()
    {
        return new() { ushort.MinValue, 1, ushort.MaxValue / 2, ushort.MaxValue };
    }

    /// <summary>
    /// List of progress values.
    /// </summary>
    /// <returns></returns>
    public static List<ushort> GetProgress()
    {
        return new() { 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
    }

    /// <summary>
    /// List of short values.
    /// </summary>
    /// <returns></returns>
    public static List<short> GetShort()
    {
        return new() { short.MinValue, 1, short.MaxValue / 2, short.MaxValue };
    }

    /// <summary>
    /// List of uint values.
    /// </summary>
    /// <returns></returns>
    public static List<uint> GetUint()
    {
        return new() { uint.MinValue, 1, uint.MaxValue / 2, uint.MaxValue };
    }

    /// <summary>
    /// List of int values.
    /// </summary>
    /// <returns></returns>
    public static List<int> GetInt()
    {
        return new() { int.MinValue, 1, int.MaxValue / 2, int.MaxValue };
    }

    /// <summary>
    /// List of long values.
    /// </summary>
    /// <returns></returns>
    public static List<long> GetLong()
    {
        return new() { long.MinValue, 1, long.MaxValue / 2, long.MaxValue };
    }

    /// <summary>
    /// List of DateTime values.
    /// </summary>
    /// <returns></returns>
    public static List<DateTime> GetDateTime()
    {
        return new() { DateTime.MinValue, DateTime.MaxValue, DateTime.Now, DateTime.Today, DateTime.UtcNow };
    }

    /// <summary>
    /// String value.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string AsString(this string str)
    {
        return str == null ? "<null>" : str == "" ? "<empty>" : str;
    }

    /// <summary>
    /// List of uri values.
    /// </summary>
    /// <returns></returns>
    public static List<Uri> GetUri()
    {
        return new() { new("http://google.com/"), new("http://microsoft.com/") };
    }

    /// <summary>
    /// List of timeout values in ms.
    /// </summary>
    /// <returns></returns>
    public static List<int> GetTimeoutMs()
    {
        return new() { 50, 500 };
    }

    /// <summary>
    /// List of bytes.
    /// </summary>
    /// <returns></returns>
    public static List<int> GetBytes()
    {
        return new() { 0, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048 };
    }
}