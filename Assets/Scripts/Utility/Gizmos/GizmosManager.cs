using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.Gizmos
{
    public class GizmosManager:MonoBehaviour
    {
        private readonly List<IGizmosCommand> _commands = new();
        private readonly Dictionary<Type,Queue<IGizmosCommand>> _commandPool = new();
        public bool IsOpen { get; set; }
        
        private void OnDrawGizmos()
        {
            if (!IsOpen)return;
            foreach (var gizmos in _commands)
            {
                gizmos.Draw();
                ReturnToPool(gizmos);
            }
            _commands.Clear();
        }

        public void Init()
        {
            IsOpen = true;
        }
        
        public void AddCommand<T>(T cmd) where T : IGizmosCommand
        {
            _commands.Add(cmd);
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
    }

    public interface IGizmosCommand
    {
        void Draw();
    }
}