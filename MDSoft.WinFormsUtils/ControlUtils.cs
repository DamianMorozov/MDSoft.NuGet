using System.Reflection;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtils
{
    public static class ControlUtils
    {
        public static void SetDoubleBuffered(this Control control, bool value)
        {
            var pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(control, value, null);

                var mi = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                mi?.Invoke(control, new object[]
                {
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer, true
                });

                mi = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                mi?.Invoke(control, null);
            }
        }
    }
}
