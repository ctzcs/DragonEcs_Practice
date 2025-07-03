using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.AI
{
    public static class AIExt
    {
        public static void EmitGenAI(this EcsEventWorld world,string id)
        {
            var e = world.NewEntityLong();
            var aiGen = new Ce_GenAI()
            {
                id = id
            };
            e.Add(ref aiGen);
        }
    }
}