using System;
using System.ComponentModel;
using System.Drawing;

namespace CaptureWolf;

public class ImageSaver
{
    private readonly BackgroundWorker _worker = new BackgroundWorker();
    private EventHandler<RunWorkerCompletedEventArgs> _whenCompleted;

    private readonly string[] _funTexts = new string[] 
    {
        "Code Sniffer", "Bug Hunter", "Loop Master", "Syntax Surfer", "Exception Exterminator", 
        "Recursion Wrangler", "Algorithm Whisperer", "Binary Boss", "Data Wrangler", "Git Guru", 
        "Java Juggler", "Python Tamer", "Ruby Rider", "SQL Slinger", "CSS Conqueror", 
        "HTML Hero", "JS Jester", "PHP Phantom", "Swift Swashbuckler", "Kotlin Knight", 
        "C# Sharpshooter", "Rust Ranger", "Go Gopher", "TypeScript Titan", "Shell Sheriff", 
        "Perl Pioneer", "Lua Luminary", "Rascal R", "Scala Scaler", "Groovy Guru", 
        "Haskell Hawk", "Erlang Eagle", "Clojure Conjurer", "Dart Daredevil", "F# Fencer", 
        "Cobol Cowboy", "Fortran Foreman", "Pascal Paladin", "Assembly Archer", "Matlab Magician", 
        "Objective-C Oracle", "CoffeeScript Captain", "Elixir Enchanter", "Vue Viking", 
        "React Ranger", "Angular Angel", "Django Juggernaut", "Flask Falcon", "Laravel Lancer", 
        "Spring Samurai", "Bit Baron", "Query Queen", "Debugging Diva", "Lambda Lord", "Framework Fencer", 
        "Cache Conqueror", "Protocol Paladin", "Network Ninja", "Database Druid", "Server Samurai", 
        "Byte Boss", "Pixel Prince", "Kernel King", "Thread Tsar", "Heap Hero", 
        "Stack Sultan", "Memory Monarch", "Function Pharaoh", "Class Czar", "Interface Imperator", 
        "Method Maestro", "Variable Viscount", "Array Archduke", "Pointer Pope", "Loop Lord", 
        "Boolean Baronet", "Exception Earl", "Recursion Raja", "Syntax Sheikh", "Algorithm Admiral", 
        "Binary Baron", "Commander CSS", "HTML Headman", "JavaScript Jedi", "Python Pharaoh", 
        "Ruby Ruler", "SQL Sultan", "TypeScript Tsar", "Vue Viscount", "React Regent", 
        "Angular Archduke", "Django Duke", "Flask Führer", "Laravel Lord", "Spring Sovereign"
    };

    public ImageSaver()
    {
        _worker.DoWork += Worker_DoWork;
        _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
    }

    public void SaveImage(string fileName, Image image)
    {
        _worker.RunWorkerAsync(Tuple.Create(fileName, image));
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
        var pen = new Pen(Color.FromArgb(0, 0, 23), 175);

        var random = new Random();
        var randomFunText = _funTexts[random.Next(_funTexts.Length)];
        var fontSize = imageWithWatermark.Width * 0.01f;
        var font = new Font("Arial", fontSize);
        var brush = new SolidBrush(Color.White);
        var format = new StringFormat { Alignment = StringAlignment.Center };

        graphics.DrawRectangle(pen, 0, 0, imageWithWatermark.Width - 1, imageWithWatermark.Height - 1);
        graphics.DrawImage(resizedWatermarkImage, watermarkPosition);
        graphics.DrawString(randomFunText, font, brush, imageWithWatermark.Width / 2, imageWithWatermark.Height - font.Height, format);

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
