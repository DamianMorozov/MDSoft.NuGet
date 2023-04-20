// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtils;

public static class MdInvokeContentControl
{
    public static void SetContent(ContentControl control, string value)
    {
        void Work(ContentControl inControl, string inValue)
        {
            inControl.Content = inValue;
        }
        if (!control.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
            else
                control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
        else
            Work(control, value);
    }

    public static void AddContent(ContentControl control, string value)
    {
        void Work(ContentControl inControl, string inValue)
        {
            inControl.Content += inValue + Environment.NewLine;
        }
        if (!control.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
            else
                control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
        else
            Work(control, value);
    }

    public static void SetDataContext(ContentControl control, object value)
    {
        void Work(ContentControl inControl, object inValue)
        {
            inControl.DataContext = inValue;
        }
        if (!control.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
            else
                control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, value);
                }));
        else
            Work(control, value);
    }
}