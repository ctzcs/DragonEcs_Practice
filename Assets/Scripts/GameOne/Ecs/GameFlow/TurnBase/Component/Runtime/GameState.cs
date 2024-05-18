using System;
using DCFApixels.DragonECS;


namespace GameOne.Ecs
{
    [Serializable]
    public struct GameState : IEcsComponent
    {
        /// <summary>
        /// 现在轮到谁了
        /// </summary>
        public ETurn turn;
        
    }
    
    
    

    public enum ETurn
    {
        None,
        RoundStart,
        Terrain,
        EnemyAI,
        PlayerAction,
        EnemyAction,
        RoundEnd,
        
    }
}