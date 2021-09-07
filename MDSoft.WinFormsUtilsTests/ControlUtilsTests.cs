// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WinFormsUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtilsTests
{
    public class ControlUtilsTests
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
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _controls = new ConcurrentQueue<Control>();
            for (int i = 0; i < 100; i++)
            {
                _controls.Enqueue(new Label());
                _controls.Enqueue(new Button());
                _controls.Enqueue(new CheckBox());
                _controls.Enqueue(new TextBox());
            }
            TestContext.WriteLine($@"{nameof(Setup)} complete.");
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Teardown)} start.");
            while (_controls.TryDequeue(out _)) { }
            TestContext.WriteLine($@"{nameof(Teardown)} complete.");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        [Test]
        public void SetDoubleBuffered_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetDoubleBuffered_DoesNotThrow)} start.");
            while (_controls.TryDequeue(out Control control))
            {
                Assert.DoesNotThrow(() => control.SetDoubleBuffered(true));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => control.SetDoubleBuffered(true)));
            }
            TestContext.WriteLine($@"{nameof(SetDoubleBuffered_DoesNotThrow)} complete.");
        }
    }
}
