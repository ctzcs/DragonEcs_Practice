using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace Base
{
    public interface IComponentSubject<TComponent> where TComponent:struct,IEcsComponent
    {
        public List<IList<TComponent>> ListenersBuffer { get; set; }
    }
}