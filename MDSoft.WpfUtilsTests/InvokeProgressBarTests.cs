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
    public class InvokeProgressBarTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ProgressBar> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<ProgressBar>();
            for (int i = 0; i < 10; i++)
                _controls.Enqueue(new ProgressBar());
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
        public void SetMaximum_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMaximum(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMaximum(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetMinimum_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMinimum(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMinimum(control, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void SetValue_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out ProgressBar control))
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetValue(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetValue(control, value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}