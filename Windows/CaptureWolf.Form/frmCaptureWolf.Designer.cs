using CaptureWolf.UI.Controls;

namespace CaptureWolf.UI;

partial class FrmCaptureWolf : Form
{
    private System.ComponentModel.IContainer components = null;
    private RoundedButton startButton;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label explainLabel;
    private bool mouseDown;
    private Point lastLocation;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaptureWolf));
        startButton = new RoundedButton();
        pictureBox = new PictureBox();
        explainLabel = new Label();
        btnStop = new Button();
        btnConfig = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        SuspendLayout();
        // 
        // startButton
        // 
        startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        startButton.BackColor = Color.FromArgb(0, 38, 71);
        startButton.FlatAppearance.BorderColor = Color.FromArgb(0, 38, 71);
        startButton.FlatStyle = FlatStyle.Flat;
        startButton.ForeColor = Color.White;
        startButton.Location = new Point(168, 291);
        startButton.Name = "startButton";
        startButton.Radius = 50;
        startButton.Size = new Size(184, 49);
        startButton.TabIndex = 0;
        startButton.Text = "Start Luring";
        startButton.UseVisualStyleBackColor = false;
        startButton.Click += startButton_Click;
        // 
        // pictureBox
        // 
        pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
        pictureBox.ImageLocation = "";
        pictureBox.Location = new Point(12, 42);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(495, 234);
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.TabIndex = 1;
        pictureBox.TabStop = false;
        pictureBox.Click += PictureBox_Click;
        // 
        // explainLabel
        // 
        explainLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        explainLabel.BackColor = Color.FromArgb(0, 0, 23);
        explainLabel.ForeColor = Color.White;
        explainLabel.Location = new Point(6, 354);
        explainLabel.Name = "explainLabel";
        explainLabel.Size = new Size(504, 22);
        explainLabel.TabIndex = 2;
        explainLabel.Text = "Sheep stick together, start luring in the Wolves!";
        explainLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnStop
        // 
        btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnStop.BackColor = Color.FromArgb(0, 0, 23);
        btnStop.FlatAppearance.BorderColor = Color.Gray;
        btnStop.FlatStyle = FlatStyle.Flat;
        btnStop.ForeColor = Color.White;
        btnStop.Location = new Point(484, 6);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(31, 27);
        btnStop.TabIndex = 3;
        btnStop.Text = "X";
        btnStop.UseVisualStyleBackColor = false;
        btnStop.Click += BtnStop_Click;
        // 
        // btnConfig
        // 
        btnConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnConfig.BackColor = Color.FromArgb(0, 0, 23);
        btnConfig.FlatAppearance.BorderColor = Color.Gray;
        btnConfig.FlatStyle = FlatStyle.Flat;
        btnConfig.ForeColor = Color.White;
        btnConfig.Location = new Point(447, 6);
        btnConfig.Name = "btnConfig";
        btnConfig.Size = new Size(31, 27);
        btnConfig.TabIndex = 4;
        btnConfig.Text = "⚙";
        btnConfig.UseVisualStyleBackColor = false;
        btnConfig.Click += BtnConfig_Click;
        // 
        // FrmCaptureWolf
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(0, 0, 23);
        ClientSize = new Size(521, 384);
        Controls.Add(btnConfig);
        Controls.Add(btnStop);
        Controls.Add(explainLabel);
        Controls.Add(pictureBox);
        Controls.Add(startButton);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "FrmCaptureWolf";
        Text = "CaptureWolves";
        MouseDown += Form_MouseDown;
        MouseMove += Form_MouseMove;
        MouseUp += Form_MouseUp;
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        ResumeLayout(false);
    }

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
    private Button btnConfig;
}
