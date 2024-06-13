using System;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    [MetaGroup("GameOne/Grid/")]
    [MetaDescription("地表容器，用来存放地表")]
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