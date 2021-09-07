// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WpfUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Controls;

namespace MDSoft.WpfUtilsTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeContentControlTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ContentControl> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<ContentControl>();
            for (int i = 0; i < 10; i++)
            {
                _controls.Enqueue(new Label());
                _controls.Enqueue(new Button());
                _controls.Enqueue(new CheckBox());
            }
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
        public void SetContent_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ContentControl control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeContentControl.SetContent(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetContent(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void AddContent_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ContentControl control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeContentControl.AddContent(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.AddContent(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetDataContext_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ContentControl control))
            {
                foreach (string value in EnumValues.GetString())
                {
                    Assert.DoesNotThrow(() => InvokeContentControl.SetDataContext(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeContentControl.SetDataContext(control, value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}