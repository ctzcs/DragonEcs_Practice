using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    /// <summary>
    /// 刷新权限影响
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RefreshTagInfluenceByBuffSystem<T> : IEcsFixedRunProcess 
        where T :struct,IEcsTagComponent
    {
        [DI] EcsDefaultWorld _world;

        public void FixedRun()
        {
        }
    }
}