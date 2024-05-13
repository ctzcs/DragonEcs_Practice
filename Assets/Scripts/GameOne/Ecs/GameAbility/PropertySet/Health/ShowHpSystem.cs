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
            foreach (var id in _world.Where(out PeopleAspect peopleAspect))
            {
                string name = peopleAspect.namePool.Get(id).name;
                int health = peopleAspect.healthPool.Get(id).healthValue;
                if (peopleAspect.diffLogicPool.Has(id))
                {
                    string logic = peopleAspect.diffLogicPool.Get(id).logic;
                    DesignScript.DiffLogic.onStartDic[logic].Invoke(name);
                }
                
                Debug.Log($"{name} : {health}");
                
                Debug.Log(Mouse.current.position);
            }
        }
    }
}