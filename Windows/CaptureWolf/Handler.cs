﻿using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
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
    private static Size _frameSize;
    private static WebCam camera;
    private static Func<Image, bool> onCapture;
    public const byte KEYEVENTF_KEYUP = 0x02;
    public const byte VK_LWIN = 0x5B;
    public const byte VK_D = 0x44;

    public static Size FrameSize { get => _frameSize; set => _frameSize = value; }

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

        Hook.GlobalEvents().MouseMove += GlobalHook_MouseMove;
        Hook.GlobalEvents().KeyUp += GlobalHook_KeyUp;
    }

    private static void GlobalHook_MouseMove(object sender, MouseEventArgs e)
    {
        try
        {
            if (_onlyOnce)
                return;
            _onlyOnce = true;
            Hook.GlobalEvents().MouseMove -= GlobalHook_MouseMove;

            CatchWolf();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    private static void GlobalHook_KeyUp(object sender, KeyEventArgs e)
    {
        try
        {
            if (_onlyOnce)
                return;
            _onlyOnce = true;
            Hook.GlobalEvents().KeyUp -= GlobalHook_KeyUp;

            CatchWolf();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
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
            camera = new WebCam(FrameSize, 30);
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
