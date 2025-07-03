using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Framework
{
    public class WorldMgr
    {
        private static readonly List<World> s_WorldList = new();
        /// <summary>
        /// 这个世界存放了当前的游戏场景
        /// </summary>
        public static World DefaultGameWorld { get; private set; }
        /// <summary>
        /// 通过反射创建世界
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateWorld<T>() where T:World,new()
        {
            var world = GetWorld<T>();
            //如果已经有了就先销毁
            if (world is not null)
            {
                DestroyWorld<T>();
            }
            world = new T();
            DefaultGameWorld = world;
            //初始化当前游戏世界的程序集
            s_WorldList.Add(world);
            //初始化世界的类型
            TypeMgr.InitializedWorldAssemblies(world);
            world.OnCreate();
            return world;
        }

        /// <summary>
        /// 遍历获取World
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetWorld<T>() where T : World
        {
            for (int i = 0; i < s_WorldList.Count; i++)
            {
                if (s_WorldList[i].GetType() == typeof(T) )
                {
                    return s_WorldList[i] as T;
                }
            }
            return default(T);
        }
        
        /// <summary>
        /// 销毁指定世界
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void DestroyWorld<T>() where T : World
        {
            Type type = typeof(T);
            for (int i = s_WorldList.Count-1; i >= 0; i--)
            {
                if (s_WorldList[i].GetType() == type)
                {
                    s_WorldList[i].DestroyWorld(typeof(T).Namespace);
                    s_WorldList.RemoveAt(i);
                    break;
                }
            }
        }

        
        
        /*public static void OnUpdate(float deltaTime,float realElapsedTime)
        {
            if (DefaultGameWorld is not null)
            {
                DefaultGameWorld.OnUpdate(deltaTime,realElapsedTime);
            }
        }*/

        public static void SaveWorld<T>(World world) where T:World,new()
        {
            WorldSerialization.Save($"{Application.dataPath}/../Save",$"{typeof(T).Name}.sav",world as T);
        }
        
        public static T LoadWorld<T>() where T:World,new()
        {
            //首先要确定没有加载过World
            var world = GetWorld<T>();
            //如果加载过，就将其销毁
            if (world is not null)
            {
                DestroyWorld<T>();
            }
            //从磁盘加载
            world = WorldSerialization.Load<T>($"{Application.dataPath}/../Save",$"{typeof(T).Name}.sav");
            if (world is not null)
            {
                DefaultGameWorld = world;
                //初始化当前游戏世界的程序集
                s_WorldList.Add(world);
                //初始化世界的类型
                TypeMgr.InitializedWorldAssemblies(world);
                //调用OnLoad
                world.OnLoad(world);
            }
            else
            {
                world = CreateWorld<T>();
            }

            MyLog.Log($"s_WorldList.Count==>{s_WorldList.Count}");
            return world;
        }


        /// <summary>
        /// 加载世界
        /// </summary>
        /// <param name="world"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T LoadWorld<T>(T world) where T:World,new()
        {
            //首先要确定没有加载过World
            var loadWorld = GetWorld<T>();
            //如果加载过，就将其销毁
            if (loadWorld is not null)
            {
                DestroyWorld<T>();
            }
            //从磁盘加载
            if (world is not null)
            {
                DefaultGameWorld = world;
                //初始化当前游戏世界的程序集
                s_WorldList.Add(world);
                //初始化世界的类型
                TypeMgr.InitializedWorldAssemblies(world);
                world.OnLoad(world);
            }
            else
            {
                world = CreateWorld<T>();
            }

            return world;
        }

        public static void ClearWorld<T>()
        {
            string path = $"{Application.streamingAssetsPath}/{typeof(T).Name}.sav";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        
    }
}