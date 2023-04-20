// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeTextBoxTests
{
    #region Private fields and properties

    private ConcurrentQueue<TextBox> _controls = new();

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
    public void Clear_DoesNotThrow()
    {
        while (_controls.TryDequeue(out TextBox control))
        {
            Assert.DoesNotThrow(() => MdInvokeTextBox.Clear(control));
            //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.Clear(control)));
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void AddText_DoesNotThrow()
    {
        while (_controls.TryDequeue(out TextBox control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeTextBox.AddText(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddText(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void AddTextFormat_DoesNotThrow()
    {
        Stopwatch sw = Stopwatch.StartNew();
        while (_controls.TryDequeue(out TextBox control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeTextBox.AddTextFormat(control, sw, value));
                foreach (DateTime dt in MdEnumValues.GetDateTime())
                {
                    Assert.DoesNotThrow(() => MdInvokeTextBox.AddTextFormat(control, dt, value));
                    TestContext.WriteLine($@"{MdInvokeTextBox.GetText(control)}");
                }
                Assert.DoesNotThrow(() => MdInvokeTextBox.AddTextFormat(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddTextFormat(control, sw, value)));
            }
        }
        sw.Stop();
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void GetText_DoesNotThrow()
    {
        while (_controls.TryDequeue(out TextBox control))
        {
            Assert.DoesNotThrow(() => MdInvokeTextBox.GetText(control));
            //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.GetText(control)));
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void SetText_DoesNotThrow()
    {
        while (_controls.TryDequeue(out TextBox control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeTextBox.SetText(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.SetText(control, value)));
            }
        }
    }
}