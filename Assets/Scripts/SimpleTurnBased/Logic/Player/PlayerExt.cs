using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Player
{
    public static class PlayerExt
    {
        public static void EmitGenPlayer(this EcsEventWorld world,string id)
        {
            var genPlayer = new Ce_GenPlayer()
            {
                id = id,
            };
            world.CreateAndAdd(ref genPlayer);
        }
    }
}