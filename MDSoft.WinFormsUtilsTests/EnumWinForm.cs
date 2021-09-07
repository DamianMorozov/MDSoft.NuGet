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
