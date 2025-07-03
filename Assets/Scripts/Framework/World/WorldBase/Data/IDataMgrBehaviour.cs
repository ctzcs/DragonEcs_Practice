namespace Framework
{
    public interface IDataMgrBehaviour:ISerializable
    {
        void OnCreate();
        void OnDestroy();
    }
}