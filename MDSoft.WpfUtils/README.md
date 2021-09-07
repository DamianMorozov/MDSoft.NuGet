# MDSoft.WinFormsUtils package - Utils for invoking WPF conrols from async threads and tasks

[![NuGet version](https://img.shields.io/nuget/v/MDSoft.WpfUtils.svg?style=flat)](https://www.nuget.org/packages/MDSoft.WpfUtils/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MDSoft.WpfUtils.svg)](https://www.nuget.org/packages/MDSoft.WpfUtils/)

--------

# WPF.Utils
- InvokeContentControl
- InvokeControl
- InvokeListBox
- InvokeProgressBar
- InvokeTextBox
- InvokeWebBrowser

**Multi-targeted platforms**
```
- net45
- net46
- net461
- net47
- net471
- net472
- net48
```

# WPF.Utils.Tests
- EnumValues
- EnumWPF
- InvokeContentControlTests
- InvokeControlTests
- InvokeProgressBarTests
- InvokeTextBoxTests

## How to use
Example of usage:

```C#
var task = Task.Run(async () =>
{
    await Task.Delay(TimeSpan.FromMilliseconds(1_000)).ConfigureAwait(true);
    InvokeTextBox.Clear(textBox);
});
```

--------

## Repositories
[MDSoft.Examples](https://github.com/DamianMorozov/MDSoft.Examples "github.com")

# Support
Please, if this tools has been useful for you click on the `star` button.
