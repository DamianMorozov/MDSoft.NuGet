// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeContentControlTests
{
    #region Private fields and properties

    private ConcurrentQueue<ContentControl> _controls = new();

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
            _controls.Enqueue(new Label());
            _controls.Enqueue(new Button());
            _controls.Enqueue(new CheckBox());
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
    public void SetContent_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ContentControl control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeContentControl.SetContent(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetContent(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void AddContent_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ContentControl control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeContentControl.AddContent(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.AddContent(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetDataContext_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ContentControl control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeContentControl.SetDataContext(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetDataContext(control, value)));
            }
        }
    }
}