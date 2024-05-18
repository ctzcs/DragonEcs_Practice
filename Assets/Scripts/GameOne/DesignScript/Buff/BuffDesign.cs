using System.Collections.Generic;
using DCFApixels.DragonECS;

namespace GameOne.DesignScript.Buff
{
    #region 委托
    public delegate void BuffOnAdd();
    public delegate void BuffOnRemove();
    #endregion
    public class BuffDesign
    {

        #region 属性

        public static Dictionary<string, BuffOnAdd> OnAddFunc { get; } = new()
        {
            {"PrintAddBuff",BuffOnAdd_PrintAddBuff},
        };
        
        public static Dictionary<string, BuffOnRemove> OnRemoveFunc { get; } = new()
        {
            { "PrintRemoveBuff", BuffOnRemove_PrintRemoveBuff },
        };

        #endregion
        
        #region Private

        #region OnAdd
        static void BuffOnAdd_PrintAddBuff()
        {
            EcsDebug.Print("AddBuff,Happy!");
        }
        

        #endregion

        #region OnRemove
        static void BuffOnRemove_PrintRemoveBuff()
        {
            EcsDebug.Print("RemoveBuff,Sad!");
        }
        

        #endregion
        
        #endregion

    }

    
    

}