# MDSoft.WinFormsUtils package

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
