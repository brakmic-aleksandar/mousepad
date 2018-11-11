using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mousepad
{
    public static class CursorExtensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, EntryPoint = "mouse_event")]
        private static extern void MouseEvent(MouseEventType dwFlags, uint dx, uint dy, int data, uint dwExtraInfo);
        private const short WheelDelta = 120;

        public static void LeftMouseButtonDown(this Cursor cursor)
        {
            MouseEvent(MouseEventType.LeftDown, (uint) cursor.HotSpot.X, (uint) cursor.HotSpot.Y, 0, 0);
        }

        public static void LeftMouseButtonUp(this Cursor cursor)
        {
            MouseEvent(MouseEventType.LeftUp, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, 0, 0);
        }

        public static void RightMouseButtonDown(this Cursor cursor)
        {
            MouseEvent(MouseEventType.RightDown, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, 0, 0);
        }

        public static void RightMouseButtonUp(this Cursor cursor)
        {
            MouseEvent(MouseEventType.RightUp, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, 0, 0);
        }
        
        public static void MiddleMouseButtonDown(this Cursor cursor)
        {
            MouseEvent(MouseEventType.MiddleDown, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, 0, 0);
        }

        public static void MiddleMouseButtonUp(this Cursor cursor)
        {
            MouseEvent(MouseEventType.MiddleUp, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, 0, 0);
        }

        public static void MoveWheel(this Cursor cursor, int amount)
        {
            MouseEvent(MouseEventType.Wheel, (uint)cursor.HotSpot.X, (uint)cursor.HotSpot.Y, WheelDelta * amount, 0);
        }

        public static void Move(this Cursor cursor, int x, int y)
        {
            Cursor.Position = new Point(x, y);
        }

        public static void MoveBy(this Cursor cursor, int x, int y)
        {
            Cursor.Position = new Point(Cursor.Position.X + x, Cursor.Position.Y + y);
        }

        private enum MouseEventType : uint
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10,
            MiddleDown = 0x0020,
            MiddleUp = 0x0020,
            Wheel = 0x0800
        }
    }
}
