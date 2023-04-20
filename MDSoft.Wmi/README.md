# MDSoft.Wmi package - WMI utils

[![NuGet version](https://img.shields.io/nuget/v/MDSoft.Wmi.svg?style=flat)](https://www.nuget.org/packages/MDSoft.Wmi/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MDSoft.Wmi.svg)](https://www.nuget.org/packages/MDSoft.Wmi/)

--------

## MDSoft.Wmi

**Multi-targeted platforms**
```
- net46
- net461
- net47
- net471
- net472
- net48
- net481
- netstandard2.0
- netstandard2.1
- net60
- net70
```

## How to use
```
MdWmiWinMemoryModel getWmi = Wmi.GetWin32OperatingSystemMemory();
ulong freeVirtual = getWmi.FreeVirtual;
ulong freePhysical = getWmi.FreePhysical;
ulong totalVirtual = getWmi.TotalVirtual;
ulong totalPhysical = getWmi.TotalPhysical;
```

--------

## Repositories
[MDSoft.Examples](https://github.com/DamianMorozov/MDSoft.Examples)

# Support
Please, if this tools has been useful for you click on the `star` button.
