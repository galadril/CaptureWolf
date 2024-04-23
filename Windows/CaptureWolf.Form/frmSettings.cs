using AForge.Video.DirectShow;

namespace CaptureWolf.UI
{
    public partial class FrmSettings : Form
    {
        public event Action SettingsChanged;
        private bool _isLoaded = false;

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SettingsChanged?.Invoke();
            Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            var webcam = new WebCam(Properties.Settings.Default.Camera); // Initialize with your desired frame rate
            webcam.Start(); // Start the webcam

            try
            {
                var devices = webcam.GetCamList();
                foreach (FilterInfo device in devices)
                {
                    cmbCamera.Items.Add(device.Name);
                }

                var selectedCamera = Properties.Settings.Default.Camera;
                if (!string.IsNullOrEmpty(selectedCamera))
                {
                    cmbCamera.SelectedItem = selectedCamera;
                }

                var resolutions = webcam.GetAvailableResolutions();
                foreach (var resolution in resolutions)
                {
                    cmbResolution.Items.Add($"{resolution.Width} x {resolution.Height}");
                }

                if (!string.IsNullOrEmpty(Properties.Settings.Default.Resolution))
                {
                    cmbResolution.SelectedItem = Properties.Settings.Default.Resolution;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                webcam.Stop(); // Stop the webcam
            }

            chkbMinimize.Checked = Properties.Settings.Default.Minimize;
            chkbWatermark.Checked = Properties.Settings.Default.Watermark;

            _isLoaded = true;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;
            Properties.Settings.Default.Resolution = cmbResolution.SelectedItem?.ToString();
            Properties.Settings.Default.Save();
        }

        private void CmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;
            Properties.Settings.Default.Camera = cmbCamera.SelectedItem?.ToString();
            Properties.Settings.Default.Resolution = null; // Reset
            Properties.Settings.Default.Save();

            cmbResolution.Items.Clear();
            var webcam = new WebCam(Properties.Settings.Default.Camera);
            webcam.Start();

            try
            {
                var resolutions = webcam.GetAvailableResolutions();
                foreach (var resolution in resolutions)
                {
                    cmbResolution.Items.Add($"{resolution.Width} x {resolution.Height}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                webcam.Stop(); // Stop the webcam
            }

            SettingsHelper.InitializeSettingsIfEmpty();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Resolution))
            {
                cmbResolution.SelectedItem = Properties.Settings.Default.Resolution;
            }
        }

        private void ChkbWatermark_CheckedChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;

            Properties.Settings.Default.Watermark = chkbWatermark.Checked;
            Properties.Settings.Default.Save();
        }

        private void ChkbMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;

            Properties.Settings.Default.Minimize = chkbMinimize.Checked;
            Properties.Settings.Default.Save();
        }
        
        private void btnReport_Click(object sender, EventArgs e)
        {
            const string url = "https://github.com/galadril/CaptureWolf/issues/new/choose";
            System.Diagnostics.Process.Start("explorer.exe", url);
        }

        private void btnContribute_Click(object sender, EventArgs e)
        {
            const string  url = "https://github.com/galadril/CaptureWolf";
            System.Diagnostics.Process.Start("explorer.exe", url);
        }

        private void btnLatestVersion_Click(object sender, EventArgs e)
        {
            const string  url = "https://github.com/galadril/CaptureWolf/releases/latest";
            System.Diagnostics.Process.Start("explorer.exe", url);
        }
    }
}
