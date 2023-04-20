// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtilsTests;

public class MdInvokeControlTests
{
    #region Private fields and properties

    private ConcurrentQueue<Control> _controls = new();

    #endregion

    /// <summary>
    /// Setup private fields.
    /// </summary>
    [SetUp]
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
    public void Teardown()
    {
        while (_controls.TryDequeue(out _)) { }
    }

    [Test]
    public void SetEnabled_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (bool value in MdEnumValues.GetBool())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetEnabled(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.SetEnabled(control, value)));
            }
        }
    }

    [Test]
    public void SetText_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetText(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.SetText(control, value)));
            }
        }
    }

    [Test]
    public void AddText_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.AddText(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.AddText(control, value)));
            }
        }
    }

    [Test]
    public void SetVisible_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (bool value in MdEnumValues.GetBool())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetVisible(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.SetVisible(control, value)));
            }
        }
    }

    [Test]
    public void SetBackColor_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (Color value in MdEnumWinForm.GetColor())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetBackColor(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.SetBackColor(control, value)));
            }
        }
    }

    [Test]
    public void SetForeColor_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            foreach (Color value in MdEnumWinForm.GetColor())
            {
                Assert.DoesNotThrow(() => MdInvokeControl.SetForeColor(control, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.SetForeColor(control, value)));
            }
        }
    }

    [Test]
    public void Focus_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            Assert.DoesNotThrow(() => MdInvokeControl.Focus(control));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.Focus(control)));
        }
    }

    [Test]
    public void Select_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            Assert.DoesNotThrow(() => MdInvokeControl.Select(control));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeControl.Select(control)));
        }
    }
}