// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeWebBrowserTests
{
    #region Private fields and properties

    private ConcurrentQueue<WebBrowser> _controls = new();

    #endregion

    /// <summary>
    /// Setup private fields.
    /// </summary>
    [SetUp]
    [Apartment(ApartmentState.STA)]
    public void Setup()
    {
        _controls = new();
        for (int i = 0; i < 10; i++)
        {
            _controls.Enqueue(new());
        }
    }

    /// <summary>
    /// Reset private fields to default state.
    /// </summary>
    [TearDown]
    [Apartment(ApartmentState.STA)]
    public void Teardown()
    {
        while (_controls.TryDequeue(out _)) { }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetSource_DoesNotThrow()
    {
        while (_controls.TryDequeue(out WebBrowser control))
        {
            foreach (Uri value in MdEnumValues.GetUri())
            {
                Assert.DoesNotThrow(() => MdInvokeWebBrowser.SetSource(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeWebBrowser.SetSource(control, new Uri(value)));
            }
        }
    }
}