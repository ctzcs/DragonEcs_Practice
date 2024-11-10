using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Utility.Gizmos
{
    public class GizmosManager:MonoBehaviour
    {
        private static int count;
        [ShowInInspector]
        private readonly List<IGizmosCommand> _tempAddCommands = new();
        [ShowInInspector]
        private readonly List<IGizmosCommand> _commands = new();
        [ShowInInspector]
        private readonly Dictionary<Type,Queue<IGizmosCommand>> _commandPool = new();

        [ShowInInspector]
        private bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set => _isOpen = value;
        }

        private void OnDrawGizmos()
        {
            if (!IsOpen)return;
            if (_tempAddCommands.Count > 0)
            {
                foreach (var cmd in _commands)
                {
                    ReturnToPool(cmd);
                }
                _commands.Clear();
                _commands.AddRange(_tempAddCommands);
                _tempAddCommands.Clear();
            }
            
            foreach (var gizmos in _commands)
            {
                gizmos.Draw();
                //ReturnToPool(gizmos);
            }
            
        }

        public void Init()
        {
            IsOpen = true;
        }
        
        public void AddCommand<T>(T cmd) where T : IGizmosCommand
        {
            if (!IsOpen||cmd == null)
            {
                return;
            }
            _tempAddCommands.Add(cmd);
        }
        
        public T Get<T>() where T:class,IGizmosCommand,new()
        {
            if (_commandPool.TryGetValue(typeof(T),out var pool)
                && pool is { Count: > 0 })
            {
                return pool.Dequeue() as T;
            }
            return new T();
        }

        private void ReturnToPool(IGizmosCommand cmd)
        {
            Type type = cmd.GetType();
            if (!_commandPool.TryGetValue(type,out var pool))
            {
                pool = new Queue<IGizmosCommand>();
                _commandPool.Add(type,pool);
                
            }
            pool.Enqueue(cmd);
        }


        private static bool IsGizmosEnable()
        {
            var sceneView = SceneView.lastActiveSceneView;//.drawGizmos;
            return sceneView != null && sceneView.drawGizmos;
        }
    }

    public interface IGizmosCommand
    {
        void Draw();
    }
}