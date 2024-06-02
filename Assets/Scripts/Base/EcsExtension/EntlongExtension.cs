using System;
using DCFApixels.DragonECS;
using GameOne.Ecs;
using UnityEngine;

namespace Base
{
    public static class EntlongExtension
    {
        #region Component

        #region Entlong拓展且不需要池子
        public static ref TComponent Get<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.Get(entity.ID);
        }
        
        public static void Add<TComponent>(this entlong entity,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            ref var poolComponent = ref pool.Add(entity.ID);
            poolComponent = component;
        }

        public static ref TComponent TryGetOrAdd<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.TryAddOrGet(entity.ID);
        }
        
        public static void Del<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            pool.Del(entity.ID);
        }
        
        public static bool Has<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return pool.Has(entity.ID);
        }
        
        public static ref readonly TComponent Read<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.Read(entity.ID);
        }
        

        #endregion
        
        #region 给Entlong做拓展
        public static ref TComponent Get<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Get(entity.ID);
        }
        
        public static ref TComponent TryGetOrAdd<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.TryAddOrGet(entity.ID);
        }
        
        public static void Add<TComponent>(this entlong entity,EcsPool<TComponent> pool,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            ref var poolComponent = ref pool.Add(entity.ID);
            poolComponent = component;
        }
        
        public static void Del<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            pool.Del(entity.ID);
        }
        
        public static bool Has<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return pool.Has(entity.ID);
        }
        public static ref readonly TComponent Read<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Read(entity.ID);
        }
        

        #endregion
        
        #region 直接给Int做拓展

        public static ref TComponent Get<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Get(entity);
        }
        
        public static ref TComponent TryGetOrAdd<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.TryAddOrGet(entity);
        }
        
        public static void Add<TComponent>(this int entity,EcsPool<TComponent> pool,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            ref var poolComponent = ref pool.Add(entity);
            poolComponent = component;
        }
        
        public static void Del<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            pool.Del(entity);
        }
        
        public static bool Has<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return pool.Has(entity);
        }
        public static ref readonly TComponent Read<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Read(entity);
        }

        #endregion
        
        #endregion

        #region TagComponent
        
        public static void AddTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            pool.Add(entity.ID);
        }
        
        public static void DelTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            pool.Del(entity.ID);
        }
        
        public static bool HasTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            return pool.Has(entity.ID);
        }
        
        
        public static void AddTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Add(entity.ID);
        }
        
        public static void DelTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Del(entity.ID);
        }

        
        public static bool HasTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            return pool.Has(entity.ID);
        }
        
        
        public static void AddTag<TTagComponent>(this int entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Add(entity);
        }
        
        public static void DelTag<TTagComponent>(this int entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Del(entity);
        }


        public static bool HasTag<TTagComponent>(this int entity, EcsTagPool<TTagComponent> pool)
            where TTagComponent : struct, IEcsTagComponent
        {
            return pool.Has(entity);
        }






        #endregion
        
        
    }
        
       
}

