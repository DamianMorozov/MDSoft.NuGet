// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WpfUtilsTests;

[TestFixture]
[Apartment(ApartmentState.STA)]
public class MdInvokeListBoxTests
{
    #region Private fields and properties

    private ConcurrentQueue<ListBox> _controls = new();

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
    public void ItemsClear_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ListBox control))
        {
            Assert.DoesNotThrow(() => MdInvokeListBox.ItemsClear(control));
            //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemsClear(control)));
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void ItemAdd_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ListBox control))
        {
            foreach (string value in MdEnumValues.GetString())
            {
                Assert.DoesNotThrow(() => MdInvokeListBox.ItemAdd(control, value));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemAdd(control, value)));
            }
        }
    }

    [Test]
    [Apartment(ApartmentState.STA)]
    public void ItemsGet_DoesNotThrow()
    {
        while (_controls.TryDequeue(out ListBox control))
        {
            Assert.DoesNotThrow(() => MdInvokeListBox.ItemsGet(control));
            //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeListBox.ItemsGet(control)));
        }
    }
}