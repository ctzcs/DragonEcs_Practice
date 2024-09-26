namespace GameOne.Service
{
    public enum EGameState
    {
        Init = 0,
        Play = 1,
        Saving = 2,
        Loading = 3,
    }
    
    /// <summary>
    /// 存储游戏状态
    /// </summary>
    public class GameService
    {
        /// <summary>
        /// 游戏状态
        /// </summary>
        public EGameState State;
        /// <summary>
        /// 游戏模式
        /// </summary>
        public EGameMode GameMode;
        /// <summary>
        /// 当前游戏模式
        /// </summary>
        public IGameMode NowMode;

        public IGameMode SetMode(EGameMode mode)
        {
            switch (mode)
            {
                case EGameMode.LevelMode:
                    GameMode = mode;
                    NowMode = new LevelMode().Reset();
                    break;
            }
            return NowMode;
        }
    }

    

    
    
   
}