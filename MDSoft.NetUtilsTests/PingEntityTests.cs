// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.NetUtils;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MDSoft.NetUtilsTests
{
    [TestFixture]
    internal class PingEntityTests
    {
        [Test]
        public void ConstructorSetupDefault_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() =>
            {
                _ = new PingEntity();
            });
            Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
            {
                _ = new PingEntity();
            }));

            Utils.MethodComplete();
        }

        [Test]
        public void ConstructorSetup_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (int timeoutPing in EnumValues.GetTimeoutMs())
            {
                foreach (int timeoutTask in EnumValues.GetTimeoutMs())
                {
                    foreach (bool dontFragment in EnumValues.GetBool())
                    {
                        foreach (int bufferSize in EnumValues.GetBytes())
                        {
                            foreach (int ttl in EnumValues.GetBytes())
                            {
                                Assert.DoesNotThrow(() =>
                                {
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                });
                                Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
                                {
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                    _ = new PingEntity(timeoutPing, bufferSize, ttl, dontFragment, timeoutTask, false);
                                }));
                            }
                        }
                    }
                }
            }

            Utils.MethodComplete();
        }

        [Test]
        public void Open_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (int timeoutPing in EnumValues.GetBytes())
            {
                foreach (int timeoutRepeat in EnumValues.GetBytes())
                {
                    foreach (bool dontFragment in EnumValues.GetBool())
                    {
                        foreach (int bufferSize in EnumValues.GetBytes())
                        {
                            foreach (int ttl in EnumValues.GetBytes())
                            {
                                if ((timeoutPing > 127 && timeoutPing < 257) && (timeoutRepeat > 127 && timeoutRepeat < 257) &&
                                    (bufferSize >= 0 && bufferSize < 1465) && (ttl > 0 && ttl < 256))
                                {
                                    Assert.DoesNotThrow(() =>
                                    {
                                        PingEntity ping = new PingEntity(timeoutPing: timeoutPing, bufferSize: bufferSize, ttl: ttl, dontFragment: dontFragment,
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

            Utils.MethodComplete();
        }

        [Test]
        public void OpenAsync_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (int timeoutPing in EnumValues.GetBytes())
            {
                foreach (int timeoutRepeat in EnumValues.GetBytes())
                {
                    foreach (bool dontFragment in EnumValues.GetBool())
                    {
                        foreach (int bufferSize in EnumValues.GetBytes())
                        {
                            foreach (int ttl in EnumValues.GetBytes())
                            {
                                if ((timeoutPing > 127 && timeoutPing < 257) && (timeoutRepeat > 127 && timeoutRepeat < 257) &&
                                    (bufferSize >= 0 && bufferSize < 1465) && (ttl > 0 && ttl < 256))
                                {
                                    Assert.DoesNotThrow(() =>
                                    {
                                        PingEntity ping = new PingEntity(timeoutPing: timeoutPing, bufferSize: bufferSize, ttl: ttl, dontFragment: dontFragment,
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

            Utils.MethodComplete();
        }
    }
}