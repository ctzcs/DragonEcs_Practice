using System.Collections.Generic;
using Base;
using DCFApixels.DragonECS;
using GameOne.Ecs;

namespace GameOne.DesignScript.Buff
{
    #region 委托
    public delegate void BuffOnAdd(EcsDefaultWorld world,int addTo);
    public delegate void BuffOnRemove(EcsDefaultWorld world,int removeFrom);
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
        static void BuffOnAdd_PrintAddBuff(EcsDefaultWorld world,int addTo)
        {
            var namePool = world.GetPool<Name>();
            if (addTo.Has(namePool))
            {
                ref readonly var name = ref addTo.Read(namePool);
                EcsDebug.Print($"AddBuff >> {name.name} !");
            }
            
            
        }
        

        #endregion

        #region OnRemove
        static void BuffOnRemove_PrintRemoveBuff(EcsDefaultWorld world,int removeFrom)
        {
            var namePool = world.GetPool<Name>();
            if (removeFrom.Has(namePool))
            {
                ref readonly var name = ref removeFrom.Read(namePool);
                EcsDebug.Print($"RemoveBuff << {name.name}!");
            }
            
        }
        

        #endregion
        
        #endregion

    }

    
    

}