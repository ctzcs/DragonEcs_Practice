
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class DeathSystem:IEcsFixedRunProcess
    {
        [EcsInject] private EcsEventWorld _world;
        
        class Aspect:EcsAspect
        {
            public EcsPool<DeathEvent> DeathEvents = Inc;
        }
        public void FixedRun()
        {
            foreach (var id in _world.Where(out Aspect aspect))
            {
               var deathEvent = aspect.DeathEvents.Get(id);
               EcsDebug.Print($"{deathEvent.name} Death");
               int entityId = deathEvent.who.ID;
               EcsWorld world = EcsWorld.GetWorld(deathEvent.who.WorldID);
               world.TryDelEntity(entityId);
               //销毁该Object
               UnityEngine.Object.Destroy(world.GetPool<GameObjectConnect>().Get(entityId).Connect.gameObject);
               
            }
        }
    }
}