# MDSoft.NuGet
NuGet packages

## MDSoft.NetUtils
- HttpClientEntity
- PingEntity
- ProxyEntity

## MDSoft.NetUtilsTests
- EnumValues
- HttpClientEntityTests
- ProxyEntityTests
- Utils

## Multi-targeted platforms
- netstandard2.0
- netstandard2.1
- net45
- net46
- net461
- net472
- net48
- net50
- net60

## How to use
### Example of HttpClientEntity usage
```C#
var proxy = new ProxyEntity();
var httpClient = new HttpClientEntity(timeout: 50, host: "http://google.com/");
var task = Task.Run(async () =>
{
    await httpClient.OpenAsync(proxy).ConfigureAwait(true);
});
task.Wait();
```
### Example of PingEntity usage
```C#
var ping = new PingEntity(timeoutPing: 100, bufferSize: 32, ttl: 128, dontFragment: true, timeoutTask: 1000, useRepeat: false);
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
### Example of ProxyEntity usage
```C#
var proxy = new NetUtils.ProxyEntity(use, useDefaultCredentials, host, port, domain, username, password);
```
## NetExamples
[Visit this repo for view examples](https://github.com/DamianMorozov/NetExamples)

# Support
<p>Please, if this tools has been useful for you click on the `star` button.</p>
