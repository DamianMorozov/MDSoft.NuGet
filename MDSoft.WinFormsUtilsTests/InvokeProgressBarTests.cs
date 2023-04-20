// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtilsTests;

public class InvokeProgressBarTests
{
    #region Private fields and properties

    private ConcurrentQueue<ProgressBar> _progressBars = new();

    #endregion

    #region Setup & teardown

    /// <summary>
    /// Setup private fields.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _progressBars = new();
        for (int i = 0; i < 10; i++)
            _progressBars.Enqueue(new());
    }

    /// <summary>
    /// Reset private fields to default state.
    /// </summary>
    [TearDown]
    public void Teardown()
    {
        while (_progressBars.TryDequeue(out _)) { }
    }

    #endregion

    [Test]
    public void SetValue_DoesNotThrow()
    {
        foreach (ProgressBar progressBar in _progressBars)
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetValue(progressBar, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeProgressBar.SetValue(progressBar, value)));
            }
        }
    }

    [Test]
    public void SetMinimum_DoesNotThrow()
    {
        foreach (ProgressBar progressBar in _progressBars)
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetMinimum(progressBar, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeProgressBar.SetMinimum(progressBar, value)));
            }
        }
    }

    [Test]
    public void SetMaximum_DoesNotThrow()
    {
        foreach (ProgressBar progressBar in _progressBars)
        {
            foreach (ushort value in MdEnumValues.GetProgress())
            {
                Assert.DoesNotThrow(() => MdInvokeProgressBar.SetMaximum(progressBar, value));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokeProgressBar.SetMaximum(progressBar, value)));
            }
        }
    }
}