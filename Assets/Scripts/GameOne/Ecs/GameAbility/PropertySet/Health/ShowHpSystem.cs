using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public class ShowHpSystem:IEcsRun
    {
        [EcsInject]EcsDefaultWorld _world;
        
        public void Run()
        {
            //查询
            foreach (var ent in _world.Where(out PeopleAspect peopleAspect))
            {
                string name = ent.Read(peopleAspect.namePool).name ;
                int health = ent.Read(peopleAspect.healthPool).healthValue;
                //EcsDebug.Print($"{name} : {health}");
            }
        }
    }
}