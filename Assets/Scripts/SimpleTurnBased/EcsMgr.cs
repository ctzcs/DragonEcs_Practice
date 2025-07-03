using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace SimpleTurnBased
{
    public interface IEcs
    {
        EcsDefaultWorld DefaultWorld { get; }
        EcsEventWorld EventWorld { get; }
    }

    public static class ECSMgr
    {
        private static List<IEcs> _ecsList = new();
        public static IEcs CurEcs { get; set; }


        public static void SetCurEcs(IEcs ecs)
        {
            CurEcs = ecs;
        }
        public static void Add<T>(T ecs) where T:IEcs
        {
            _ecsList.Add(ecs);
        }
        public static T Get<T>() where T:IEcs
        {
            foreach (var ecs in _ecsList)
            {
                if (ecs is T result)
                {
                    return result;
                }
            }
            return default;
        }

        public static void Remove<T>() where T : IEcs
        {
            for (int i = _ecsList.Count - 1; i >=0 ; i--)
            {
                if (_ecsList[i] is T result)
                {
                    _ecsList.RemoveAt(i);
                }
            }
        }
        
        
        public static EcsDefaultWorld GetDefaultWorld()
        {
            return CurEcs.DefaultWorld;
        }
        
        public static EcsEventWorld GetEventWorld()
        {
            return CurEcs.EventWorld;
        }
    }
}