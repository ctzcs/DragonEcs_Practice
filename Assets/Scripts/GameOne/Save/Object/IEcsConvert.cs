using DCFApixels.DragonECS;

namespace GameOne.Object
{
    public interface IEcsConverter<out T>
    {
        T GetDataFromEcs(entlong entityId);
    }
}