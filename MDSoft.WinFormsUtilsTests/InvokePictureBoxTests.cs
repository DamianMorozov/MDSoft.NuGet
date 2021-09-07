// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using MDSoft.WinFormsUtils;
using NUnit.Framework;
using System.Collections.Concurrent;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSoft.WinFormsUtilsTests
{
    public class InvokePictureBoxTests
    {
        #region Private fields and properties

        private ConcurrentQueue<PictureBox> _pictureBoxes;
        private Image _image;
        private Bitmap _bitmap;

        #endregion

        /// <summary>
        /// Setup private fields.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Utils.MethodStart();
            _pictureBoxes = new ConcurrentQueue<PictureBox>();
            for (int i = 0; i < 10; i++)
            {
                _pictureBoxes.Enqueue(new PictureBox());
            }
            string filePng = @"c:\Windows\ImmersiveControlPanel\images\splashscreen.png";
            if (File.Exists(filePng))
            {
                _image = Image.FromFile(filePng);
                _bitmap = (Bitmap)Image.FromFile(filePng);
            }
            Utils.MethodComplete();
        }

        /// <summary>
        /// Reset private fields to default state.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            Utils.MethodStart();
            while (_pictureBoxes.TryDequeue(out _)) { }
            Utils.MethodComplete();
        }

        [Test]
        public void SetBackgroundImage_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (PictureBox pictureBox in _pictureBoxes)
            {
                Assert.DoesNotThrow(() => InvokePictureBox.SetBackgroundImage(pictureBox, _image));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokePictureBox.SetBackgroundImage(pictureBox, _image)));
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetBitmap_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (PictureBox pictureBox in _pictureBoxes)
            {
                Assert.DoesNotThrow(() => InvokePictureBox.SetBitmap(pictureBox, _bitmap));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokePictureBox.SetBitmap(pictureBox, _bitmap)));
            }
            Utils.MethodComplete();
        }

        [Test]
        public void SetImage_DoesNotThrow()
        {
            Utils.MethodStart();
            foreach (PictureBox pictureBox in _pictureBoxes)
            {
                Assert.DoesNotThrow(() => InvokePictureBox.SetImage(pictureBox, _bitmap));
                Assert.DoesNotThrowAsync(async () => await Task.Run(() => InvokePictureBox.SetImage(pictureBox, _bitmap)));
            }
            Utils.MethodComplete();
        }
    }
}
