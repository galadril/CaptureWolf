using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace CaptureWolf
{
    public class Program
    {
        private static void Init(bool silent)
        {
            Console.WriteLine("    @(#                   #(       ");
            Console.WriteLine("    #.((# *(((((((((((@@@((*       ");
            Console.WriteLine("    # .%(((#(((((((((@(((&.        ");
            Console.WriteLine("    / #///////////////////(&#      ");
            Console.WriteLine("   .//////////////////////////     ");
            Console.WriteLine("   (/////     /////&    /////%     ");
            Console.WriteLine(" &///////. %@  /#//  @@ ///////(   ");
            Console.WriteLine("  (/////////&  &//  (,/////////    ");
            Console.WriteLine("   &,         .///*          @     ");
            Console.WriteLine("    , .    .  (@@&@  , *           ");
            Console.WriteLine("      .., * ,  @*,, (.%# .#..     ");
            Console.WriteLine("             .,@#@&                ");
            Console.WriteLine("              .   ,,               ");
            Console.WriteLine("                                   ");
            if (silent) return;

            Console.WriteLine("Are you ready to capture/lure some wolves?? (Y/N)");
            var response = Console.ReadLine();
            if (string.Compare(response, "N", StringComparison.OrdinalIgnoreCase) != 0) return;
            Environment.Exit(0);
            return;
        }

        private static void Main(string[] args)
        {
            var silent = args is { Length: > 0 } && !string.IsNullOrEmpty(args[0]) && (string.Compare(args[0], "/silent", StringComparison.OrdinalIgnoreCase) == 0 ||
                string.Compare(args[0], "/s", StringComparison.OrdinalIgnoreCase) == 0);

            Handler.PreventScreenSaver(true);
            Init(silent);
            Handler.MinimizeAll();
            Handler.HookupEvents(OnCapture);
            Application.Run(new ApplicationContext());
        }

        private static bool OnCapture(Image image)
        {
            try
            {
                var location = System.Reflection.Assembly.GetEntryAssembly()?.Location;
                if (location == null)
                    return false;

                var dir = location[..location.LastIndexOf(@"\", StringComparison.Ordinal)] +
                          "\\captured";
                Directory.CreateDirectory(dir);
                var newFile = dir + "\\wolf" +
                              Guid.NewGuid().ToString() + ".jpg";

                using var fs = new FileStream(newFile, FileMode.Create);
                Console.WriteLine($"Writing image: {newFile}");
                image.Save(fs, ImageFormat.Jpeg);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
