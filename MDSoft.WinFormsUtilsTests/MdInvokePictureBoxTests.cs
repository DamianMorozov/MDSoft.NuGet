// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace MDSoft.WinFormsUtilsTests;

public class MdInvokePictureBoxTests
{
    #region Private fields and properties

    private ConcurrentQueue<PictureBox> _pictureBoxes = new();
    private Image _image;
    private Bitmap _bitmap;

    #endregion

    /// <summary>
    /// Setup private fields.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _pictureBoxes = new();
        for (int i = 0; i < 10; i++)
        {
            _pictureBoxes.Enqueue(new());
        }
        string filePng = @"c:\Windows\ImmersiveControlPanel\images\splashscreen.png";
        if (File.Exists(filePng))
        {
            _image = Image.FromFile(filePng);
            _bitmap = (Bitmap)Image.FromFile(filePng);
        }
    }

    /// <summary>
    /// Reset private fields to default state.
    /// </summary>
    [TearDown]
    public void Teardown()
    {
        while (_pictureBoxes.TryDequeue(out _)) { }
    }

    [Test]
    public void SetBackgroundImage_DoesNotThrow()
    {
        foreach (PictureBox pictureBox in _pictureBoxes)
        {
            Assert.DoesNotThrow(() => MdInvokePictureBox.SetBackgroundImage(pictureBox, _image));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokePictureBox.SetBackgroundImage(pictureBox, _image)));
        }
    }

    [Test]
    public void SetBitmap_DoesNotThrow()
    {
        foreach (PictureBox pictureBox in _pictureBoxes)
        {
            Assert.DoesNotThrow(() => MdInvokePictureBox.SetBitmap(pictureBox, _bitmap));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokePictureBox.SetBitmap(pictureBox, _bitmap)));
        }
    }

    [Test]
    public void SetImage_DoesNotThrow()
    {
        foreach (PictureBox pictureBox in _pictureBoxes)
        {
            Assert.DoesNotThrow(() => MdInvokePictureBox.SetImage(pictureBox, _bitmap));
            Assert.DoesNotThrowAsync(async () => await Task.Run(() => MdInvokePictureBox.SetImage(pictureBox, _bitmap)));
        }
    }
}