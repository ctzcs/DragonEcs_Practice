using DCFApixels.DragonECS;
using UnityEngine;

namespace Base
{
    public class Template
    {
        #region 字段

        #endregion

        #region 属性


        #endregion

        #region Public

        #region 接口

        #endregion


        #endregion

        #region Private


        #endregion

        public static T Copy<T>(T template) where T:Object,ITemplate
        {
            return Object.Instantiate(template);
        }
    }
}