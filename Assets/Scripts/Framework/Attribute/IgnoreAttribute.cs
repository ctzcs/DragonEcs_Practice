namespace Framework
{
    /// <summary>
    /// 忽略标签，反射收集的时候不会收集到这些内容
    /// </summary>
    public class IgnoreAttribute : System.Attribute
    {
        public EIgnoreType IgnoreType = EIgnoreType.Default;
        
        public enum EIgnoreType
        {
            Default,
            //样例
            Sample,
            //开发中
            InProgress,
            //废弃
            Deprecate
        }
        
        public IgnoreAttribute()
        {
            
        }
    }
}