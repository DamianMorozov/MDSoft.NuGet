// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeProgressBarTests
{
    #region Private fields and properties

    private ConcurrentQueue<ProgressBar> _controls = new();

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
            _controls.Enqueue(new());
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
    public void SetMaximum_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ProgressBar control))
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetMaximum(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMaximum(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetMinimum_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ProgressBar control))
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetMinimum(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMinimum(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetValue_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ProgressBar control))
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetValue(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetValue(control, value)));
            }
        }
    }
}