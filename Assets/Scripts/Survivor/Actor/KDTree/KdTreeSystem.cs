using System.Collections.Generic;
using Base;
using DataStructures.ViliWonka.KDTree;
using DCFApixels.DragonECS;
using Survivor.Global;
using Survivor.Property;
using UnityEngine;

namespace Survivor.Actor
{
    public class KdTreeSystem:IEcsInit,IEcsFixedRunProcess
    {
        [EcsInject]private EcsDefaultWorld _world;
        public void Init()
        {
            entlong god = _world.God();
            List<Vector3> cloud = new(10000);
            KdCloud kdCloud = new KdCloud
            {
                points = cloud,
                entities = new List<entlong>(),
                tree = new KDTree(cloud.ToArray()),
                
            };
            god.Add(ref kdCloud);
            
        }

        class Aspect:EcsAspect
        {
            public EcsPool<KdAgent> KdAgent = Inc;
            //TODO 这里用的GameOne中的LogicTransform
            public EcsPool<VelPos> VelPos = Inc;
            //public EcsPool<LogicTransform> VelPos = Inc;
        }

        public void FixedRun()
        {
            /*
             * 重建点云
             * 重建树
             */
            int index = 0;
            entlong god = _world.Get<WorldData>().god;
            ref KdCloud kdCloud = ref god.Get<KdCloud>();
            kdCloud.entities.Clear();
            kdCloud.points.Clear();
            foreach (var kdAgent in _world.Where(out Aspect aspect))
            {
                aspect.KdAgent.Get(kdAgent).index = index;
                kdCloud.entities.Add(kdAgent.ToEntityLong(_world));
                
                kdCloud.points.Add(aspect.VelPos.Get(kdAgent).position);
                
                ++index;
            }
            
            kdCloud.tree.Build(kdCloud.points);
        }
    }
}