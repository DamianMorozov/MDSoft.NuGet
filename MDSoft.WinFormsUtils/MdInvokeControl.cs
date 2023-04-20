// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtils;

public static class MdInvokeControl
{
    public static void SetText(Control control, string value)
    {
        void Work(Control inControl, string inValue)
        {
            inControl.Text = inValue;
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

    public static void AddText(Control control, string value)
    {
        void Work(Control inControl, string inValue)
        {
            inControl.Text += inValue;
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

    public static void SetVisible(Control control, bool value)
    {
        void Work(Control inControl, bool inValue)
        {
            inControl.Visible = inValue;
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

    public static void SetEnabled(Control control, bool value)
    {
        void Work(Control inControl, bool inValue)
        {
            inControl.Enabled = inValue;
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

    public static void SetBackColor(Control control, Color value)
    {
        void Work(Control inControl, Color inValue)
        {
            inControl.BackColor = inValue;
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

    public static void SetForeColor(Control control, Color value)
    {
        void Work(Control inControl, Color inValue)
        {
            inControl.ForeColor = inValue;
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

    public static void Select(Control control)
    {
        void Work(Control inControl)
        {
            inControl.Select();
        }
        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() =>
            {
                Work(control);
            }));
        }
        else
        {
            Work(control);
        }
    }

    public static void Focus(Control control)
    {
        void Work(Control inControl)
        {
            inControl.Focus();
        }

        if (control.InvokeRequired)
        {
            control.Invoke(new Action(() =>
            {
                Work(control);
            }));
        }
        else
        {
            Work(control);
        }
    }
}