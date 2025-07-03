using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Framework
{
    public class WindowsConsole:MonoBehaviour
    {
        private bool _isOpen;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("user32.dll")]
        static extern bool IsWindowVisible(IntPtr hWnd);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleOutputCP(uint wCodePageID);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        private static TextWriter oldOutput;

        void Awake()
        {
            oldOutput = Console.Out;
            try
            {
                AllocConsole();
            
                // 隐藏控制台窗口，稍后我们会通过快捷键显示它
                IntPtr handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);

                // 重定向标准输出
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
                
                Console.OutputEncoding = Encoding.UTF8;
                
                Console.WriteLine("Console window created and ready.");
                

            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to create console window: {e.Message}");
            }
        }

        void Update()
        {
            // 使用 F1 键来切换控制台的显示/隐藏
            if (Input.GetKeyDown(KeyCode.F2))
            {
                ToggleConsole();
            }
        }

        void ToggleConsole()
        {
            IntPtr handle = GetConsoleWindow();
            if (handle != IntPtr.Zero)
            {
                bool isVisible = IsWindowVisible(handle);
                ShowWindow(handle, isVisible ? SW_HIDE : SW_SHOW);
            }
        }

        

        void OnDestroy()
        {
            try
            {
                Console.SetOut(oldOutput);
                FreeConsole();
                
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to free console: {e.Message}");
            }
        }

        private static object _lock = new object();
        // 这个方法可以在其他脚本中调用，用于写入控制台
        public static void WriteToConsole(string message,ConsoleColor bg,ConsoleColor font)
        {
            Console.BackgroundColor = bg;
            Console.ForegroundColor = font;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}