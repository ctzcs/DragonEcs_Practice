using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Framework
{
    public class ConsoleAppender
    {
        public void WriteLine(Logger logger, LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                
                case LogLevel.Warn:
                    WindowsConsole.WriteToConsole(message,ConsoleColor.Yellow,ConsoleColor.Black);
                    break;
                case LogLevel.Error:
                    WindowsConsole.WriteToConsole(message,ConsoleColor.Red,ConsoleColor.Black);
                    break;
                case LogLevel.Info:
                default:
                    WindowsConsole.WriteToConsole(message,ConsoleColor.Black,ConsoleColor.White);
                    break;
            }
            
        }
    }
}