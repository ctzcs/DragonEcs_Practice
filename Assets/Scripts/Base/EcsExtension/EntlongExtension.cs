
using DCFApixels.DragonECS;

namespace Base
{
    public static class EntlongExtension
    {
        #region Component
        public static ref TComponent Get<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            return ref world.GetPool<TComponent>().Get(id);
        }
        
        public static ref TComponent Add<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            return ref world.GetPool<TComponent>().Add(id);
        }
        
        public static void Del<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            world.GetPool<TComponent>().Del(id);
        }
        
        public static bool Has<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            return world.GetPool<TComponent>().Has(id);
        }
        
        public static ref readonly TComponent Read<TComponent>(this entlong entity) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            return ref world.GetPool<TComponent>().Read(id);
        }
        
        
        
        public static ref TComponent Get<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Get(entity.ID);
        }
        
        public static ref TComponent Add<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            return ref pool.Add(entity.ID);
        }
        
        public static void Del<TComponent>(this entlong entity,EcsPool<TComponent> pool) where TComponent : struct, IEcsComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            pool.Del(id);
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

        #region TagComponent
        
        public static void AddTag<TTagComponent>(this entlong entity) where TTagComponent : struct, IEcsTagComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            world.GetTagPool<TTagComponent>().Add(id);
        }
        
        public static void DelTag<TTagComponent>(this entlong entity) where TTagComponent : struct, IEcsTagComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            world.GetTagPool<TTagComponent>().Del(id);
        }
        
        public static bool HasTag<TTagComponent>(this entlong entity) where TTagComponent : struct, IEcsTagComponent
        {
            entity.Unpack(out int id,out EcsWorld world);
            return world.GetTagPool<TTagComponent>().Has(id);
        }
        
        
        public static void AddTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) where TTagComponent : struct, IEcsTagComponent
        {
            pool.Add(entity.ID);
        }
        
        public static void DelTag<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) where TTagComponent : struct, IEcsTagComponent
        {
            pool.Del(entity.ID);
        }

        
        public static bool Has<TTagComponent>(this entlong entity,EcsTagPool<TTagComponent> pool) where TTagComponent : struct, IEcsTagComponent
        {
            return pool.Has(entity.ID);
        }
        

        #endregion
        
        
    }
}