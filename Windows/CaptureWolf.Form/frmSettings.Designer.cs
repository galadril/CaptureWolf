namespace CaptureWolf.UI
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label = new Label();
            cmbResolution = new ComboBox();
            lblTitleSettings = new Label();
            btnStop = new Button();
            label1 = new Label();
            cmbCamera = new ComboBox();
            chkbMinimize = new CheckBox();
            chkbWatermark = new CheckBox();
            SuspendLayout();
            // 
            // label
            // 
            label.Location = new Point(42, 243);
            label.Name = "label";
            label.Size = new Size(156, 23);
            label.TabIndex = 0;
            label.Text = "Resolution";
            // 
            // cmbResolution
            // 
            cmbResolution.Location = new Point(42, 265);
            cmbResolution.Name = "cmbResolution";
            cmbResolution.Size = new Size(317, 23);
            cmbResolution.TabIndex = 1;
            cmbResolution.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            // 
            // lblTitleSettings
            // 
            lblTitleSettings.AutoSize = true;
            lblTitleSettings.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleSettings.ForeColor = Color.White;
            lblTitleSettings.Location = new Point(36, 40);
            lblTitleSettings.Name = "lblTitleSettings";
            lblTitleSettings.Size = new Size(123, 30);
            lblTitleSettings.TabIndex = 5;
            lblTitleSettings.Text = "Preferences";
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStop.BackColor = Color.FromArgb(0, 0, 23);
            btnStop.FlatAppearance.BorderColor = Color.Gray;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(387, 6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(31, 27);
            btnStop.TabIndex = 6;
            btnStop.Text = "X";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Location = new Point(42, 185);
            label1.Name = "label1";
            label1.Size = new Size(156, 23);
            label1.TabIndex = 7;
            label1.Text = "Camera";
            // 
            // cmbCamera
            // 
            cmbCamera.Location = new Point(42, 207);
            cmbCamera.Name = "cmbCamera";
            cmbCamera.Size = new Size(317, 23);
            cmbCamera.TabIndex = 8;
            cmbCamera.SelectedIndexChanged += CmbCamera_SelectedIndexChanged;
            // 
            // chkbMinimize
            // 
            chkbMinimize.Location = new Point(42, 92);
            chkbMinimize.Margin = new Padding(1);
            chkbMinimize.Name = "chkbMinimize";
            chkbMinimize.Size = new Size(310, 37);
            chkbMinimize.TabIndex = 9;
            chkbMinimize.Text = "Minimize everything";
            chkbMinimize.CheckedChanged += ChkbMinimize_CheckedChanged;
            // 
            // chkbWatermark
            // 
            chkbWatermark.Location = new Point(42, 135);
            chkbWatermark.Margin = new Padding(1);
            chkbWatermark.Name = "chkbWatermark";
            chkbWatermark.Size = new Size(310, 37);
            chkbWatermark.TabIndex = 10;
            chkbWatermark.Text = "Add watermark frame";
            chkbWatermark.CheckedChanged += ChkbWatermark_CheckedChanged;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 38, 71);
            ClientSize = new Size(425, 319);
            Controls.Add(chkbWatermark);
            Controls.Add(label1);
            Controls.Add(cmbCamera);
            Controls.Add(btnStop);
            Controls.Add(label);
            Controls.Add(cmbResolution);
            Controls.Add(lblTitleSettings);
            Controls.Add(chkbMinimize);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FrmSettings";
            Text = "Preferences";
            Load += FrmSettings_Load;
            MouseDown += Form_MouseDown;
            MouseMove += Form_MouseMove;
            MouseUp += Form_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        #endregion

        private Label label;
        private ComboBox cmbResolution;
        private Label lblTitleSettings;
        private Button btnStop;
        private Label label1;
        private ComboBox cmbCamera;
        private CheckBox chkbMinimize;
        private CheckBox chkbWatermark;
    }
}