using System.Collections.Generic;
using Base;
using DataStructures.ViliWonka.KDTree;
using DCFApixels.DragonECS;
using Survivor.Global;
using Survivor.Property;
using UnityEngine;

namespace Survivor.Actor
{
    public class KdTreeSystem:IEcsInit,IEcsRun
    {
        private EcsDefaultWorld _world;
        public void Init()
        {
            entlong god = _world.Get<WorldData>().god;
            List<Vector3> cloud = new();
            KdCloud kdCloud = new KdCloud
            {
                points = cloud,
                tree = new KDTree(cloud.ToArray())
            };
            god.Add(ref kdCloud);
            
            
            
        }

        class Aspect:EcsAspect
        {
            public EcsPool<KdAgent> KdAgent = Inc;
            public EcsPool<VelPos> VelPos = Inc;
        }
        public void Run()
        {
            int index = 0;
            entlong god = _world.Get<WorldData>().god;
            ref KdCloud kdCloud = ref god.Get<KdCloud>();
            kdCloud.entities.Clear();
            foreach (var kdAgent in _world.Where(out Aspect aspect))
            {
                aspect.KdAgent.Get(kdAgent).index = index;
                kdCloud.entities.Add(kdAgent.ToEntityLong(_world));
                kdCloud.points.Add(aspect.VelPos.Get(kdAgent).pos);
                ++index;
            }
            
            kdCloud.tree.Build(kdCloud.tree.Points);
        }
    }
    
    
    public static partial class Utils
    {
        private static readonly KDQuery query = new KDQuery();

        public static void KdQuery_Radius(KDTree tree, Vector3 queryPosition, float queryRadius, List<int> resultIndices)
        {
            query.Radius(tree,queryPosition, queryRadius,resultIndices);
        }
            
    }
}