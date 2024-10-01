using System.Collections.Generic;
using DataStructures.ViliWonka.KDTree;
using DCFApixels.DragonECS;
using Survivor.Global;
using UnityEngine;

namespace Survivor
{
    public static partial class Utils
    {
        public static entlong God(this EcsWorld world)
        {
            return world.Get<WorldData>().god;
        }
    }
    
    public static partial class Utils
    {
        private static readonly KDQuery query = new KDQuery();

        public static void KdQuery_Radius(KDTree tree, Vector3 queryPosition, float queryRadius, List<int> resultIndices)
        {
            query.Radius(tree,queryPosition, queryRadius,resultIndices);
        }

        public static void KdQuery_KNearest(KDTree tree, Vector3 queryPosition, int k, List<int> resultIndices, List<float> resultDistances = null)
        {
            query.KNearest(tree,queryPosition,k,resultIndices,resultDistances);
        }

        public static void KdQuery_Interval(KDTree tree, Vector3 min, Vector3 max, List<int> resultIndices)
        {
            query.Interval(tree,min,max,resultIndices);
        }

        public static void KdQuery_Closest(KDTree tree, Vector3 queryPosition, List<int> resultIndices, List<float> resultDistances = null)
        {
            query.ClosestPoint(tree,queryPosition,resultIndices,resultDistances);
        }
            
    }
}