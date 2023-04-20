// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtils;

public static class MdInvokeListBox
{
    public static void ItemsClear(ListBox control)
    {
        void Work(ListBox inControl)
        {
            inControl.Items.Clear();
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

    public static void ItemAdd(ListBox control, object item)
    {
        void Work(ListBox inControl, object inItem)
        {
            inControl.Items.Add(inItem);
        }
        if (!control.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, item);
                }));
            else
                control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, item);
                }));
        else
            Work(control, item);
    }

    public static void ItemsAdd(ListBox control, ItemCollection items)
    {
        void Work(ListBox inControl, ItemCollection inItems)
        {
            foreach (object item in inItems)
            {
                inControl.Items.Add(item);
            }
        }
        if (!control.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, items);
                }));
            else
                control.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(control, items);
                }));
        else
            Work(control, items);
    }

    public static ItemCollection ItemsGet(ListBox control)
    {
        ItemCollection? result = null;
        ItemCollection Work(ListBox inControl)
        {
            return inControl.Items;
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
        if (result is not null)
            return result;
        return Work(control);
    }
}