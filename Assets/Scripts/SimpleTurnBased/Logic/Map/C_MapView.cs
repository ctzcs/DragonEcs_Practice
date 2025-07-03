using DCFApixels.DragonECS;
using UnityEngine;

namespace SimpleTurnBased.Logic.Map
{
    public struct C_MapView:IEcsComponent
    {
        public Vector2 startPoint;
        public float cellSize;
        public GameObject mapRoot;
        public GameObject[,] bottom;
        /*public GameObject[,] mid;
        public GameObject[,] top;*/
    }
}