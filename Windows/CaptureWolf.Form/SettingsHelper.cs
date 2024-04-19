namespace CaptureWolf.UI;

public static class SettingsHelper
{
    public static void InitializeSettingsIfEmpty()
    {
        if (!string.IsNullOrEmpty(Properties.Settings.Default.Resolution) &&
            !string.IsNullOrEmpty(Properties.Settings.Default.Camera))
        {
            return;
        }

        var webcam = new WebCam(Properties.Settings.Default.Camera);
        webcam.Start(); // Start the webcam

        try
        {
            SetupCamera(webcam);
            SetupResolution(webcam);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            webcam.Stop(); // Stop the webcam
        }
    }

    private static void SetupCamera(WebCam webcam)
    {
        var selectedCamera = Properties.Settings.Default.Camera;
        if (!string.IsNullOrEmpty(selectedCamera))
        {
            return;
        }

        var devices = webcam.GetCamList();
        Properties.Settings.Default.Camera = devices?[0].Name;
        Properties.Settings.Default.Save();
    }

    private static void SetupResolution(WebCam webcam)
    {
        var selectedResolution = Properties.Settings.Default.Resolution;
        if (!string.IsNullOrEmpty(selectedResolution))
        {
            return;
        }

        var resolutions = webcam.GetAvailableResolutions();

        var highestResolution = new Size(0, 0);
        var highestHdResolution = new Size(0, 0);
        foreach (var resolution in resolutions)
        {
            // Check if this resolution is higher than the current highest resolution
            if (resolution.Width * resolution.Height > highestResolution.Width * highestResolution.Height)
            {
                highestResolution = resolution;
            }

            // Check if this resolution has an HD aspect ratio and is higher than the current highest HD resolution
            if ((float)resolution.Width / resolution.Height == 16f / 9 && resolution.Width * resolution.Height >
                highestHdResolution.Width * highestHdResolution.Height)
            {
                highestHdResolution = resolution;
            }
        }

        // Store the highest HD resolution in the settings if it's available, otherwise store the highest resolution
        Properties.Settings.Default.Resolution = highestHdResolution.Width != 0
            ? $"{highestHdResolution.Width} x {highestHdResolution.Height}"
            : $"{highestResolution.Width} x {highestResolution.Height}";
        Properties.Settings.Default.Save();
    }
}
