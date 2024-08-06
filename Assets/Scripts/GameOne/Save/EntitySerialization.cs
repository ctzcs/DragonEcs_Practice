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
    public class EntitySerialization
    {
        public string ToJson(entlong entl)
        {
            int id = entl.ID;
            var world = entl.World;
            ReadOnlySpan<int> components = world.GetComponentTypeIDsFor(id);
            StringBuilder sb = new StringBuilder();
            sb.Append($"entity:{entl},");
            foreach (var component in components)
            {
                var pool = world.GetPoolInstance(component);
                object data = pool.GetRaw(id);
                FieldInfo[] fieldInfos = pool.GetType().GetFields();
                string json = JsonConvert.SerializeObject(data);
                sb.Append(json);
            }
            return sb.ToString();
        }

        public void ToEntity(string json,EcsWorld world)
        {
            var jsonArray = json.Split(",");
            int id = int.Parse(jsonArray[0].Split(":")[1]);
            var e=  world.NewEntity(id);
            for (int i = 1; i < jsonArray.Length; i++)
            {
                object component = JsonConvert.DeserializeObject(jsonArray[i]);
                
            }
        }
    }
}