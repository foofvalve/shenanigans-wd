using Jetmax.Testing.Gui.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Shouldly;

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

            File.Exists(recording).ShouldBeTrue();
            new FileInfo(recording).Length.ShouldBeGreaterThan(0);
            recording.ShouldSatisfyAllConditions(
                () => recording.ShouldContain("scr"),
                () => recording.ShouldEndWith("wmv")
            );
  
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
            screenRecorder.ShouldBeNull();
        }

        [TestMethod]
        [ExpectedException(typeof(Microsoft.Expression.Encoder.ArgumentErrorException),
            "Screen capture output file name not valid.")]
        public void SavesRecordingThrowExceptionWithInvalidSaveFolder()
        {
            var saveFolder = @"Z:\\note*valie\dir:\";
            var screenRecorder = new ScreenRecorder(saveFolder, FileName);
            screenRecorder.ShouldBeNull();
        }
    }
}