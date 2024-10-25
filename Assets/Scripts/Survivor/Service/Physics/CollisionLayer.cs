using System;

namespace Service
{
    [Flags]
    public enum CollisionLayer
    {
        Default = 1 << 0,
        Player =  1 << 1,
        Enemy = 1 << 2,
        Projectile = 1 << 3,
    }
}