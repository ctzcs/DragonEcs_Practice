using DCFApixels.DragonECS;
using DCFApixels.DragonECS.RunnersCore;

namespace Base
{
    public interface IEcsUpdateProcess:IEcsProcess
    {
        void Update();
    }
    public sealed class EcsUpdateRunner:EcsRunner<IEcsUpdateProcess>,IEcsUpdateProcess
    {
        public void Update()
        {
            foreach (var item in Process)
            {
                item.Update();
            }
        }
    }
}