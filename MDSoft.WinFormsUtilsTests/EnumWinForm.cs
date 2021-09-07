// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Drawing;
// ReSharper disable UnusedMember.Global
// Last changed 2020-10-10.

namespace MDSoft.WinFormsUtilsTests
{
    /// <summary>
    /// Enumeration of values.
    /// </summary>
    public static class EnumWinForm
    {
        /// <summary>
        /// List of Color values.
        /// </summary>
        /// <returns></returns>
        public static List<Color> GetColor()
        {
            return new List<Color>() { Color.White, Color.Black, Color.Blue, Color.Gray, Color.Green, Color.Red };
        }
    }
}
