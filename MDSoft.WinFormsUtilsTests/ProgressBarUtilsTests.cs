using MDSoft.WinFormsUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtilsTests
{
    public class ProgressBarUtilsTests
    {
        #region Private fields and properties

        private ConcurrentQueue<ProgressBar> _progressBars;

        #endregion

        #region Setup & teardown

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Setup)} start.");
            _progressBars = new ConcurrentQueue<ProgressBar>();
            for (var i = 0; i < 10; i++)
                _progressBars.Enqueue(new ProgressBar());
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
            while (_progressBars.TryDequeue(out _)) { }
            TestContext.WriteLine($@"{nameof(Teardown)} complete.");
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        }

        #endregion

        #region Public properties

        [Test]
        public void SetState_DoesNotThrow()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetState_DoesNotThrow)} start.");
            foreach (var progressBar in _progressBars)
            {
                Assert.DoesNotThrow(() => progressBar.SetState(1));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(1)));
                Assert.DoesNotThrow(() => progressBar.SetState(2));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(2)));
                Assert.DoesNotThrow(() => progressBar.SetState(3));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(3)));
            }
            TestContext.WriteLine($@"{nameof(SetState_DoesNotThrow)} complete.");
        }

        #endregion
    }
}
