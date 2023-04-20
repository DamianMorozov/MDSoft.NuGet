// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.NetUtilsTests;

[TestFixture]
internal class MdProxyModelTests
{
    [Test]
    public void ConstructorSetupDefault_DoesNotThrow()
    {
        Assert.DoesNotThrow(() => { _ = new MdProxyModel(); });
        Assert.DoesNotThrowAsync(async () => await Task.Run(() => { _ = new MdProxyModel(); }));
    }

    [Test]
    public void ConstructorSetup_DoesNotThrow()
    {
        foreach (bool use in MdEnumValues.GetBool())
        {
            foreach (bool useDefaultCredentials in MdEnumValues.GetBool())
            {
                foreach (Uri host in MdEnumValues.GetUri())
                {
                    foreach (int port in MdEnumValues.GetInt())
                    {
                        foreach (string domain in MdEnumValues.GetString())
                        {
                            foreach (string username in MdEnumValues.GetString())
                            {
                                foreach (string password in MdEnumValues.GetString())
                                {
                                    Assert.DoesNotThrow(() =>
                                    {
                                        _ = new MdProxyModel(use, useDefaultCredentials, host, port, domain, username, password);
                                    });
                                    Assert.DoesNotThrowAsync(async () => await Task.Run(() =>
                                    {
                                        _ = new MdProxyModel(use, useDefaultCredentials, host, port, domain, username, password);
                                    }));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}