# MDSoft.WinFormsUtils package - Utils for invoking WinForms conrols from async threads and tasks.

[![NuGet version](https://img.shields.io/nuget/v/MDSoft.WinFormsUtils.svg?style=flat)](https://www.nuget.org/packages/MDSoft.WinFormsUtils/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MDSoft.WinFormsUtils.svg)](https://www.nuget.org/packages/MDSoft.WinFormsUtils/)

--------

## MDSoft.WinFormsUtils
- ControlUtils
- InvokeControl
- InvokePictureBox
- InvokeProgressBar
- ProgressBarUtils

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

## MDSoft.WinFormsUtilsTests
- ControlUtilsTests
- InvokeControlTests
- InvokePictureBoxTests
- InvokeProgressBarTests
- ProgressBarUtilsTests

## How to use
Example of usage:

```C#
var task = Task.Run(async () =>
{
    await Task.Delay(TimeSpan.FromMilliseconds(_timeout)).ConfigureAwait(true);
    InvokeControl.SetVisible(button, false);
});
```

--------

## Repositories
[MDSoft.Examples](https://github.com/DamianMorozov/MDSoft.Examples "github.com")

# Support
Please, if this tools has been useful for you click on the `star` button.
