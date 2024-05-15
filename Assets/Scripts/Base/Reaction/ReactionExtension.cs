using System;
using Base;
using DCFApixels.DragonECS;

namespace GameOne.Ecs
{
    public static class ReactionExtension
    {
        #region EntityDiff

        /// <summary>
        /// 找不同的结果
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static ComponentDiffResult<T1> Diff<T1, T2>(this entlong entity)
            where T1:struct,IEcsComponent,IEquatable<T1>
            where T2:struct,IDiffComponent<T1>
        {
            var currentPool = entity.World.GetPool<T1>();
            var oldPool = entity.World.GetPool<T2>();
            var hasCurrent = entity.Has(currentPool);
            var hasOld = entity.Has(oldPool);
            if (!hasCurrent && !hasOld)
            {
                return new ComponentDiffResult<T1>() { type = ComponentDiffResult<T1>.EChangeType.NotPresent };
            }

            if (hasCurrent && hasOld == false)
            {
                ref readonly var component = ref entity.Read(currentPool);
                return new ComponentDiffResult<T1>()
                {
                    type = ComponentDiffResult<T1>.EChangeType.Added,
                    old = component,
                    current = component,
                };
            }

            if (!hasCurrent)
            {
                var component = entity.Read(oldPool).Value;
                return new ComponentDiffResult<T1>()
                {
                    type = ComponentDiffResult<T1>.EChangeType.Removed,
                    old = component,
                    current = component,
                };

            }

            var before = entity.Read(oldPool).Value;
            var after = entity.Read(currentPool);
            if (before.Equals(after))
            {
                return new ComponentDiffResult<T1>() {
                    type = ComponentDiffResult<T1>.EChangeType.NothingChanged,
                    old = before,
                    current = after
                };
            }
            return new ComponentDiffResult<T1>(){
                        type = ComponentDiffResult<T1>.EChangeType.Updated,
                        old = before,
                        current = after };
            }
        
        /// <summary>
        /// 将历史记录和
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <returns></returns>
        public static ComponentDiffResult<T1> Balance<T1, T2>(this entlong entity)
            where T1 : struct, IEcsComponent, IEquatable<T1>
            where T2 : struct, IDiffComponent<T1>
        {
                        
            var diffResult = entity.Diff<T1, T2>();
            var oldPool = entity.World.GetPool<T2>();
            
            switch (diffResult.type)
            {
                case ComponentDiffResult<T1>.EChangeType.Added:
                case ComponentDiffResult<T1>.EChangeType.Updated:
                    T2 component = new T2() { Value = diffResult.current };
                    ref T2 newComponent = ref entity.TryGetOrAdd(oldPool);
                    newComponent = component;
                    break;
                case ComponentDiffResult<T1>.EChangeType.Removed:
                    entity.Del(oldPool);
                    break;
                case ComponentDiffResult<T1>.EChangeType.NothingChanged:
                case ComponentDiffResult<T1>.EChangeType.NotPresent:
                    break;

            }
            return diffResult;
        }
        
        #endregion
    }
}