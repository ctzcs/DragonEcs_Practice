using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [System.Serializable]
    public partial struct CreateMapEvent:IEcsComponent
    {
        public int width;
        public int height;
    }
    
    
    public partial struct CreateMapEvent
    {
        public void Set(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
