namespace GameOne.Service
{
    public interface IGameMode
    {
        void Start();

        void Update(float deltaTime);
        
    }
    public enum EGameMode
    {
        LevelMode = 0,
    }
}