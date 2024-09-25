using DCFApixels.DragonECS;


namespace GameOne.Ecs
{
    public class PlayerAspect:EcsAspect
    {
        public EcsTagPool<PlayerTag> playerTagPool = Inc;

        public EcsPool<ItemContainer> itemBagPool = Inc;
    }
}