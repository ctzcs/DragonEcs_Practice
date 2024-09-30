
using DCFApixels.DragonECS;
using UnityEngine;


namespace GameOne.Ecs
{
    public struct View : IEcsComponent
    {
        /// <summary>
        /// 连接Transform的位置
        /// </summary>
		public UnityEngine.Transform transform;

        public SpriteRenderer sp;
        
        public Color Color;
        
        public Vector3 prePos;
        public Vector3 nextPos;

        public float preScaleRate;
        public float nextScaleRate;
    }
}