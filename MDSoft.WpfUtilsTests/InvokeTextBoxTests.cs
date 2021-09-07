// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WpfUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Windows.Controls;

namespace MDSoft.WpfUtilsTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeTextBoxTests
    {
        #region Private fields and properties

        private ConcurrentQueue<TextBox> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<TextBox>();
            for (int i = 0; i < 10; i++)
                _controls.Enqueue(new TextBox());
            Utils.MethodComplete();
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        [Apartment(ApartmentState.STA)]
        public void Teardown()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out _)) { }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Clear_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.Clear(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.Clear(control)));
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddText_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out TextBox control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeTextBox.AddText(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddText(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddTextFormat_DoesNotThrow()
        {
            Utils.MethodStart();
            Stopwatch sw = Stopwatch.StartNew();
            while (_controls.TryDequeue(out TextBox control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeTextBox.AddTextFormat(control, sw, value));
                    foreach (System.DateTime dt in EnumValues.GetDateTime())
                    {
                        Assert.DoesNotThrow(() => InvokeTextBox.AddTextFormat(control, dt, value));
                        TestContext.WriteLine($@"{InvokeTextBox.GetText(control)}");
                    }
                    Assert.DoesNotThrow(() => InvokeTextBox.AddTextFormat(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.AddTextFormat(control, sw, value)));
                }
            }
            sw.Stop();
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void GetText_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out TextBox control))
            {
                Assert.DoesNotThrow(() => InvokeTextBox.GetText(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.GetText(control)));
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetText_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out TextBox control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeTextBox.SetText(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeTextBox.SetText(control, value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}