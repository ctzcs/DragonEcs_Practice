
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
        /// <summary>
        /// 插值开始的位置
        /// </summary>
        public Vector3 startPos;
        /// <summary>
        /// 插值结束的位置
        /// </summary>
        public Vector3 targetPos;
        /// <summary>
        ///插值时间流失缓存 
        /// </summary>
        public float elapsedTime;
    }
}