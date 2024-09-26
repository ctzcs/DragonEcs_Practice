namespace GameOne.Service
{
    public class LevelMode : IGameMode
    {
        /// <summary>
        /// 现在轮到谁了
        /// </summary>
        public ETurn Turn;
        
        
        public LevelMode Reset()
        {
            Turn = ETurn.Wait;
            return this;
        }
        
        public enum ETurn
        {
            Wait = 0,
            RoundStart = 1,
            /// <summary>
            /// 地形效果
            /// </summary>
            Terrain = 2,
            /// <summary>
            /// 敌人思考
            /// </summary>
            EnemyAI = 3,
            /// <summary>
            /// 等待玩家输入
            /// </summary>
            WaitForPlayerInput = 4,
            /// <summary>
            /// 玩家行为
            /// </summary>
            PlayerAction = 5,
            /// <summary>
            /// 敌人行动
            /// </summary>
            EnemyAction = 6,
            /// <summary>
            /// 激活Buff
            /// </summary>
            ActiveBuff,
            /// <summary>
            /// 回合结束
            /// </summary>
            RoundEnd = 7,
        }

        public void Start()
        {
        }

        public void Update(float deltaTime)
        {
        }
    }
}