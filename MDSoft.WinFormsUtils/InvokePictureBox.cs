using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtils
{
    public static class InvokePictureBox
    {
        public static void SetBitmap(PictureBox control, Bitmap value)
        {
            if (control is null)
                return;
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
            if (control is null)
                return;
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
            if (control is null)
                return;
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
}
