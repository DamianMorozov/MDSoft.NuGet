// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtils;

public static class MdInvokePictureBox
{
    public static void SetBitmap(PictureBox control, Bitmap value)
    {
        void Work(PictureBox inControl, Bitmap inValue)
        {
            inControl.Image = inValue;
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

    public static void SetImage(PictureBox control, Image value)
    {
        void Work(PictureBox inControl, Image inValue)
        {
            inControl.Image = inValue;
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

    public static void SetBackgroundImage(PictureBox control, Image value)
    {
        void Work(PictureBox inControl, Image inValue)
        {
            inControl.BackgroundImage = inValue;
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