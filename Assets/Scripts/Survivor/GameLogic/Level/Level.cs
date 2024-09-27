using System;
using DCFApixels.DragonECS;

namespace Survivor.GameLogic
{
    [MetaGroup("Survivor/GameLogic")]
    [Serializable]
    public struct Level : IEcsComponent
    {
        //地图数据
        //敌人波次数据
    }

    public struct Evt_LoadLevel : IEcsComponent
    {
        public string id;
    }
    
    public struct Evt_StartLevel : IEcsComponent
    {
        
    }

    public struct Evt_CloseLevel : IEcsComponent
    {
        
    }
    
    
}