using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne.DesignScript
{
    public class DiffLogic
    {
        public static Dictionary<string, Action<string>> onStartDic = new()
        {
            {"Hello",LogHello},
            {"Fuck",LogFuck}
        };

        private static void LogHello(string name)
        {
            EcsDebug.Print($"Hello {name}");
        }

        private static void LogFuck(string name)
        {
            EcsDebug.Print($"Fuck {name}");
        }
    }
}
