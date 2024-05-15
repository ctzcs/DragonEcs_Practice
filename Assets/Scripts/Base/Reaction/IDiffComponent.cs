using System;
using DCFApixels.DragonECS;

namespace Base
{
    public interface IDiffComponent<T> : IEcsComponent where T:struct,IEcsComponent,IEquatable<T>
    {
        T Value { get; set; }
    }
}