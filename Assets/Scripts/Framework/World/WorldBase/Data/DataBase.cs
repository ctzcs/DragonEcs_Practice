using System;

namespace Framework
{
    public abstract class DataBase:ICloneable
    {
        /// <summary>
        /// 永久更新的时候，需要设置数据
        /// </summary>
        /// <param name="data"></param>
        public abstract void SetData(object data);
        /// <summary>
        /// 逻辑层获取克隆的数据
        /// </summary>
        /// <returns></returns>
        public abstract object Clone();
    }
}