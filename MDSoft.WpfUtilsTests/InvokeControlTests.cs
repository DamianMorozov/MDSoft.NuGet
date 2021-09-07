// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WpfUtils;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace MDSoft.WpfUtilsTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeControlTests
    {
        #region Private fields and properties

        private ConcurrentQueue<Control> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<Control>();
            for (int i = 0; i < 10; i++)
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
        [Apartment(ApartmentState.STA)]
        public void Teardown()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out _)) { }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Focus_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                Assert.DoesNotThrow(() => InvokeControl.Focus(control));
                //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.Focus(control)));
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetBackground_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (System.Windows.Media.Brush value in EnumWPF.GetBrush())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetBackground(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetBackground(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetForeground_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (System.Windows.Media.Brush value in EnumWPF.GetBrush())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetForeground(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetForeground(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetIsEnabled_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (bool value in EnumValues.GetBool())
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetIsEnabled(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetIsEnabled(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetVisibility_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out Control control))
            {
                foreach (Visibility value in Enum.GetValues(typeof(Visibility)))
                {
                    Assert.DoesNotThrow(() => InvokeControl.SetVisibility(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeControl.SetVisibility(control, value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}