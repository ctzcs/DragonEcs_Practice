using System;
using Sirenix.OdinInspector;

namespace Framework
{
    public interface IBindableProperty<T>
    {
        T Value { get; set; }
        public event Action<T> OnValueChange;
    }
    
    /// <summary>
    /// 该数据自带一个更改后的回调
    /// 可以将其与view面板绑定
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindableProperty<T>:IBindableProperty<T> where T:IEquatable<T>
    {
        [ShowInInspector]
        private T _value;
        public event Action<T> OnValueChange;
        public T Value
        {
            get=>_value;
            set
            {
                if (_value.Equals(value)) return;
                _value = value;
                OnValueChange?.Invoke(_value);

            }
        }
        
        public BindableProperty(T defaultValue = default) => _value = defaultValue;

        public void Reset()
        {
            _value = default;
            OnValueChange = null;
        }
    }
}