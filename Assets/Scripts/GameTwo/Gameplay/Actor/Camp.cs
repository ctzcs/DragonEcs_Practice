using DCFApixels.DragonECS;

namespace GameTwo
{
    [System.Serializable]
    public struct Camp:IEcsComponent
    {
        public ECamp value;
    }

    public enum ECamp
    {
        Player,
        Enemy,
        Neutral
    }
}
