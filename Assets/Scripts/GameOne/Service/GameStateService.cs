using Base;
using DCFApixels;

namespace GameOne
{
    public class GameStateService
    {
        public EGameState state;
        
    }


    public enum EGameState
    {
        Init,
        Play,
        Saving,
        Loading,
    }
}