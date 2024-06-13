using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Map/")]
    [System.Serializable]
    [MetaDescription("地图的基本数据")]
    public partial struct MapModel:IEcsComponent
    {
        public int width;
        public int height;
    }
    
    public partial struct MapModel
    {
        public void Set(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    [System.Serializable]
    class MapInfoTemplate : ComponentTemplate<MapModel>
    {
    }
}
