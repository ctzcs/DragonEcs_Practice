using System.Collections.Generic;
using DataStructures.ViliWonka.KDTree;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Actor
{
    public struct KdCloud:IEcsComponent
    {
        public List<entlong> entities;
        public List<Vector3> points;
        public KDTree tree;
    }
}