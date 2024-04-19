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

        private void frmSettings_Load(object sender, EventArgs e)
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

            _isLoaded = true;
            chkbMinimize.Checked = Properties.Settings.Default.Minimize;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;
            Properties.Settings.Default.Resolution = cmbResolution.SelectedItem?.ToString();
            Properties.Settings.Default.Save();
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
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

        private void chkbMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (!_isLoaded)
                return;

            Properties.Settings.Default.Minimize = chkbMinimize.Checked;
        }
    }
}
