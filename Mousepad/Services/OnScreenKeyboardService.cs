using System;
using System.Runtime.InteropServices;

namespace Mousepad.Services
{
    class OnScreenKeyboardService
    {
        public void Toggle()
        {
            //This is not great way to do this, it emulates click on "Toggle touch keyboard" button in system tray, 
            //"Show touch keyboard" in system tray context menu must be active for this to work
            var trayWnd = FindWindow("Shell_TrayWnd", null);
            var nullIntPtr = new IntPtr(0);

            if (trayWnd != nullIntPtr)
            {
                var trayNotifyWnd = FindWindowEx(trayWnd, nullIntPtr, "TrayNotifyWnd", null);
                if (trayNotifyWnd != nullIntPtr)
                {
                    var wnd = FindWindowEx(trayNotifyWnd, nullIntPtr, "TIPBand", null);

                    if (wnd != nullIntPtr)
                    {
                        PostMessage(wnd, (UInt32)Messages.ButtonDown, 1, 65537);
                        PostMessage(wnd, (UInt32)Messages.ButtonUp, 1, 65537);
                    }
                }
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string sClassName, string sAppName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private enum Messages
        {
            ButtonDown = 0x201,
            ButtonUp = 0x202
        }
    }
}

