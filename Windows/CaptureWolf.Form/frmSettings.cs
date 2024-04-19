namespace CaptureWolf.UI
{
    public partial class FrmSettings : Form
    {
        public event Action SettingsChanged;

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
            var webcam = new WebCam(1); // Initialize with your desired frame rate
            webcam.Start(); // Start the webcam

            try
            {
                var resolutions = webcam.GetAvailableResolutions();
                foreach (var resolution in resolutions)
                {
                    comboBox.Items.Add($"{resolution.Width} x {resolution.Height}");
                }

                var selectedResolution = Properties.Settings.Default.Resolution;
                if (!string.IsNullOrEmpty(selectedResolution))
                {
                    comboBox.SelectedItem = selectedResolution;
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
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Store the selected resolution in the settings
            Properties.Settings.Default.Resolution = comboBox.SelectedItem?.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
