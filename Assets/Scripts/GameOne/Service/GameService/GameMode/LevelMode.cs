namespace GameOne.Service
{
    public class LevelMode : IGameMode
    {
        public ETurn Turn;

        public LevelMode Reset()
        {
            Turn = ETurn.None;
            return this;
        }
        public enum ETurn
        {
            None = 0,
            RoundStart = 1,
            Terrain = 2,
            EnemyAI = 3,
            WaitForPlayerInput = 4,
            PlayerAction = 5,
            EnemyAction = 6,
            RoundEnd = 7,
        
        }
    }
}