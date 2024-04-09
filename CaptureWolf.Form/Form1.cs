
namespace CaptureWolf.UI;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        Handler.PreventScreenSaver(true);
        Handler.MinimizeAll();
        Handler.HookupEvents(onCapture);
    }

    private bool onCapture(Image image)
    {
        pictureBox.Image = image;
        explainLabel.Text = "We captured one!!!";
        return true;
    }

    private void pictureBox_Click(object sender, EventArgs e)
    {
        if (pictureBox.Image == null)
            return;

        using SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "Images|*.png;*.bmp;*.jpg";
        sfd.DefaultExt = "png";

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            pictureBox.Image.Save(sfd.FileName);
        }
    }
}
