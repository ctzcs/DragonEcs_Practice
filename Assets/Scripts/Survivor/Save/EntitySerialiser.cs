using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Base;
using DCFApixels.DragonECS;
using Newtonsoft.Json;
using UnityEngine;

namespace GameOne
{

    public class Entity
    {
        public int id;
        public List<Component> components = new();
        
        public struct Component
        {
            public Type type;
            public object value;
        }
    }
    public class EntitySerialiser
    {
        public string Path = Application.dataPath + "/../Save";
        
        /// <summary>
        /// 将World中的Entity转换成Object
        /// </summary>
        /// <param name="entl"></param>
        /// <returns></returns>
        public static Entity World2Object(entlong entl)
        {
            Entity entity = new Entity();
            
            int id = entl.ID;
            entity.id = id;
            var world = entl.World;
            ReadOnlySpan<int> components = world.GetComponentTypeIDsFor(id);
            foreach (var component in components)
            {
                var pool = world.GetPoolInstance(component);
                object data = pool.GetRaw(id);
                
                entity.components.Add(new Entity.Component()
                {
                    type = data.GetType(),
                    value = data,
                });
            }

            return entity;
        }

        public static void Object2World(Entity entity,EcsWorld world)
        {
            var e= world.NewEntity(entity.id);
            foreach (var c in entity.components)
            {
               var pool = world.GetPoolInstance(c.type);
               pool.AddRaw(e,c.value);
            }
        }
        
    }
}