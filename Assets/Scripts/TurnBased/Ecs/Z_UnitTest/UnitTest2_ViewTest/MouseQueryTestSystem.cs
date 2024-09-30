using System.Collections.Generic;
using Base;
using DCFApixels.DragonECS;
using GameOne.Ecs.Input;
using Survivor;
using Survivor.Actor;
using UnityEngine;

namespace GameOne.Ecs.Z_UnitTest
{
    public class MouseQueryTestSystem:IEcsInit,IEcsFixedRunProcess,IEcsRun
    {
        [EcsInject] private EcsDefaultWorld _world;
        private List<int> index;
        
        public void Init()
        {
            index = new();
        }
        

        public void FixedRun()
        {
            /*ref readonly KdCloud kdCloud = ref _world.God().Read<KdCloud>();
            index.Clear();
            Vector3 mouseWorldPos = _world.Get<WorldInput>().mouseWorldPosition;
            mouseWorldPos.z = 0;
            //EcsDebug.Print($"{mouseWorldPos}");
            Survivor.Utils.KdQuery_Radius(kdCloud.tree,mouseWorldPos,1,index);
            EcsPool<View> viewPool = _world.GetPoolInstance<EcsPool<View>>();
            for (int i = 0; i < kdCloud.entities.Count; i++)
            {
                if (index.Contains(i))
                {
                    kdCloud.entities[i].Get(viewPool).Color =  Color.blue;
                    continue;
                }
                kdCloud.entities[i].Get(viewPool).Color = Color.white;
            }*/
        }

        public void Run()
        {
            ref readonly KdCloud kdCloud = ref _world.God().Read<KdCloud>();
            index.Clear();
            Vector3 mouseWorldPos = _world.Get<WorldInput>().mouseWorldPosition;
            mouseWorldPos.z = 0;
            //EcsDebug.Print($"{mouseWorldPos}");
            Survivor.Utils.KdQuery_Radius(kdCloud.tree,mouseWorldPos,1,index);
            EcsPool<View> viewPool = _world.GetPoolInstance<EcsPool<View>>();
            for (int i = 0; i < kdCloud.entities.Count; i++)
            {
                
                kdCloud.entities[i].Get(viewPool).Color = Color.white;
            }

            foreach (var ent in index)
            {
                kdCloud.entities[ent].Get(viewPool).Color =  Color.blue;
            }
        }
    }
}