namespace CaptureWolf.UI;

partial class frmCaptureWolf : Form
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button startButton;
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaptureWolf));
        startButton = new Button();
        pictureBox = new PictureBox();
        explainLabel = new Label();
        btnStop = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        SuspendLayout();
        // 
        // startButton
        // 
        startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        startButton.BackColor = ColorTranslator.FromHtml("#383838");
        startButton.FlatAppearance.BorderColor = Color.Gray;
        startButton.FlatStyle = FlatStyle.Flat;
        startButton.ForeColor = Color.White;
        startButton.Location = new Point(34, 1171);
        startButton.Margin = new Padding(9, 10, 9, 10);
        startButton.Name = "startButton";
        startButton.Size = new Size(1414, 182);
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
        pictureBox.Location = new Point(54, 132);
        pictureBox.Margin = new Padding(9, 10, 9, 10);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(1370, 992);
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.TabIndex = 1;
        pictureBox.TabStop = false;
        pictureBox.Click += pictureBox_Click;
        // 
        // explainLabel
        // 
        explainLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        explainLabel.AutoSize = true;
        explainLabel.BackColor = ColorTranslator.FromHtml("#2C2C2C");
        explainLabel.ForeColor = Color.White;
        explainLabel.Location = new Point(34, 1387);
        explainLabel.Margin = new Padding(9, 0, 9, 0);
        explainLabel.Name = "explainLabel";
        explainLabel.Size = new Size(770, 48);
        explainLabel.TabIndex = 2;
        explainLabel.Text = "Sheep stick together, start luring in the Wolves!";
        // 
        // btnStop
        // 
        btnStop.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnStop.BackColor = ColorTranslator.FromHtml("#2C2C2C");
        btnStop.FlatAppearance.BorderColor = Color.Gray;
        btnStop.FlatStyle = FlatStyle.Flat;
        btnStop.ForeColor = Color.White;
        btnStop.Location = new Point(1382, 19);
        btnStop.Margin = new Padding(9, 10, 9, 10);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(88, 86);
        btnStop.TabIndex = 3;
        btnStop.Text = "X";
        btnStop.UseVisualStyleBackColor = false;
        btnStop.Click += btnStop_Click;
        // 
        // frmCaptureWolf
        // 
        AutoScaleDimensions = new SizeF(20F, 48F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = ColorTranslator.FromHtml("#2C2C2C");
        ClientSize = new Size(1488, 1502);
        Controls.Add(btnStop);
        Controls.Add(explainLabel);
        Controls.Add(pictureBox);
        Controls.Add(startButton);
        ForeColor = Color.White;
        FormBorderStyle = FormBorderStyle.None;
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(9, 10, 9, 10);
        MaximizeBox = false;
        Name = "frmCaptureWolf";
        Text = "CaptureWolves";
        MouseDown += Form_MouseDown;
        MouseMove += Form_MouseMove;
        MouseUp += Form_MouseUp;
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
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
}
