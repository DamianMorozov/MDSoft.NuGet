using MDSoft.WinFormsUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtilsTests
{
    public class InvokeControlTests
    {
        #region Private fields and properties

        private ConcurrentQueue<Control> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<Control>();
            for (var i = 0; i < 10; i++)
            {
                _controls.Enqueue(new Label());
                _controls.Enqueue(new Button());
                _controls.Enqueue(new CheckBox());
                _controls.Enqueue(new TextBox());
            }
            Utils.MethodComplete();
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out _)) { }
            Utils.MethodComplete();
        }

        [Test]
        public void SetEnabled_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumValues.GetBool())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetEnabled(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetEnabled(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetText_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetText(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetText(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void AddText_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeControl.AddText(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.AddText(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetVisible_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumValues.GetBool())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetVisible(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetVisible(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetBackColor_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumWinForm.GetColor())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetBackColor(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetBackColor(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetForeColor_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (var value in EnumWinForm.GetColor())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetForeColor(control, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetForeColor(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void Focus_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                Assert.DoesNotThrow(() => InvokeControl.Focus(control));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.Focus(control)));
            }
            Utils.MethodComplete();
        }

        [Test]
        public void Select_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                Assert.DoesNotThrow(() => InvokeControl.Select(control));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.Select(control)));
            }
            Utils.MethodComplete();
        }
    }
}
