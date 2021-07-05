using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CaptureWolf
{
    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the SwMinimize.
        /// </summary>
        internal const Int32 SwMinimize = 6;

        /// <summary>
        /// Defines the HwndBroadcast.
        /// </summary>
        private const int HwndBroadcast = 0xFFFF;

        /// <summary>
        /// Defines the ScMonitorpower.
        /// </summary>
        private const int ScMonitorpower = 0xF170;

        /// <summary>
        /// Defines the ShutOffDisplay.
        /// </summary>
        private const int ShutOffDisplay = 2;

        /// <summary>
        /// Defines the WmSyscommand.
        /// </summary>
        private const int WmSyscommand = 0x0112;

        /// <summary>
        /// Defines the _onlyOnce.
        /// </summary>
        private static bool _onlyOnce;

        /// <summary>
        /// Defines the camera.
        /// </summary>
        private static WebCam camera;

        /// <summary>
        /// Defines the ExecutionState.
        /// </summary>
        [FlagsAttribute]
        public enum ExecutionState : uint
        {
            /// <summary>
            /// Defines the EsAwaymodeRequired.
            /// </summary>
            EsAwaymodeRequired = 0x00000040,
            /// <summary>
            /// Defines the EsContinuous.
            /// </summary>
            EsContinuous = 0x80000000,
            /// <summary>
            /// Defines the EsDisplayRequired.
            /// </summary>
            EsDisplayRequired = 0x00000002,
            /// <summary>
            /// Defines the EsSystemRequired.
            /// </summary>
            EsSystemRequired = 0x00000001
        }

        /// <summary>
        /// The SetThreadExecutionState.
        /// </summary>
        /// <param name="esFlags">The esFlags<see cref="ExecutionState"/>.</param>
        /// <returns>The <see cref="ExecutionState"/>.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

        /// <summary>
        /// Catch the wolf!!.
        /// </summary>
        private static void CatchWolf()
        {
            if (_onlyOnce)
                return;
            _onlyOnce = true;

            Console.WriteLine("Capturing a WOLF!!!");
            LockWorkStation();
            TakeSnapshot();
            PreventScreenSaver(false);

            camera.Stop();
            Environment.Exit(0);
        }

        /// <summary>
        /// The GetConsoleWindow.
        /// </summary>
        /// <returns>The <see cref="IntPtr"/>.</returns>
        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        /// <summary>
        /// The HookupEvents.
        /// </summary>
        private static void HookupEvents()
        {
            Hook.GlobalEvents().MouseMove += (sender, e) =>
            {
                CatchWolf();
            };
            Hook.GlobalEvents().KeyUp += (sender, e) =>
            {
                if (e.Shift && Keys.W == e.KeyCode)
                    return;
                CatchWolf();
            };
        }

        /// <summary>
        /// The Init.
        /// </summary>
        /// <param name="silent">The silent<see cref="bool"/>.</param>
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

        /// <summary>
        /// Lock workstation.
        /// </summary>
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();

        /// <summary>
        /// The main program class.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        private static void Main(string[] args)
        {
            var silent = args is { Length: > 0 } && !string.IsNullOrEmpty(args[0]) && (string.Compare(args[0], "/silent", StringComparison.OrdinalIgnoreCase) == 0 ||
                string.Compare(args[0], "/s", StringComparison.OrdinalIgnoreCase) == 0);

            PreventScreenSaver(true);

            Init(silent);

            MinimizeAll();
            HookupEvents();
            Application.Run(new ApplicationContext());
        }

        /// <summary>
        /// Minimize all windows.
        /// </summary>
        private static void MinimizeAll()
        {
            var thisProcess =
                Process.GetCurrentProcess();
            var processes =
                Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process == thisProcess) continue;
                var handle = process.MainWindowHandle;
                if (handle == System.IntPtr.Zero) continue;
                ShowWindow(handle, SwMinimize);
            }
        }

        /// <summary>
        /// Minimize this windows.
        /// </summary>
        private static void MinimizeConsoleWindow()
        {
            var hWndConsole = GetConsoleWindow();
            ShowWindow(hWndConsole, SwMinimize);
        }

        /// <summary>
        /// Post a message.
        /// </summary>
        /// <param name="hWnd">The hWnd<see cref="IntPtr"/>.</param>
        /// <param name="msg">The msg<see cref="uint"/>.</param>
        /// <param name="wParam">The wParam<see cref="IntPtr"/>.</param>
        /// <param name="lParam">The lParam<see cref="IntPtr"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint msg,
            IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Prevent screen saver or not.
        /// </summary>
        /// <param name="sw">The sw<see cref="bool"/>.</param>
        private static void PreventScreenSaver(bool sw)
        {
            if (sw)
                SetThreadExecutionState(ExecutionState.EsDisplayRequired | ExecutionState.EsContinuous);
            else
                SetThreadExecutionState(ExecutionState.EsContinuous);
        }

        /// <summary>
        /// Set the ShowWindow value.
        /// </summary>
        /// <param name="hWnd">The hWnd<see cref="IntPtr"/>.</param>
        /// <param name="nCmdShow">The nCmdShow<see cref="Int32"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);

        /// <summary>
        /// Take the snapshot.
        /// </summary>
        private static void TakeSnapshot()
        {
            try
            {
                camera = new WebCam(new Size(1280, 960), 30);
                camera.Start();

                Image capturedImage = null;
                var counter = 0;
                while (capturedImage == null || counter >= 5)
                {
                    capturedImage = camera.CurrentImage;
                    counter++;
                }

                var location = System.Reflection.Assembly.GetEntryAssembly()?.Location;
                if (location == null) return;
                var dir = location[..location.LastIndexOf(@"\", StringComparison.Ordinal)] +
                          "\\captured";
                Directory.CreateDirectory(dir);
                var newFile = dir + "\\wolf" +
                              Guid.NewGuid().ToString() + ".jpg";
                using var fs = new FileStream(newFile, FileMode.Create);
                Console.WriteLine($"Writing image: {newFile}");
                capturedImage.Save(fs, ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
