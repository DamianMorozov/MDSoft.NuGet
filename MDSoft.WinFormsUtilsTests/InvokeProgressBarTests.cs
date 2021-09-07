// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WinFormsUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtilsTests
{
    public class InvokeProgressBarTests
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
            Utils.MethodStart();
            _progressBars = new ConcurrentQueue<ProgressBar>();
            for (int i = 0; i < 10; i++)
                _progressBars.Enqueue(new ProgressBar());
            Utils.MethodComplete();
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            Utils.MethodStart();
            while (_progressBars.TryDequeue(out _)) { }
            Utils.MethodComplete();
        }

        #endregion

        [Test]
        public void SetValue_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (ProgressBar progressBar in _progressBars)
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetValue(progressBar, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetValue(progressBar, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetMinimum_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (ProgressBar progressBar in _progressBars)
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMinimum(progressBar, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMinimum(progressBar, value)));
                }
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetMaximum_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (ProgressBar progressBar in _progressBars)
            {
                foreach (ushort value in EnumValues.GetProgress())
                {
                    Assert.DoesNotThrow(() => InvokeProgressBar.SetMaximum(progressBar, value));
                    Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokeProgressBar.SetMaximum(progressBar, value)));
                }
            }
            Utils.MethodComplete();
        }
    }
}
