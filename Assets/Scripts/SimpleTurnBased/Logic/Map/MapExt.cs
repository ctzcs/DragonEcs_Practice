using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Map
{
    public static class MapExt
    {
        public static void EmitGenMap(EcsEventWorld eventWorld,string id)
        {
            var eGenMap = new Ce_GenMap()
            {
                mapId = id,
            };
            eventWorld.CreateAndAdd(ref eGenMap);
        }
        
        
    }
}