using System.Windows.Forms;

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
            btnContribute = new Controls.RoundedButton();
            btnReport = new Controls.RoundedButton();
            btnLatestVersion = new Controls.RoundedButton();
            picPreview = new PictureBox();
            lblHorizontalLine = new Label();
            btnPreview = new Controls.RoundedButton();
            lblVersion = new Label();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.Location = new Point(120, 717);
            label.Margin = new Padding(9, 0, 9, 0);
            label.Name = "label";
            label.Size = new Size(446, 74);
            label.TabIndex = 0;
            label.Text = "Resolution";
            // 
            // cmbResolution
            // 
            cmbResolution.Location = new Point(120, 787);
            cmbResolution.Margin = new Padding(9, 10, 9, 10);
            cmbResolution.Name = "cmbResolution";
            cmbResolution.Size = new Size(607, 56);
            cmbResolution.TabIndex = 1;
            cmbResolution.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
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
            btnStop.Location = new Point(1749, 19);
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
            label1.Location = new Point(120, 531);
            label1.Margin = new Padding(9, 0, 9, 0);
            label1.Name = "label1";
            label1.Size = new Size(446, 74);
            label1.TabIndex = 7;
            label1.Text = "Camera";
            // 
            // cmbCamera
            // 
            cmbCamera.Location = new Point(120, 601);
            cmbCamera.Margin = new Padding(9, 10, 9, 10);
            cmbCamera.Name = "cmbCamera";
            cmbCamera.Size = new Size(607, 56);
            cmbCamera.TabIndex = 8;
            cmbCamera.SelectedIndexChanged += CmbCamera_SelectedIndexChanged;
            // 
            // chkbMinimize
            // 
            chkbMinimize.Location = new Point(120, 294);
            chkbMinimize.Name = "chkbMinimize";
            chkbMinimize.Size = new Size(886, 118);
            chkbMinimize.TabIndex = 9;
            chkbMinimize.Text = "Minimize everything";
            chkbMinimize.CheckedChanged += ChkbMinimize_CheckedChanged;
            // 
            // chkbWatermark
            // 
            chkbWatermark.Location = new Point(586, 294);
            chkbWatermark.Name = "chkbWatermark";
            chkbWatermark.Size = new Size(886, 118);
            chkbWatermark.TabIndex = 10;
            chkbWatermark.Text = "Add watermark frame";
            chkbWatermark.CheckedChanged += ChkbWatermark_CheckedChanged;
            // 
            // btnContribute
            // 
            btnContribute.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnContribute.BackColor = Color.FromArgb(0, 0, 23);
            btnContribute.FlatAppearance.BorderColor = Color.FromArgb(0, 38, 71);
            btnContribute.FlatStyle = FlatStyle.Flat;
            btnContribute.ForeColor = Color.White;
            btnContribute.Location = new Point(978, 94);
            btnContribute.Margin = new Padding(9, 10, 9, 10);
            btnContribute.Name = "btnContribute";
            btnContribute.Radius = 50;
            btnContribute.Size = new Size(296, 119);
            btnContribute.TabIndex = 11;
            btnContribute.Text = "Contribute";
            btnContribute.UseVisualStyleBackColor = false;
            btnContribute.Click += btnContribute_Click;
            // 
            // btnReport
            // 
            btnReport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReport.BackColor = Color.FromArgb(0, 0, 23);
            btnReport.FlatAppearance.BorderColor = Color.FromArgb(0, 38, 71);
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.ForeColor = Color.White;
            btnReport.ImageAlign = ContentAlignment.BottomCenter;
            btnReport.Location = new Point(629, 94);
            btnReport.Margin = new Padding(9, 10, 9, 10);
            btnReport.Name = "btnReport";
            btnReport.Radius = 50;
            btnReport.Size = new Size(307, 119);
            btnReport.TabIndex = 12;
            btnReport.Text = "Report bug";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += btnReport_Click;
            // 
            // btnLatestVersion
            // 
            btnLatestVersion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLatestVersion.BackColor = Color.FromArgb(0, 0, 23);
            btnLatestVersion.FlatAppearance.BorderColor = Color.FromArgb(0, 38, 71);
            btnLatestVersion.FlatStyle = FlatStyle.Flat;
            btnLatestVersion.ForeColor = Color.White;
            btnLatestVersion.Location = new Point(1309, 94);
            btnLatestVersion.Margin = new Padding(9, 10, 9, 10);
            btnLatestVersion.Name = "btnLatestVersion";
            btnLatestVersion.Radius = 50;
            btnLatestVersion.Size = new Size(394, 119);
            btnLatestVersion.TabIndex = 13;
            btnLatestVersion.Text = "Check latest version";
            btnLatestVersion.UseVisualStyleBackColor = false;
            btnLatestVersion.Click += btnLatestVersion_Click;
            // 
            // picPreview
            // 
            picPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picPreview.Location = new Point(788, 531);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(1005, 506);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 14;
            picPreview.TabStop = false;
            // 
            // lblHorizontalLine
            // 
            lblHorizontalLine.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblHorizontalLine.BorderStyle = BorderStyle.Fixed3D;
            lblHorizontalLine.Location = new Point(11, 423);
            lblHorizontalLine.Name = "lblHorizontalLine";
            lblHorizontalLine.Size = new Size(1835, 2);
            lblHorizontalLine.TabIndex = 15;
            // 
            // btnPreview
            // 
            btnPreview.BackColor = Color.FromArgb(0, 0, 23);
            btnPreview.FlatAppearance.BorderColor = Color.FromArgb(0, 38, 71);
            btnPreview.FlatStyle = FlatStyle.Flat;
            btnPreview.ForeColor = Color.White;
            btnPreview.ImageAlign = ContentAlignment.BottomCenter;
            btnPreview.Location = new Point(276, 918);
            btnPreview.Margin = new Padding(9, 10, 9, 10);
            btnPreview.Name = "btnPreview";
            btnPreview.Radius = 50;
            btnPreview.Size = new Size(451, 119);
            btnPreview.TabIndex = 16;
            btnPreview.Text = "Preview";
            btnPreview.UseVisualStyleBackColor = false;
            btnPreview.Click += btnPreview_Click;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblVersion.BackColor = Color.FromArgb(0, 38, 71);
            lblVersion.ForeColor = Color.White;
            lblVersion.Location = new Point(188, 1096);
            lblVersion.Margin = new Padding(9, 0, 9, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(1440, 70);
            lblVersion.TabIndex = 17;
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(20F, 48F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 38, 71);
            ClientSize = new Size(1857, 1175);
            Controls.Add(lblVersion);
            Controls.Add(btnPreview);
            Controls.Add(btnLatestVersion);
            Controls.Add(btnReport);
            Controls.Add(btnContribute);
            Controls.Add(chkbWatermark);
            Controls.Add(label1);
            Controls.Add(cmbCamera);
            Controls.Add(btnStop);
            Controls.Add(label);
            Controls.Add(cmbResolution);
            Controls.Add(lblTitleSettings);
            Controls.Add(chkbMinimize);
            Controls.Add(picPreview);
            Controls.Add(lblHorizontalLine);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(9, 10, 9, 10);
            MaximizeBox = false;
            Name = "FrmSettings";
            Text = "Preferences";
            Load += FrmSettings_Load;
            MouseDown += Form_MouseDown;
            MouseMove += Form_MouseMove;
            MouseUp += Form_MouseUp;
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
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

        private PictureBox picPreview;
        private Label label;
        private ComboBox cmbResolution;
        private Label lblTitleSettings;
        private Button btnStop;
        private Label label1;
        private ComboBox cmbCamera;
        private CheckBox chkbMinimize;
        private CheckBox chkbWatermark;
        private Controls.RoundedButton btnContribute;
        private Controls.RoundedButton btnReport;
        private Controls.RoundedButton btnLatestVersion;
        private Label lblHorizontalLine;
        private Controls.RoundedButton btnPreview;
        private Label lblVersion;
    }
}