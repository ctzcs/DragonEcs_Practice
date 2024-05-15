using DCFApixels.DragonECS;

namespace Base
{
    public interface IListener<TComponent> where TComponent:struct,IEcsComponent
    {
        void OnValueChange(in entlong entity,in TComponent component);
    }
}