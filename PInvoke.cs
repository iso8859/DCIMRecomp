using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace uData
{
    public class PInvoke
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool CreateDirectory(string lpPathName, IntPtr lpSecurityAttributes);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool DeleteFile(string lpFileName);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool SetFileAttributes(string lpFileName, uint dwFileAttributes);

        [DllImport("wtsapi32.dll", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static internal extern bool WTSQuerySessionInformationW(System.IntPtr hServer, uint SessionId, int WtsClassInfo, out string buffer, out uint size);

        [DllImport("user32.dll", SetLastError = false)]
        static public extern IntPtr GetDesktopWindow();

        static public string GetCurrentStationName()
        {
            string result = string.Empty;
            string name = string.Empty;
            uint size = 0;
            if (WTSQuerySessionInformationW(System.IntPtr.Zero, 0, 6, out name, out size))
                result = name;
            return result;
        }

        [DllImport("kernel32.dll")]
        static extern bool ProcessIdToSessionId(uint dwProcessId, out uint pSessionId);

        static public uint GetSessionId()
        {
            uint result = uint.MaxValue;
            ProcessIdToSessionId((uint)Process.GetCurrentProcess().Id, out result);
            return result;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern public bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        enum GetWindow_Cmd : uint {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        static public List<IntPtr> GetChildWindowHandles(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            IntPtr tmp = GetWindow(parent, GetWindow_Cmd.GW_CHILD);
            do
            {
                result.Add(tmp);
                tmp = GetWindow(tmp, GetWindow_Cmd.GW_HWNDNEXT);
            }
            while (tmp != IntPtr.Zero);

            return result;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public static string GetWindowText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [DllImport("rpcrt4.dll", SetLastError = true)]
        public static extern int UuidCreateSequential(out Guid guid);
    }
}
