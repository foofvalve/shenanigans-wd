using Microsoft.Expression.Encoder.ScreenCapture;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Jetmax.Testing.Gui.Core
{
    public class ScreenRecorder : ScreenCaptureJob
    {
        private readonly string _outputFilePath;

        public ScreenRecorder(string saveDir, string fileName)
        {
            _outputFilePath = Path.Combine(saveDir, "scr" + "_" + DateTime.Now.ToString("s").Replace(":","-") + "_" + fileName + ".wmv");

            int height =
                Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height % 16);
            int width =
                Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width % 16);
            
            ScreenCaptureVideoProfile.Size = new Size(width, height);
            CaptureRectangle = new Rectangle(0, 0, width, height);
            ScreenCaptureVideoProfile.Force16Pixels = true;
            ScreenCaptureVideoProfile.FrameRate = 30;
            CaptureMouseCursor = true;
            ScreenCaptureVideoProfile.Quality = 20;

            ScreenCaptureVideoProfile.AutoFit = true;
            OutputScreenCaptureFileName = _outputFilePath;
        }

        public void StartRecording()
        {
            Start();
        }

        public string StopRecording()
        {
            Stop();

            //this?.Dispose();
            Console.WriteLine(_outputFilePath);
            return _outputFilePath;
        }
    }
}
