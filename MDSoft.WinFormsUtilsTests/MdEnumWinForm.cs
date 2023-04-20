// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com
// ReSharper disable UnusedMember.Global

namespace MDSoft.WinFormsUtilsTests;

/// <summary>
/// Enumeration of values.
/// </summary>
public static class MdEnumWinForm
{
    /// <summary>
    /// List of Color values.
    /// </summary>
    /// <returns></returns>
    public static List<Color> GetColor()
    {
        return new() { Color.White, Color.Black, Color.Blue, Color.Gray, Color.Green, Color.Red };
    }
}