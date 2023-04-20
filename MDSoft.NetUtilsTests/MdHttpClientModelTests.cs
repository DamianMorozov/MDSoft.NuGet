// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.NetUtilsTests;

[TestFixture]
internal class MdHttpClientModelTests
{
    [Test]
    public void ConstructorSetupDefault_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => { _ = new MdHttpClientModel(); });
        Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new MdHttpClientModel(); }));
    }

    [Test]
    public void ConstructorSetup_DoesNotThrow()
    {
        foreach (int timeout in MdEnumValues.GetInt())
        {
            foreach (Uri host in MdEnumValues.GetUri())
            {
                Assert.DoesNotThrow(() => { _ = new MdHttpClientModel(timeout, host); });
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new MdHttpClientModel(); }));
            }
        }
    }

    [Test]
    public void OpenAsyncTask_DoesNotThrow()
    {
        foreach (int timeout in MdEnumValues.GetTimeoutMs())
        {
            foreach (Uri host in MdEnumValues.GetUri())
            {
                Assert.DoesNotThrow(() =>
                {
                    TestContext.WriteLine($@"Assert.DoesNotThrow. timeout: {timeout}. host: {host}");
                    MdProxyModel proxy = new();
                    MdHttpClientModel httpClient = new(timeout, host);
                    TestContext.WriteLine($@"{httpClient.Settings}");
                    Task task = Task.Run(async () =>
                    {
                        await httpClient.OpenAsync(proxy).ConfigureAwait(true);
                    });
                    task.Wait();
                    TestContext.WriteLine($@"{httpClient.Log}");
                });
                Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
                {
                    TestContext.WriteLine($@"Assert.DoesNotThrow. timeout: {timeout}. host: {host}");
                    MdProxyModel proxy = new();
                    MdHttpClientModel httpClient = new(timeout, host);
                    TestContext.WriteLine($@"{httpClient.Settings}");
                    Task task = Task.Run(async () =>
                    {
                        await httpClient.OpenAsync(proxy).ConfigureAwait(true);
                    });
                    task.Wait();
                    TestContext.WriteLine($@"{httpClient.Log}");
                }));
            }
        }
    }
}