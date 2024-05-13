using System.Diagnostics;
using Gma.System.MouseKeyHook;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureWolf;

public static class Handler
{
    public const int SwMinimize = 6;
    public const int HwndBroadcast = 0xFFFF;
    public const int ScMonitorpower = 0xF170;
    public const int ShutOffDisplay = 2;
    public const int WmSyscommand = 0x0112;
    private static bool _onlyOnce;
    private static WebCam camera;
    private static Func<Image, bool> onCapture;
    public const byte KEYEVENTF_KEYUP = 0x02;
    public const byte VK_LWIN = 0x5B;
    public const byte VK_D = 0x44;

    public static Size FrameSize { get; set; }
    public static string WebCamName { get; set; }

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
        Console.WriteLine("Capturing a WOLF!!!");
        LockWorkStation();
        PreventScreenSaver(false);

        onCapture?.Invoke(TakeSnapshot());
    }

    public static void HookupEvents(Func<Image, bool> onCaptureEvent)
    {
        _onlyOnce = false; //reset
        onCapture = onCaptureEvent;

        try
        {
            Hook.GlobalEvents().MouseMove += GlobalHook_MouseDetected;
            Hook.GlobalEvents().MouseClick += GlobalHook_MouseDetected;
            Hook.GlobalEvents().MouseDoubleClick += GlobalHook_MouseDetected;
            Hook.GlobalEvents().MouseDown += GlobalHook_MouseDetected;
            Hook.GlobalEvents().KeyUp += GlobalHook_KeyDetected;
            Hook.GlobalEvents().KeyDown += GlobalHook_KeyDetected;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void GlobalHook_MouseDetected(object sender, MouseEventArgs e)
    {
        try
        {
            if (_onlyOnce)
                return;
            _onlyOnce = true;

            UnhookEvents();
            CatchWolf();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void GlobalHook_KeyDetected(object sender, KeyEventArgs e)
    {
        try
        {
            if (_onlyOnce)
                return;
            _onlyOnce = true;

            UnhookEvents();
            CatchWolf();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void UnhookEvents()
    {
        try { Hook.GlobalEvents().MouseMove -= GlobalHook_MouseDetected; } catch (Exception) { /* ignored */ }
        try { Hook.GlobalEvents().MouseClick -= GlobalHook_MouseDetected; } catch (Exception) { /* ignored */ }
        try { Hook.GlobalEvents().MouseDoubleClick -= GlobalHook_MouseDetected; } catch (Exception) { /* ignored */ }
        try { Hook.GlobalEvents().MouseDown -= GlobalHook_MouseDetected; } catch (Exception) { /* ignored */ }
        try { Hook.GlobalEvents().KeyUp -= GlobalHook_KeyDetected; } catch (Exception) { /* ignored */ }
        try { Hook.GlobalEvents().KeyDown -= GlobalHook_KeyDetected; } catch (Exception) { /* ignored */ }
    }

    [DllImport("user32.dll")]
    public static extern void LockWorkStation();

    [DllImport("user32.dll")]
    public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    public static void MinimizeAll()
    {
        keybd_event(VK_LWIN, 0, 0, 0);
        keybd_event(VK_D, 0, 0, 0);
        keybd_event(VK_D, 0, KEYEVENTF_KEYUP, 0);
        keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, 0);
    }

    public static void MinimizeThisApplication()
    {
        ShowWindow(Process.GetCurrentProcess().MainWindowHandle, SwMinimize);
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
    public static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);

    public static Image TakeSnapshot()
    {
        try
        {
            camera = new WebCam(FrameSize, WebCamName);
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
