using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class HealthChangeSystem:IEcsFixedRunProcess
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject] private EcsEventWorld _eWorld;
        class DamageEventAspect:EcsAspect
        {
            public EcsPool<HealthChangeEvent> DamageEventPool = Inc;
        }

        class CanBeDamageAspect:EcsAspect
        {
            public EcsPool<Health> HealthPool = Inc;
        }
        
        public void FixedRun()
        {
            _world.Where(out CanBeDamageAspect healthAspect);
            
            foreach (var id in _world.Where(out DamageEventAspect damageEventAspect))
            {
               ref HealthChangeEvent healthChangeEvent = ref damageEventAspect.DamageEventPool.Get(id);
               int targetId = healthChangeEvent.toEntity.ID;
               
               if (healthAspect.HealthPool.Has(targetId))
               {
                   ref Health health = ref healthAspect.HealthPool.Get(targetId);
                   //伤害系统
                   health.healthValue += healthChangeEvent.changeValue;
                   Utils.MathExtension.Clamp(ref health.healthValue, health.minHealthValue, health.maxHealthValue);
               }
            }
            
        }
    }
}