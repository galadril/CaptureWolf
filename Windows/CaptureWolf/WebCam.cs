using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CaptureWolf
{
    public class WebCam
    {
        private readonly int _frameRate;
        public Bitmap CurrentImage;
        private Size? _frameSize;
        private FilterInfoCollection _videoDevices = null;
        private VideoCaptureDevice _videoSource = null;
        public Func<Image, bool> OnCurrentImageChanged;

        public WebCam(int frameRate)
        {
            this._frameRate = frameRate;
            this.CurrentImage = null;
        }

        public WebCam(Size frameSize, int frameRate) : this(frameRate)
        {
            this._frameSize = frameSize;
        }

        public void Start(Func<Image, bool> onChanged = null)
        {
            this.OnCurrentImageChanged = onChanged;

            if (GetCamList().Count == 0)
                throw new Exception("Video device not found");

            _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
            _videoSource.VideoResolution = _frameSize != null ? SelectResolution(_videoSource) : _videoSource.VideoCapabilities.Last();
            if (_frameSize == null)
            {
                _frameSize = new Size(_videoSource.VideoResolution.FrameSize.Width, _videoSource.VideoResolution.FrameSize.Height);
            }
            _videoSource.NewFrame += VideoNewFrame;
            _videoSource.Start();
        }

        public void Stop()
        {
            if (_videoSource is not { IsRunning: true }) return;

            _videoSource.NewFrame -= VideoNewFrame;
            _videoSource.SignalToStop();
            _videoSource.WaitForStop();
            _videoSource = null;
        }

        private static bool ImageConvertCallback()
        {
            return false;
        }

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

        private FilterInfoCollection GetCamList()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            return _videoDevices;
        }

        private void VideoNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            this.CurrentImage = (Bitmap)eventArgs.Frame.GetThumbnailImage(_frameSize?.Width ?? eventArgs.Frame.Width, _frameSize?.Height ?? eventArgs.Frame.Height, ImageConvertCallback, IntPtr.Zero);
            OnCurrentImageChanged?.Invoke(CurrentImage);
        }

        public IEnumerable<Size> GetAvailableResolutions()
        {
            if (_videoSource == null)
            {
                throw new Exception("Video source is not initialized");
            }

            return _videoSource.VideoCapabilities.Select(cap => cap.FrameSize);
        }
    }
}
