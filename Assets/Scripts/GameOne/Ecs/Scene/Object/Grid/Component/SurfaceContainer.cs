using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
    [Serializable]
    public partial struct SurfaceContainer : IEcsComponent
    {
        public entlong surfaceEntity;
    }

    [Serializable]
    class SurfaceContainerTemplate : ComponentTemplate<SurfaceContainer>
    {
    }
}