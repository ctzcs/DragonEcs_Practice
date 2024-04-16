using Component;
using DCFApixels.DragonECS;

namespace System
{
    public class DeathSystem:IEcsRun
    {
        [EcsInject] private EcsEventWorld _world;
        
        class Aspect:EcsAspect
        {
            public EcsPool<DeathEvent> DeathEvents = Inc;
        }
        public void Run()
        {
            foreach (var id in _world.Where(out Aspect aspect))
            {
               var deathEvent = aspect.DeathEvents.Get(id);
               EcsDebug.Print($"{deathEvent.name} Death");
               int entityId = deathEvent.who.ID;
               EcsWorld world = EcsWorld.GetWorld(deathEvent.who.WorldID);
               world.TryDelEntity(entityId);
               UnityEngine.Object.Destroy(world.GetPool<GameObjectConnect>().Get(entityId).Connect.gameObject);
               
            }
        }
    }
}