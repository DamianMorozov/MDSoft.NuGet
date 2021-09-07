// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.NetUtils;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MDSoft.NetUtilsTests
{
    [TestFixture]
    internal class HttpClientEntityTests
    {
        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Utils.MethodStart();
            //
            Utils.MethodComplete();
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            Utils.MethodStart();
            // 
            Utils.MethodComplete();
        }

        [Test]
        public void ConstructorSetupDefault_DoesNotThrow()
        {
            Utils.MethodStart();

            Assert.DoesNotThrow(() => { _ = new HttpClientEntity(); });
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new HttpClientEntity(); }));

            Utils.MethodComplete();
        }

        [Test]
        public void ConstructorSetup_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (int timeout in EnumValues.GetInt())
            {
                foreach (System.Uri host in EnumValues.GetUri())
                {
                    Assert.DoesNotThrow(() => { _ = new HttpClientEntity(timeout, host); });
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new HttpClientEntity(); }));
                }
            }

            Utils.MethodComplete();
        }

        [Test]
        public void OpenAsyncTask_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (int timeout in EnumValues.GetTimeoutMs())
            {
                foreach (System.Uri host in EnumValues.GetUri())
                {
                    Assert.DoesNotThrow(() =>
                    {
                        TestContext.WriteLine($@"Assert.DoesNotThrow. timeout: {timeout}. host: {host}");
                        ProxyEntity proxy = new ProxyEntity();
                        HttpClientEntity httpClient = new HttpClientEntity(timeout, host);
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
                        ProxyEntity proxy = new ProxyEntity();
                        HttpClientEntity httpClient = new HttpClientEntity(timeout, host);
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

            Utils.MethodComplete();
        }
    }
}