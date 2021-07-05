using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Linq;

namespace CaptureWolf
{
    /// <summary>
    /// Defines the <see cref="WebCam" />.
    /// </summary>
    internal class WebCam
    {
        /// <summary>
        /// Defines the _frameRate.
        /// </summary>
        private readonly int _frameRate;

        /// <summary>
        /// Defines the CurrentImage.
        /// </summary>
        public Bitmap CurrentImage;

        /// <summary>
        /// Defines the _frameSize.
        /// </summary>
        private Size _frameSize;

        /// <summary>
        /// Defines the _videoDevices.
        /// </summary>
        private FilterInfoCollection _videoDevices = null;

        /// <summary>
        /// Defines the _videoSource.
        /// </summary>
        private VideoCaptureDevice _videoSource = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebCam"/> class.
        /// </summary>
        /// <param name="frameSize">The frame size<see cref="Size"/>.</param>
        /// <param name="frameRate">The frame rate<see cref="int"/>.</param>
        public WebCam(Size frameSize, int frameRate)
        {
            this._frameSize = frameSize;
            this._frameRate = frameRate;
            this.CurrentImage = null;
        }

        /// <summary>
        /// The Start.
        /// </summary>
        public void Start()
        {
            if (GetCamList().Count == 0)
                throw new Exception("Video device not found");
            
            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.VideoResolution = SelectResolution(_videoSource);
            _videoSource.NewFrame += VideoNewFrame;
            _videoSource.Start();
        }

        /// <summary>
        /// The Stop.
        /// </summary>
        public void Stop()
        {
            if (_videoSource is not { IsRunning: true }) return;

            _videoSource.NewFrame -= VideoNewFrame;
            _videoSource.SignalToStop();
            _videoSource.WaitForStop();
            _videoSource = null;
        }

        /// <summary>
        /// The image convert callback.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool ImageConvertCallback()
        {
            return false;
        }

        /// <summary>
        /// The SelectResolution.
        /// </summary>
        /// <param name="device">The device<see cref="VideoCaptureDevice"/>.</param>
        /// <returns>The <see cref="VideoCapabilities"/>.</returns>
        private static VideoCapabilities SelectResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 1080)
                    return cap;
                if (cap.FrameSize.Width == 1920)
                    return cap;
            }
            return device.VideoCapabilities.Last();
        }

        /// <summary>
        /// Get the cam list.
        /// </summary>
        /// <returns>The <see cref="FilterInfoCollection"/>.</returns>
        private FilterInfoCollection GetCamList()
        {
            _videoDevices =  new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return _videoDevices;
        }

        /// <summary>
        /// Event handler if new frame is ready.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="eventArgs">The eventArgs<see cref="NewFrameEventArgs"/>.</param>
        private void VideoNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.CurrentImage = (Bitmap)eventArgs.Frame.GetThumbnailImage(_frameSize.Width, _frameSize.Height, ImageConvertCallback, IntPtr.Zero);
        }
    }
}
