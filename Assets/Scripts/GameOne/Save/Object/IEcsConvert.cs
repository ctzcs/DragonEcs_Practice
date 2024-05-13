using DCFApixels.DragonECS;

namespace GameOne
{
    public interface IEcsConverter<out T>
    {
        T GetDataFromEcs(entlong entityId);
    }
}