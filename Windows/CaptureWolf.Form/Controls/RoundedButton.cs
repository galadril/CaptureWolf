namespace CaptureWolf.UI.Controls;

public class RoundedButton : Button
{
    public int Radius { get; set; } = 30; // Default radius

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
        graphicsPath.AddLine(Radius, 0, this.Width - Radius, 0);
        graphicsPath.AddArc(this.Width - Radius, 0, Radius, Radius, 270, 90);
        graphicsPath.AddLine(this.Width, Radius, this.Width, this.Height - Radius);
        graphicsPath.AddArc(this.Width - Radius, this.Height - Radius, Radius, Radius, 0, 90);
        graphicsPath.AddLine(this.Width - Radius, this.Height, Radius, this.Height);
        graphicsPath.AddArc(0, this.Height - Radius, Radius, Radius, 90, 90);
        graphicsPath.AddLine(0, this.Height - Radius, 0, Radius);
        graphicsPath.AddArc(0, 0, Radius, Radius, 180, 90);
        this.Region = new System.Drawing.Region(graphicsPath);
        base.OnPaint(pevent);
    }
}
