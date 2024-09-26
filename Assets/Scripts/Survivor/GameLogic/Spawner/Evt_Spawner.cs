using System;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.GameLogic.Spawner
{
    [MetaGroup("Survivor/Spawner")]
    [Serializable]
    public struct Evt_Spawner:IEcsComponent
    {
        /// <summary>
        /// 生成事件的id
        /// </summary>
        public string id;

        /// <summary>
        /// 生成的逻辑位置
        /// </summary>
        public Vector3 position;
    }
}