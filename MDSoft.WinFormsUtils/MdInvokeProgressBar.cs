// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtils;

public class MdInvokeProgressBar
{
    public static void SetValue(ProgressBar control, int value)
    {
        void Work(ProgressBar inControl, int inValue)
        {
            inControl.Value = inValue;
        }
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() =>
            {
                Work(control, value);
            }));
        }
        else
        {
            Work(control, value);
        }
    }

    public static void SetMinimum(ProgressBar control, int value)
    {
        void Work(ProgressBar inControl, int inValue)
        {
            inControl.Minimum = inValue;
        }
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() =>
            {
                Work(control, value);
            }));
        }
        else
        {
            Work(control, value);
        }
    }

    public static void SetMaximum(ProgressBar control, int value, int sleepTimeOutMs = 10)
    {
        void Work(ProgressBar inControl, int inValue)
        {
            inControl.Maximum = inValue;
        }
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() =>
            {
                Work(control, value);
            }));
        }
        else
        {
            Work(control, value);
        }
    }
}