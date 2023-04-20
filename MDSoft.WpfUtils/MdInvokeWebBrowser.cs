// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtils;

public static class MdInvokeWebBrowser
{
    public static void SetSource(WebBrowser browser, Uri uri)
    {
        void Work(WebBrowser inBrowser, Uri inUri)
        {
            inBrowser.Source = inUri;
        }
        if (!browser.CheckAccess())
            if (!(Application.Current is null))
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(browser, uri);
                }));
            else
                browser.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    Work(browser, uri);
                }));
        else
            Work(browser, uri);
    }
}