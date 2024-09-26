using DCFApixels.DragonECS;

namespace Survivor.Ability
{
    
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


    }
}