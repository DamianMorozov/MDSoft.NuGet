// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeControlTests
{
    #region Private fields and properties

    private ConcurrentQueue<Control> _controls = new();

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
            _controls.Enqueue(new TextBox());
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
    public void Focus_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            Assert.DoesNotThrow(() => MdInvokeControl.Focus(control));
            //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.Focus(control)));
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetBackground_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (Brush value in MdEnumWPF.GetBrush())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetBackground(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetBackground(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetForeground_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (Brush value in MdEnumWPF.GetBrush())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetForeground(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetForeground(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetIsEnabled_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (bool value in MdEnumValues.GetBool())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetIsEnabled(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetIsEnabled(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetVisibility_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (Visibility value in Enum.GetValues(typeof(Visibility)))
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetVisibility(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetVisibility(control, value)));
            }
        }
    }
}