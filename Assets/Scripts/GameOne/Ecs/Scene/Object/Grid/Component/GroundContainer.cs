using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
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