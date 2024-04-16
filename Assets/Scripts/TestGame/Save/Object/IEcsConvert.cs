using DCFApixels.DragonECS;

namespace Object
{
    public interface IEcsConverter<out T>
    {
        T GetDataFromEcs(entlong entityId);
    }
}