using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    public struct NowTurn:IEcsComponent
    {
        public EWhoTurn now;
    }


    public enum EWhoTurn
    {
        
    }
}
