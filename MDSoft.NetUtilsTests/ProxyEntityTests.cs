// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.NetUtils;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MDSoft.NetUtilsTests
{
    [TestFixture]
    internal class ProgramTests
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

            Assert.DoesNotThrow(() => { _ = new ProxyEntity(); });
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new ProxyEntity(); }));

            Utils.MethodComplete();
        }

        [Test]
        public void ConstructorSetup_DoesNotThrow()
        {
            Utils.MethodStart();

            foreach (bool use in EnumValues.GetBool())
            {
                foreach (bool useDefaultCredentials in EnumValues.GetBool())
                {
                    foreach (System.Uri host in EnumValues.GetUri())
                    {
                        foreach (int port in EnumValues.GetInt())
                        {
                            foreach (string domain in EnumValues.GetString())
                            {
                                foreach (string username in EnumValues.GetString())
                                {
                                    foreach (string password in EnumValues.GetString())
                                    {
                                        Assert.DoesNotThrow(() =>
                                        {
                                            _ = new ProxyEntity(use, useDefaultCredentials, host, port, domain, username, password);
                                        });
                                        Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
                                        {
                                            _ = new ProxyEntity(use, useDefaultCredentials, host, port, domain, username, password);
                                        }));
                                    }
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