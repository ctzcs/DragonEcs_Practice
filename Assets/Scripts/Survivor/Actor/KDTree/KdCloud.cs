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
        private static readonly Vector3 NullPos = new Vector3(-1000,1000,-1000);

        public void Remove(entlong ent)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] == ent)
                {
                    RemoveAt(i);
                }
            }
        }

        public void UpdateKdTree()
        {
            for (int i = 0; i < points.Count; i++)
            {
                tree.Points[i] = points[i];
            }

            for (int i = points.Count; i < tree.Count; i++)
            {
                tree.Points[i] = NullPos;
            }
            tree.Rebuild();
        }

        void RemoveAt(int index)
        {
            int lastIndex = entities.Count - 1;
            entities[index] = entities[lastIndex];
            points[index] = points[lastIndex];
            entities.RemoveAt(lastIndex);
            points.RemoveAt(lastIndex);
        }
    }
}