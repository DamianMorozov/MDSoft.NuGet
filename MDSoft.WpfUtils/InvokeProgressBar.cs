// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MDSoft.WpfUtils
{
    public static class InvokeProgressBar
    {
        public static void SetValue(ProgressBar control, int value)
        {
            if (control is null)
                return;
            void Work(ProgressBar inControl, int inValue)
            {
                inControl.Value = inValue;
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

        public static void SetMinimum(ProgressBar control, int value)
        {
            if (control is null)
                return;
            void Work(ProgressBar inControl, int inValue)
            {
                inControl.Minimum = inValue;
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

        public static void SetMaximum(ProgressBar control, int value)
        {
            if (control is null)
                return;
            void Work(ProgressBar inControl, int inValue)
            {
                inControl.Maximum = inValue;
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
}
