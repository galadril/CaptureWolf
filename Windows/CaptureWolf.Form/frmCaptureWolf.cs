using System.ComponentModel;

namespace CaptureWolf.UI;

public partial class frmCaptureWolf : Form
{
    public bool ImageSet = false;
    private readonly ImageSaver _imageSaver;

    public frmCaptureWolf()
    {
        InitializeComponent();

        _imageSaver = new ImageSaver();
        _imageSaver.SetOnCompletedEvent(WhenCompleted);
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        LoadPreferences();

        Handler.PreventScreenSaver(true);
        Handler.MinimizeAll();

        Thread.Sleep(2000);
        Handler.HookupEvents(OnCapture);
    }

    private void WhenCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        explainLabel.Text = e.Error != null
            ? $"Could not save the image."
            : $"Image saved successfully!";
    }

    private void LoadPreferences()
    {
        string resolution = Properties.Settings.Default.Resolution;
        if (!string.IsNullOrEmpty(resolution))
        {
            var parts = resolution.Split('x');
            var width = int.Parse(parts[0].Trim());
            var height = int.Parse(parts[1].Trim());
            var frameSize = new Size(width, height);
            Handler.FrameSize = frameSize;
        }
    }

    private bool OnCapture(Image image)
    {
        pictureBox.Image = image;
        ImageSet = true;
        explainLabel.Text = "We captured one!!! Click the photo to save it.";

        // Bring the current application window to the front
        Invoke(() =>
        {
            WindowState = FormWindowState.Normal;
            Activate();
        });

        SetupTooltip();
        return true;
    }

    private void pictureBox_Click(object sender, EventArgs e)
    {
        if (!ImageSet || pictureBox.Image == null)
            return;

        using var sfd = new SaveFileDialog();
        sfd.FileName = $"capture-{Guid.NewGuid().ToString()}";
        sfd.Filter = @"Images|*.png;*.bmp;*.jpg";
        sfd.DefaultExt = "png";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            _imageSaver.SaveImage(sfd.FileName, pictureBox.Image);
        }
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void SetupTooltip()
    {
        var toolTip = new ToolTip();
        toolTip.AutoPopDelay = 5000;
        toolTip.InitialDelay = 1000;
        toolTip.ReshowDelay = 500;
        toolTip.ShowAlways = true;
        toolTip.BackColor = Color.FromArgb(50, 50, 50); // Dark gray
        toolTip.ForeColor = Color.White;
        toolTip.SetToolTip(this.pictureBox, "Click the image to save it.");
    }

    private void btnConfig_Click(object sender, EventArgs e)
    {
        var settingsForm = new frmSettings();
        settingsForm.ShowDialog();
    }
}
