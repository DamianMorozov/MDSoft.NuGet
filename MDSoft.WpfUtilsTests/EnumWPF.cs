// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Windows.Media;
// ReSharper disable UnusedMember.Global
// Last changed 2020-10-10.

namespace MDSoft.WpfUtilsTests
{
    /// <summary>
    /// Enumeration of values.
    /// </summary>
    public static class EnumWPF
    {
        /// <summary>
        /// List of Color values.
        /// </summary>
        /// <returns></returns>
        public static List<Color> GetColors()
        {
            return new List<Color>() { Colors.White, Colors.Black, Colors.Blue, Colors.Gray, Colors.Green, Colors.Red };
        }

        /// <summary>
        /// List of Brush values.
        /// </summary>
        /// <returns></returns>
        public static List<Brush> GetBrush()
        {
            return new List<Brush>() { Brushes.Transparent, Brushes.White, Brushes.Black, Brushes.Blue, Brushes.Gray, Brushes.Green, Brushes.Red };
        }
    }
}
