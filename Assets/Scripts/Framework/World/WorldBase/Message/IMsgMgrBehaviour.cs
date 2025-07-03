namespace Framework
{
    public interface IMsgMgrBehaviour:ISerializable
    {
        void OnCreate();
        void OnDestroy();
    }
}