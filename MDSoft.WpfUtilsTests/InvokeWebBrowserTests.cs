// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Controls;
using MDSoft.WpfUtils;

namespace MDSoft.WpfUtilsTests
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class InvokeWebBrowserTests
    {
        #region Private fields and properties

        private ConcurrentQueue<WebBrowser> _controls;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        [Apartment(ApartmentState.STA)]
        public void Setup()
        {
            Utils.MethodStart();
            _controls = new ConcurrentQueue<WebBrowser>();
            for (int i = 0; i < 10; i++)
            {
                _controls.Enqueue(new WebBrowser());
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
        public void SetSource_DoesNotThrow()
        {
            Utils.MethodStart();
            while (_controls.TryDequeue(out WebBrowser control))
            {
                foreach (System.Uri value in EnumValues.GetUri())
                {
                    Assert.DoesNotThrow(() => InvokeWebBrowser.SetSource(control, value));
                    //Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeWebBrowser.SetSource(control, new Uri(value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}