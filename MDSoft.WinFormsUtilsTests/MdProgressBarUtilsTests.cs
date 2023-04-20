// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtilsTests;

public class MdProgressBarUtilsTests
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

    #region Public properties

    [Test]
    public void SetState_DoesNotThrow()
    {
        foreach (ProgressBar progressBar in _progressBars)
        {
            Assert.DoesNotThrow(() => progressBar.SetState(1));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(1)));
            Assert.DoesNotThrow(() => progressBar.SetState(2));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(2)));
            Assert.DoesNotThrow(() => progressBar.SetState(3));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => progressBar.SetState(3)));
        }
    }

    #endregion
}