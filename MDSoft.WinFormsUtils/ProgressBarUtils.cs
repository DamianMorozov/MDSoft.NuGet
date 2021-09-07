// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtils
{
    public static class ProgressBarUtils
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr w, IntPtr l);

        /// <summary>
        /// Set style.
        /// </summary>
        /// <param name="progressBar"></param>
        /// <param name="state">1 = normal (green); 2 = error (red); 3 = warning (yellow)</param>
        public static void SetState(this ProgressBar progressBar, int state)
        {
            SendMessage(progressBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
