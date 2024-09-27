using DCFApixels.DragonECS;

namespace Survivor.GameLogic
{
    public struct GameState : IEcsComponent
    {
        public int tick;
        public int levelTick;
        public float timeElapsed;
        public float deltaTime;
        public float fixedDeltaTime;
    }
}