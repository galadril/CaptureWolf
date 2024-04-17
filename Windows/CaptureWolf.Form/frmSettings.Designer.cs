using CaptureWolf.UI.Properties;
using System.Windows.Forms;

namespace CaptureWolf.UI
{
    partial class frmSettings
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
            btnStop = new Button();
            btnClose = new Button();
            label = new Label();
            comboBox = new ComboBox();
            lblTitleSettings = new Label();
            SuspendLayout();
            // 
            // btnStop
            // 
            btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStop.BackColor = Color.FromArgb(0, 0, 23);
            btnStop.FlatAppearance.BorderColor = Color.Gray;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(640, 12);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(31, 27);
            btnStop.TabIndex = 4;
            btnStop.Text = "X";
            btnStop.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(0, 0, 23);
            btnClose.FlatAppearance.BorderColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(361, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(31, 27);
            btnClose.TabIndex = 6;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label
            // 
            label.Location = new Point(36, 99);
            label.Name = "label";
            label.Size = new Size(156, 23);
            label.TabIndex = 0;
            label.Text = "Select resolution of camera:";
            // 
            // comboBox
            // 
            comboBox.Location = new Point(36, 125);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(317, 23);
            comboBox.TabIndex = 1;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // lblTitleSettings
            // 
            lblTitleSettings.AutoSize = true;
            lblTitleSettings.BackColor = Color.FromArgb(0, 0, 23);
            lblTitleSettings.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleSettings.ForeColor = Color.White;
            lblTitleSettings.Location = new Point(36, 40);
            lblTitleSettings.Name = "lblTitleSettings";
            lblTitleSettings.Size = new Size(123, 30);
            lblTitleSettings.TabIndex = 5;
            lblTitleSettings.Text = "Preferences";
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 23);
            ClientSize = new Size(404, 194);
            Controls.Add(label);
            Controls.Add(comboBox);
            Controls.Add(btnClose);
            Controls.Add(lblTitleSettings);
            Controls.Add(btnStop);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "frmSettings";
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

        private Button btnStop;
        private Button btnClose;
        private Label label;
        private ComboBox comboBox;
        private Label lblTitleSettings;
    }
}