namespace Framework
{
    /// <summary>
    /// 逻辑层控制器
    /// </summary>
    public interface ILogicCtrlBehaviour:ISerializable
    {
        void OnCreate();
        void OnDestroy();
    }
}