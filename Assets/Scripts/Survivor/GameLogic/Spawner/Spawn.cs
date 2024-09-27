using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.GameLogic
{
    [MetaGroup("Survivor/Spawner")]
    [Serializable]
    public struct Act_Spawn:IEcsComponent
    {
        /// <summary>
        /// 生成的对象的Id
        /// </summary>
        public string id;

        /// <summary>
        /// 生成对象的类型
        /// </summary>
        public string genType;
        
        /// <summary>
        /// 生成的逻辑位置
        /// </summary>
        public Vector2 position;
    }

    
    public struct Evt_Spawn : IEcsComponent
    {
        public Vector3 position;
    }
}