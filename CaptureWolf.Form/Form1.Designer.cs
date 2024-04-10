namespace CaptureWolf.UI;

partial class Form1: Form
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button startButton;
    private System.Windows.Forms.PictureBox pictureBox;
    private System.Windows.Forms.Label explainLabel;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        startButton = new Button();
        pictureBox = new PictureBox();
        explainLabel = new Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
        SuspendLayout();
        // 
        // startButton
        // 
        startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        startButton.Location = new Point(10, 333);
        startButton.Name = "startButton";
        startButton.Size = new Size(416, 57);
        startButton.TabIndex = 0;
        startButton.Text = "Start Luring";
        startButton.UseVisualStyleBackColor = true;
        startButton.Click += startButton_Click;
        // 
        // pictureBox
        // 
        pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
        pictureBox.ImageLocation = "";
        pictureBox.Location = new Point(12, 12);
        pictureBox.Name = "pictureBox";
        pictureBox.Size = new Size(414, 300);
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox.TabIndex = 1;
        pictureBox.TabStop = false;
        pictureBox.Click += pictureBox_Click;
        // 
        // explainLabel
        // 
        explainLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        explainLabel.AutoSize = true;
        explainLabel.Location = new Point(12, 401);
        explainLabel.Name = "explainLabel";
        explainLabel.Size = new Size(254, 15);
        explainLabel.TabIndex = 2;
        explainLabel.Text = "Sheep stick together, start luring in the Wolves!";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(442, 425);
        Controls.Add(explainLabel);
        Controls.Add(pictureBox);
        Controls.Add(startButton);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "Form1";
        Text = "CaptureWolves";
        ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
