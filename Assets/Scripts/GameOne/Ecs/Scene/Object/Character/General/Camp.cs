using DCFApixels.DragonECS;

namespace GameOne.Ecs
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
