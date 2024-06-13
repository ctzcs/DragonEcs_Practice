using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
    [MetaDescription("地表物体的容器")]
    [Serializable]
    public partial struct GroundContainer : IEcsComponent
    {
        public entlong groundEntity;
    }

    [Serializable]
    class GroundContainerTemplate : ComponentTemplate<GroundContainer>
    {
    }
}