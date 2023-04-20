# MDSoft.NetUtils packages - Network utils

[![NuGet version](https://img.shields.io/nuget/v/MDSoft.NetUtils.svg?style=flat)](https://www.nuget.org/packages/MDSoft.NetUtils/)
[![NuGet downloads](https://img.shields.io/nuget/dt/MDSoft.NetUtils.svg)](https://www.nuget.org/packages/MDSoft.NetUtils/)

--------

## MDSoft.NetUtils
- MdHttpClientModel
- MdPingModel
- MdProxyModel

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

## MDSoft.NetUtilsTests
- EnumValues
- HttpClientEntityTests
- ProxyEntityTests
- Utils

## How to use
### Example of MdHttpClientModel usage
```C#
var proxy = new MdProxyModel();
var httpClient = new MdHttpClientModel(timeout: 50, host: "http://google.com/");
var task = Task.Run(async () =>
{
    await httpClient.OpenAsync(proxy).ConfigureAwait(true);
});
task.Wait();
```
### Example of MdPingModel usage
```C#
var ping = new MdPingModel(timeoutPing: 100, bufferSize: 32, ttl: 128, dontFragment: true, timeoutTask: 1000, useRepeat: false);
ping.Hosts.Add("google.com");
ping.Hosts.Add("microsoft.com");
ping.Hosts.Add("yandex.com");
var task = Task.Run(async () =>
{
    await ping.OpenAsync().ConfigureAwait(true);
});
task.Wait();
TestContext.WriteLine($@"{ping.Settings}");
TestContext.WriteLine($@"{ping.Log}");
```
### Example of MdProxyModel usage
```C#
var proxy = new NetUtils.MdProxyModel(use, useDefaultCredentials, host, port, domain, username, password);
```

--------

## Repositories
[MDSoft.Examples](https://github.com/DamianMorozov/MDSoft.Examples "github.com")

# Support
Please, if this tools has been useful for you click on the `star` button.
