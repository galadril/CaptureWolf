using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureWolf;

public static class Handler
{
    public const Int32 SwMinimize = 6;
    public const int HwndBroadcast = 0xFFFF;
    public const int ScMonitorpower = 0xF170;
    public const int ShutOffDisplay = 2;
    public const int WmSyscommand = 0x0112;
    private static bool _onlyOnce;
    private static WebCam camera;
    private static Func<Image, bool> onCapture;

    [FlagsAttribute]
    public enum ExecutionState : uint
    {
        EsAwaymodeRequired = 0x00000040,
        EsContinuous = 0x80000000,
        EsDisplayRequired = 0x00000002,
        EsSystemRequired = 0x00000001
    }

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern ExecutionState SetThreadExecutionState(ExecutionState esFlags);

    public static void CatchWolf()
    {
        if (_onlyOnce)
            return;
        _onlyOnce = true;

        Console.WriteLine("Capturing a WOLF!!!");
        LockWorkStation();

        var image = TakeSnapshot();
        if (onCapture != null) 
            onCapture.Invoke(image);

        PreventScreenSaver(false);
    }

    public static void HookupEvents(Func<Image, bool> OnCapture)
    {
        onCapture = OnCapture;
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

    [DllImport("user32.dll")]
    public static extern void LockWorkStation();

    public static void MinimizeAll()
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

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint msg,
        IntPtr wParam, IntPtr lParam);

    public static void PreventScreenSaver(bool sw)
    {
        if (sw)
            SetThreadExecutionState(ExecutionState.EsDisplayRequired | ExecutionState.EsContinuous);
        else
            SetThreadExecutionState(ExecutionState.EsContinuous);
    }

    [DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool ShowWindow([In] IntPtr hWnd, [In] Int32 nCmdShow);

    public static Image TakeSnapshot()
    {
        try
        {
            camera = new WebCam(30);
            camera.Start();
            
            Image capturedImage = null;
            var counter = 0;
            while (capturedImage == null && counter < 60)
            {
                capturedImage = camera.CurrentImage;
                counter++;

                if (capturedImage == null)
                {
                    Task.Delay(500).Wait();
                }
            }
            return capturedImage;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            camera.Stop();
        }
    }
}
