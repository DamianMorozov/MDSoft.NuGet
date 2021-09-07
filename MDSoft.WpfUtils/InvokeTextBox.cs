// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MDSoft.WpfUtils
{
    public static class InvokeTextBox
    {
        public static void Clear(TextBox control)
        {
            if (control is null)
                return;
            void Work(TextBox inControl)
            {
                inControl.Clear();
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control);
                    }));
            else
                Work(control);
        }

        public static void SetText(TextBox control, string text)
        {
            if (control is null)
                return;
            void Work(TextBox inControl, string inText)
            {
                inControl.Text = inText;
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
            else
                Work(control, text);
        }

        public static string GetText(TextBox control)
        {
            string result = string.Empty;
            if (control is null)
                return result;
            string Work(TextBox inControl)
            {
                return inControl.Text;
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        result = Work(control);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        result = Work(control);
                    }));
            else
                result = Work(control);
            return result;
        }

        public static void AddText(TextBox control, string text)
        {
            if (control is null)
                return;
            void Work(TextBox inControl, string inText)
            {
                inControl.Text += inText + Environment.NewLine;
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, text);
                    }));
            else
                Work(control, text);
        }

        public static void AddTextFormat(TextBox control, Stopwatch sw, string text)
        {
            if (control is null)
                return;
            void Work(TextBox inControl, Stopwatch inSw, string inText)
            {
                inControl.Text += $@"[{inSw.Elapsed}] {inText}" + Environment.NewLine;
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, sw, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, sw, text);
                    }));
            else
                Work(control, sw, text);
        }

        public static void AddTextFormat(TextBox control, DateTime dt, string text)
        {
            if (control is null)
                return;
            void Work(TextBox inControl, DateTime inDt, string inText)
            {
                inControl.Text += $@"[{inDt}] {inText}" + Environment.NewLine;
            }
            if (!control.CheckAccess())
                if (!(Application.Current is null))
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, dt, text);
                    }));
                else
                    control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        Work(control, dt, text);
                    }));
            else
                Work(control, dt, text);
        }

        public static void AddTextFormat(TextBox control, string text)
        {
            AddTextFormat(control, DateTime.Now, text);
        }
    }
}
