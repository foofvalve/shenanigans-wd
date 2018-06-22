using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Jetmax.Testing.Gui.UnitTests
{
    [TestClass]
    public class ScreenRecorderTests
    {
        const string FileName = "ScreenRecorderTests";

        [TestMethod]
        public void SavesRecordingToWmvFile()
        {
            var saveFolder = Path.GetTempPath();
            var screenRecord = new ScreenRecorder(saveFolder, FileName);

            screenRecord.StartRecording();
            System.Threading.Thread.Sleep(200);
            var recording = screenRecord.StopRecording();

            Assert.IsTrue(File.Exists(recording));
            Assert.IsTrue(new FileInfo(recording).Length > 0);
            Assert.IsTrue(recording.Contains("scr_") && recording.EndsWith("wmv"));
            File.Delete(recording);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NotSupportedException),
            "The given path\'s format is not supported.")]
        public void SavesRecordingThrowExceptionWithInvalidFileName()
        {
            var invalidFileName = "Test:Fail..";
            var saveFolder = Path.GetTempPath();
            var screenRecorder = new ScreenRecorder(saveFolder, invalidFileName);
            screenRecorder.StartRecording();
            Assert.IsNull(screenRecorder);
        }

        [TestMethod]
        [ExpectedException(typeof(Microsoft.Expression.Encoder.ArgumentErrorException),
            "Screen capture output file name not valid.")]
        public void SavesRecordingThrowExceptionWithInvalidSaveFolder()
        {
            var saveFolder = @"Z:\\note*valie\dir:\";
            var screenRecorder = new ScreenRecorder(saveFolder, FileName);
            //creenRecorder.StartRecording();
            Assert.IsNull(screenRecorder);
        }
    }
}