using System;
namespace CaptureWolf.UI
{
    public partial class frmSettings : Form
    {
        public event Action SettingsChanged;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SettingsChanged != null)
            {
                SettingsChanged();
            }

            Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var webcam = new WebCam(1); // Initialize with your desired frame rate
            webcam.Start(); // Start the webcam
            var resolutions = webcam.GetAvailableResolutions();

            foreach (Size resolution in resolutions)
            {
                comboBox.Items.Add($"{resolution.Width} x {resolution.Height}");
            }

            string selectedResolution = Properties.Settings.Default.Resolution;
            if (!string.IsNullOrEmpty(selectedResolution))
            {
                comboBox.SelectedItem = selectedResolution;
            }

            webcam.Stop(); // Stop the webcam
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the selected resolution in the settings
            Properties.Settings.Default.Resolution = comboBox.SelectedItem?.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
