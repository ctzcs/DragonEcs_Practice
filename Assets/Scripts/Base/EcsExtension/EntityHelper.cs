using System.Runtime.CompilerServices;
using DCFApixels.DragonECS;

namespace Base
{
    public static class EntityHelper
    {

        #region Component
        
        #region Entlong Without Pool
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent Get<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.Get(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TComponent>(this entlong entity,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            ref var poolComponent = ref pool.Add(entity.ID);
            poolComponent = component;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent TryGetOrAdd<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.TryAddOrGet(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Del<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            pool.Del(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return pool.Has(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TComponent Read<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            EcsPool<TComponent> pool = EcsWorld.GetPoolInstance<EcsPool<TComponent>>(entity.WorldID);
            return ref pool.Read(entity.ID);
        }

        #endregion
        
        #region Entlong With Pool
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent Get<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Get(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent TryGetOrAdd<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.TryAddOrGet(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TComponent>(this entlong entity,EcsPool<TComponent> pool,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            ref var poolComponent = ref pool.Add(entity.ID);
            poolComponent = component;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Del<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            pool.Del(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return pool.Has(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TComponent Read<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Read(entity.ID);
        }

        

        #endregion
        
        #region Int With Pool

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent Get<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Get(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent TryGetOrAdd<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.TryAddOrGet(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TComponent>(this int entity,EcsPool<TComponent> pool,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            ref var poolComponent = ref pool.Add(entity);
            poolComponent = component;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Del<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            pool.Del(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return pool.Has(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TComponent Read<TComponent>(this int entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Read(entity);
        }

        #endregion

        #region Int Without Pool

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent Get<TComponent>(this int entity,EcsWorld world) where TComponent : struct, IEcsComponent
        {
            return ref world.GetPool<TComponent>().Get(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Add<TComponent>(this int entity,EcsWorld world,ref TComponent component) where TComponent : struct, IEcsComponent
        {
            ref var poolComponent = ref world.GetPool<TComponent>().Add(entity);
            poolComponent = component;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TComponent TryGetOrAdd<TComponent>(this int entity,EcsWorld world) where TComponent : struct, IEcsComponent
        {
            return ref world.GetPool<TComponent>().TryAddOrGet(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Del<TComponent>(this int entity,EcsWorld world) where TComponent : struct, IEcsComponent
        {
            world.GetPool<TComponent>().Del(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Has<TComponent>(this int entity,EcsWorld world) where TComponent : struct, IEcsComponent
        {
            return world.GetPool<TComponent>().Has(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TComponent Read<TComponent>(this int entity,EcsWorld world) where TComponent : struct, IEcsComponent
        {
            return ref world.GetPool<TComponent>().Read(entity);
        }

        

        #endregion
        #endregion
        #region Tag

        #region without world
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            pool.Add(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            pool.Del(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTag<TTagComponent>(this entlong entity) 
            where TTagComponent : struct, IEcsTagComponent
        {
            EcsTagPool<TTagComponent> pool = EcsWorld.GetPoolInstance<EcsTagPool<TTagComponent>>(entity.WorldID);
            return pool.Has(entity.ID);
        }
        

        #endregion

        #region with world
        //无池版本
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddTag<TTagComponent>(this int entity,EcsWorld world) where TTagComponent : struct, IEcsTagComponent
        {
            world.GetPool<TTagComponent>().Add(entity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelTag<TTagComponent>(this int entity,EcsWorld world) where TTagComponent : struct, IEcsTagComponent
        {
            world.GetPool<TTagComponent>().Del(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTag<TTagComponent>(this int entity,EcsWorld world) where TTagComponent : struct, IEcsTagComponent
        {
            return world.GetPool<TTagComponent>().Has(entity);
        }
        

        #endregion

        #region with pool
        //池子版本
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Add(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Del(entity.ID);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            return pool.Has(entity.ID);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddTag<TTagComponent>(this int entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Add(entity);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DelTag<TTagComponent>(this int entity,EcsTagPool<TTagComponent> pool) 
            where TTagComponent : struct, IEcsTagComponent
        {
            pool.Del(entity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool HasTag<TTagComponent>(this int entity, EcsTagPool<TTagComponent> pool)
            where TTagComponent : struct, IEcsTagComponent
        {
            return pool.Has(entity);
        }
        

        #endregion
        
        #endregion
        #region Event

        public static ref T CreateAndAdd<T>(this EcsWorld world) where T : struct, IEcsComponent
        {
            var entl = world.NewEntityLong();
            return ref world.GetPool<T>().Add(entl.ID);
        }

        public static entlong CreateAndAdd<T>(this EcsWorld world, ref T component) where T : struct, IEcsComponent
        {
            var entl = world.NewEntityLong();
            ref var poolComponent = ref world.GetPool<T>().Add(entl.ID);
            poolComponent = component;
            return entl;
        }

        #endregion
    }
        
       
}

