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
            SuspendLayout();
            // 
            // label
            // 
            label.Location = new Point(103, 494);
            label.Margin = new Padding(9, 0, 9, 0);
            label.Name = "label";
            label.Size = new Size(446, 74);
            label.TabIndex = 0;
            label.Text = "Resolution";
            // 
            // cmbResolution
            // 
            cmbResolution.Location = new Point(103, 577);
            cmbResolution.Margin = new Padding(9, 10, 9, 10);
            cmbResolution.Name = "cmbResolution";
            cmbResolution.Size = new Size(898, 56);
            cmbResolution.TabIndex = 1;
            cmbResolution.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // lblTitleSettings
            // 
            lblTitleSettings.AutoSize = true;
            lblTitleSettings.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleSettings.ForeColor = Color.White;
            lblTitleSettings.Location = new Point(103, 128);
            lblTitleSettings.Margin = new Padding(9, 0, 9, 0);
            lblTitleSettings.Name = "lblTitleSettings";
            lblTitleSettings.Size = new Size(366, 85);
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
            btnStop.Location = new Point(1107, 19);
            btnStop.Margin = new Padding(9, 10, 9, 10);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(89, 86);
            btnStop.TabIndex = 6;
            btnStop.Text = "X";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Location = new Point(103, 279);
            label1.Margin = new Padding(9, 0, 9, 0);
            label1.Name = "label1";
            label1.Size = new Size(446, 74);
            label1.TabIndex = 7;
            label1.Text = "Camera";
            // 
            // cmbCamera
            // 
            cmbCamera.Location = new Point(103, 362);
            cmbCamera.Margin = new Padding(9, 10, 9, 10);
            cmbCamera.Name = "cmbCamera";
            cmbCamera.Size = new Size(898, 56);
            cmbCamera.TabIndex = 8;
            cmbCamera.SelectedIndexChanged += cmbCamera_SelectedIndexChanged;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 38, 71);
            ClientSize = new Size(1214, 789);
            Controls.Add(label1);
            Controls.Add(cmbCamera);
            Controls.Add(btnStop);
            Controls.Add(label);
            Controls.Add(cmbResolution);
            Controls.Add(lblTitleSettings);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(9, 10, 9, 10);
            MaximizeBox = false;
            Name = "FrmSettings";
            Text = "Preferences";
            Load += frmSettings_Load;
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
    }
}