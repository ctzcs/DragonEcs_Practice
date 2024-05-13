using DCFApixels.DragonECS;



namespace GameTwo
{
    [System.Serializable]
    [MetaGroup("GameTwo/MapModule/")]
    public struct Grid:IEcsComponent
    {
        public entlong belongMap;
    }
}
