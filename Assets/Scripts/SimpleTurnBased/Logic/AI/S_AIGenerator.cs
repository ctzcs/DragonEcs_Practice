using Base;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.AI
{
    /// <summary>
    /// AI生成
    /// </summary>
    public class S_AIGenerator:IEcsFixedRunProcess
    {
        [DI] private EcsDefaultWorld _world;
        [DI] private EcsEventWorld _eventWorld;
        class GenAIEvent:EcsAspect
        {
            public EcsPool<Ce_GenAI> genAI = Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _eventWorld.Where(out GenAIEvent genAIEvent))
            {
                ref readonly var genAIEvt = ref ent.Read(genAIEvent.genAI);
                var ai = _world.NewEntityLong();
                var aiCom = new C_AI()
                {
                    aiName = genAIEvt.id,
                };
                ai.Add(ref aiCom);
            }
        }
    }
}