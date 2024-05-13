// README https://gist.github.com/DCFApixels/c0dd6ba4ee6d4fa641a158108d1b82c8#file-service-md
// inspired by https://github.com/Leopotam/globals/blob/master/src/Service.cs

// author: DCFApixels
// license: MIT

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Base.Service;

namespace Base
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class AssociateServiceFactoryWithAttribute : Attribute
    {
        public readonly Type targetType;
        public readonly string staticFactoryMethodName;
        public AssociateServiceFactoryWithAttribute(Type targetType, string staticFactoryMethodName = "")
        {
            this.targetType = targetType;
            this.staticFactoryMethodName = staticFactoryMethodName;
        }
    }
    public interface IService
    {
        void OnEnabled();
        void OnDisabled();
    }
    internal static class Service
    {
        private static Dictionary<Type, MethodBase> _associatedFactoryMethods;

        internal static bool TryGetAssotiatedFactoryMethod(Type type, out MethodBase method)
        {
            if (_isInit == false) Init();
            bool result = _associatedFactoryMethods.TryGetValue(type, out method);
            if(result == false) { method = FindConstructor(type); }
            return method != null;
        }

        // Implementing via lazy initialization removes dependency on the static constructor implementation and ensures that associations are generated when needed.
        private static bool _isInit;
        private static void Init()
        {
            _associatedFactoryMethods = new Dictionary<Type, MethodBase>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var atrs = type.GetCustomAttributes<AssociateServiceFactoryWithAttribute>();
                    foreach (var atr in atrs)
                    {
                        if (atr.targetType.IsGenericType)
                            throw new Exception("Generic types are not supported yet.");
                        if (_associatedFactoryMethods.TryGetValue(atr.targetType, out var otherMethod))
                            throw new Exception($"Cannot be assigned multi-association with {atr.targetType.Name}, remove the {nameof(AssociateServiceFactoryWithAttribute)} from {type.Name} or {otherMethod.DeclaringType.Name}.");
                        var factory = FindFactoryMethod(type, atr.staticFactoryMethodName);
                        if (factory == null)
                        {
                            if (string.IsNullOrEmpty(atr.staticFactoryMethodName))
                                throw new Exception($"Type {type.Name} does not have a no-argument constructor.");
                            else
                                throw new Exception($"Failed to find a static {atr.staticFactoryMethodName} method in {type.Name}.");
                        }
                        _associatedFactoryMethods.Add(atr.targetType, factory);
                    }
                }
            }
            _isInit = true;
        }

        internal static MethodBase FindConstructor(Type type)
        {
            return type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
        }
        internal static MethodBase FindFactoryMethod(Type type, string staticFactoryMethodName)
        {
            if (string.IsNullOrEmpty(staticFactoryMethodName) == false)
                return type.GetMethod(staticFactoryMethodName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            return FindConstructor(type);
        }
    }
    public class Service<T> where T : class
    {
        private static MethodBase _factoryMethod;
        private static T _instance;
        private readonly static Type _type;
        public static event Action<T> Changed = delegate { };
        static Service()
        {
            _type = typeof(T);
        }

        /// <summary>Returns True if instance of T type is already set</summary>
        public static bool IsNull => _instance == null;
        /// <summary>Returns True if instance of T type is not set</summary>
        public static bool IsNotNull => _instance != null;


        public static void Register(Func<T> factory)
        {
            _factoryMethod = factory.Method;
        }

        /// <summary>Gets global instance of T type</summary>
        /// <param name="createIfNotExists">If true and instance not exists - new instance will be created.</param>
        /// <returns>Instance of T type</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Get(bool createIfNotExists = false)
        {
#if DEBUG
            if (createIfNotExists && _factoryMethod == null && !TryGetAssotiatedFactoryMethod(_type, out _factoryMethod))
                ThrowNoFactoryMethod();
#endif
            if (_instance != null)
                return _instance;
            if (createIfNotExists)
                Set(CreateInstance());
            return _instance;
        }

        private static bool _isRecursiveCallSet = false;
        /// <summary>Sets global instance of T type</summary>
        /// <param name="instance">New instance of T type.</param>
        /// <returns>Instance of T type</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Set(T instance)
        {
            if (_instance == instance)
                return instance;

            if (_isRecursiveCallSet)
                ThrowRecursiveCallSet();

            _isRecursiveCallSet = true;
            var oldInstance = _instance;
            _instance = instance;

            if (oldInstance != null && oldInstance is IService service1)
                service1.OnDisabled();
            if (instance != null && instance is IService service2)
                service2.OnEnabled();
            Changed(instance);

            _isRecursiveCallSet = false;
            return _instance;
        }

        /// <summary>Returns True if otherInstance is the current instance</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Equals(T otherInstance) => _instance == otherInstance;

        /// <summary>Sets global instance of T type to Null</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Reset()
        {
            Set(null);
        }
        /// <summary>Creates a new global instance T</summary>
        /// <returns>New instance of T type</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Renew()
        {
            Set(null);
            return Get(true);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static T CreateInstance()
        {
            if (_factoryMethod == null)
                TryGetAssotiatedFactoryMethod(_type, out _factoryMethod);
            if (_factoryMethod is ConstructorInfo constructorInfo)
                return (T)constructorInfo.Invoke(null);
            return (T)_factoryMethod.Invoke(null, BindingFlags.Default, null, null, null);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowNoFactoryMethod()
        {
            throw new ArgumentException($"There is no factory method set for {typeof(T).Name}. Use Register method set it manually, or create a no-argument constructor or use {nameof(AssociateServiceFactoryWithAttribute)}.");
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowRecursiveCallSet()
        {
            throw new ArgumentException($"Recursive call to the {nameof(Set)} method.");
        }
    }
}