// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtilsTests;

public class MdControlUtilsTests
{
    #region Private fields and properties

    private ConcurrentQueue<Control> _controls = new();

    #endregion

    [SetUp]
    public void Setup()
    {
        _controls = new();
        for (int i = 0; i < 100; i++)
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
    public void SetDoubleBuffered_DoesNotThrow()
    {
        while (_controls.TryDequeue(out Control control))
        {
            Assert.DoesNotThrow(() => control.SetDoubleBuffered(true));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => control.SetDoubleBuffered(true)));
        }
    }
}