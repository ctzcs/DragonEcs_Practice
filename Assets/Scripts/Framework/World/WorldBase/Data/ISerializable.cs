

namespace Framework
{
    public interface ISerializable
    {
        void OnSave();
        void OnLoad(object data);
    }
}