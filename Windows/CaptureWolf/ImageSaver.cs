using System.ComponentModel;

namespace CaptureWolf;

public class ImageSaver
{
    private readonly BackgroundWorker _worker = new();
    private EventHandler<RunWorkerCompletedEventArgs> _whenCompleted;

    public ImageSaver()
    {
        _worker.DoWork += Worker_DoWork;
        _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
    }

    public void SaveImage(string fileName, Image image, bool addWaterMark)
    {
        if (addWaterMark)
        {
            _worker.RunWorkerAsync(Tuple.Create(fileName, image));
        }
        else
        {
            image.Save(fileName);
            _whenCompleted?.Invoke(this, null);
        }
    }

    private void Worker_DoWork(object sender, DoWorkEventArgs e)
    {
        var args = (Tuple<string, Image>)e.Argument;
        var fileName = args?.Item1;
        var image = args?.Item2;

        if(string.IsNullOrEmpty(fileName) || image == null)
            return;

        using var watermarkImage = Image.FromFile("icon.png");
        var newHeight = image.Height / 3;
        var newWidth = (int)(watermarkImage.Width * ((double)newHeight / watermarkImage.Height));
        var resizedWatermarkImage = new Bitmap(watermarkImage, new Size(newWidth, newHeight));

        using var imageWithWatermark = new Bitmap(image);

        using var graphics = Graphics.FromImage(imageWithWatermark);
        var watermarkPosition = new Point(imageWithWatermark.Width - resizedWatermarkImage.Width - 20, 20);
        var pen = new Pen(Color.FromArgb(0, 0, 23), 250);

        var maxLabelWidth = imageWithWatermark.Width * 0.7f; // 80% of image width
        var font = new Font("Arial", 10); // Start with a base font size
        const string text = "Thanks for keeping me sharp!";
        var size = graphics.MeasureString(text, font);

        // Increase font size until the text width exceeds the maximum label width
        while (size.Width < maxLabelWidth)
        {
            font = new Font(font.FontFamily, font.Size + 1);
            size = graphics.MeasureString(text, font);
        }

        // Decrease font size by 1 to ensure the text width does not exceed the maximum label width
        font = new Font(font.FontFamily, font.Size - 1);
        var brush = new SolidBrush(Color.White);
        var format = new StringFormat { Alignment = StringAlignment.Center };

        graphics.DrawRectangle(pen, 0, 0, imageWithWatermark.Width - 1, imageWithWatermark.Height - 1);
        graphics.DrawImage(resizedWatermarkImage, watermarkPosition);
        graphics.DrawString(text, font, brush, imageWithWatermark.Width / 2, imageWithWatermark.Height - font.Height, format);

        imageWithWatermark.Save(fileName);
        e.Result = fileName;
    }

    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _whenCompleted?.Invoke(this, e);
    }

    public void SetOnCompletedEvent(EventHandler<RunWorkerCompletedEventArgs> args)
    {
        _whenCompleted = args;
    }
}
