// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.NetUtilsTests;

[TestFixture]
internal class MdPingModelTests
{
    [Test]
    public void ConstructorSetupDefault_DoesNotThrow()
    {
        Assert.DoesNotThrow(() =>
        {
            _ = new MdPingModel();
        });
        Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
        {
            _ = new MdPingModel();
        }));
    }

    [Test]
    public void ConstructorSetup_DoesNotThrow()
    {
        foreach (int timeoutPing in MdEnumValues.GetTimeoutMs())
        {
            foreach (int timeoutTask in MdEnumValues.GetTimeoutMs())
            {
                foreach (bool dontFragment in MdEnumValues.GetBool())
                {
                    foreach (int bufferSize in MdEnumValues.GetBytes())
                    {
                        foreach (int ttl in MdEnumValues.GetBytes())
                        {
                            Assert.DoesNotThrow(() =>
                            {
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                            });
                            Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
                            {
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                _ = new MdPingModel(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                            }));
                        }
                    }
                }
            }
        }
    }

    [Test]
    public void Open_DoesNotThrow()
    {
        foreach (int timeoutPing in MdEnumValues.GetBytes())
        {
            foreach (int timeoutRepeat in MdEnumValues.GetBytes())
            {
                foreach (bool dontFragment in MdEnumValues.GetBool())
                {
                    foreach (int bufferSize in MdEnumValues.GetBytes())
                    {
                        foreach (int ttl in MdEnumValues.GetBytes())
                        {
                            if (timeoutPing > 127 && timeoutPing < 257 && timeoutRepeat > 127 && timeoutRepeat < 257 &&
                                bufferSize >= 0 && bufferSize < 1465 && ttl > 0 && ttl < 256)
                            {
                                Assert.DoesNotThrow(() =>
                                {
                                    MdPingModel ping = new(timeoutPing: timeoutPing, bufferSize: bufferSize, ttl: ttl, dontFragment: dontFragment,
                                        timeoutTask: timeoutRepeat, useRepeat: false);
                                    TestContext.WriteLine($@"{ping.Settings}");
                                    ping.Hosts.Add("google.com");
                                    ping.Hosts.Add("microsoft.com");
                                    ping.Hosts.Add("127.0.0.1");
                                    ping.Hosts.Add("yandex.com");
                                    ping.Hosts.Add("localhost");
                                    ping.Open();
                                    ping.Close();
                                    TestContext.WriteLine($@"{ping.Log}");
                                });
                            }
                        }
                    }
                }
            }
        }
    }

    [Test]
    public void OpenAsync_DoesNotThrow()
    {
        foreach (int timeoutPing in MdEnumValues.GetBytes())
        {
            foreach (int timeoutRepeat in MdEnumValues.GetBytes())
            {
                foreach (bool dontFragment in MdEnumValues.GetBool())
                {
                    foreach (int bufferSize in MdEnumValues.GetBytes())
                    {
                        foreach (int ttl in MdEnumValues.GetBytes())
                        {
                            if (timeoutPing > 127 && timeoutPing < 257 && timeoutRepeat > 127 && timeoutRepeat < 257 &&
                                bufferSize >= 0 && bufferSize < 1465 && ttl > 0 && ttl < 256)
                            {
                                Assert.DoesNotThrow(() =>
                                {
                                    MdPingModel ping = new(timeoutPing: timeoutPing, bufferSize: bufferSize, ttl: ttl, dontFragment: dontFragment,
                                        timeoutTask: timeoutRepeat, useRepeat: false);
                                    TestContext.WriteLine($@"{ping.Settings}");
                                    ping.Hosts.Add("google.com");
                                    ping.Hosts.Add("microsoft.com");
                                    ping.Hosts.Add("127.0.0.1");
                                    ping.Hosts.Add("yandex.com");
                                    ping.Hosts.Add("localhost");
                                    Task task = Task.Run(async () =>
                                    {
                                        await ping.OpenAsync().ConfigureAwait(true);
                                    });
                                    task.Wait();
                                    Task taskClose = Task.Run(async () =>
                                    {
                                        await ping.CloseAsync().ConfigureAwait(true);
                                    });
                                    taskClose.Wait();
                                    TestContext.WriteLine($@"{ping.Log}");
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}