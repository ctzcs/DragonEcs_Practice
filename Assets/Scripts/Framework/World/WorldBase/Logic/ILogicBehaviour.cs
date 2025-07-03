namespace Framework
{
    /// <summary>
    /// 逻辑层obj
    /// </summary>
    public interface ILogicBehaviour:ILogicUpdate
    {
        void OnCreate();
        void OnDestroy();
    }
}