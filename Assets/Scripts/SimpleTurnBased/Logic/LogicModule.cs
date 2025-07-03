using Base;
using DCFApixels.DragonECS;
using SimpleTurnBased.Logic.AI;
using SimpleTurnBased.Logic.Map;
using SimpleTurnBased.Logic.Turn;

namespace SimpleTurnBased.Logic
{
    public class LogicModule:IEcsModule
    {
        public void Import(EcsPipeline.Builder b)
        {
            b.Add(new S_TurnSchedule())
                .Add(new S_MapGenerator())
                .Add(new S_AIGenerator())
                .Add(new S_GenerateMapView(),EcsConsts.END_LAYER);//感觉应该有一个ViewLayer
        }
    }
}