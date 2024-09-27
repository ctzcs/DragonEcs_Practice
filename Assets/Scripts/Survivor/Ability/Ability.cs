using System;
using System.Collections.Generic;
using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor.Ability
{
    
    [MetaGroup("Survivor/Ablity")]
    [Serializable]
    public struct AbilityCarrier : IEcsComponent
    {
        public List<string> HasAbilityId;
        
        
    }

    [MetaGroup("Survivor/Ability")]
    [Serializable]
    public struct Ability : IEcsComponent
    {
        //Config
        public string id;
        public int level;
        public int lifeTime;
        public int intervalTime;//触发间隔时间
        public string spawn;
        public string interval;
        public string remove;
        public string beforeLevUp;
        
        //Auto
        public AbilityConfig config;
        public entlong belongTo;
        public int elapsedTime;//流逝时间
        public int power;

    }
    
    /// <summary>
    /// 在某时某地产生某个能力
    /// </summary>
    public struct CastAbilityInfo:IEcsComponent
    {
        /// <summary>
        /// 技能发出者
        /// </summary>
        public entlong caster;

        /// <summary>
        /// 技能Id
        /// </summary>
        public string abilityId;

        /// <summary>
        /// 发出行为的位置
        /// </summary>
        public Vector2 actPos;
        
        /// <summary>
        /// 发出方式
        /// </summary>
        public ECastType castType;
        
        /// <summary>
        /// 发出延迟,为0的时候发出技能
        /// </summary>
        public int delay;
        
    }

    
    public struct Tag_PlayerCast:IEcsTagComponent
    {
        
    }


    public class AbilityConfig
    {
        public string id;
        public int power;
    }
    
    public enum ECastType
    {
        None,
        FollowCaster,
        
    }
    
    
    
    
    
}