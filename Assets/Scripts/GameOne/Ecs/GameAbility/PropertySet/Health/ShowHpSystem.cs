using Base;
using DCFApixels.DragonECS;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameOne.Ecs
{
    public class ShowHpSystem:IEcsRun
    {
        [EcsInject]EcsDefaultWorld _world;
        
        public void Run()
        {
            Debug.Log("ShowHpSystem==>Update");
            //查询
            foreach (var ent in _world.Where(out PeopleAspect peopleAspect))
            {
                string name = ent.Read(peopleAspect.namePool).name ;
                int health = ent.Read(peopleAspect.healthPool).healthValue;
                Debug.Log($"{name} : {health}");
                
                Debug.Log(Mouse.current.position);
            }
        }
    }
}