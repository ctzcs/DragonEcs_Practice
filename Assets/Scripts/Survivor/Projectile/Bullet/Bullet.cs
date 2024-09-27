using DCFApixels.DragonECS;

namespace Survivor.Projectile
{
    public struct Bullet : IEcsComponent
    {
        public float triggerInterval;
        public float lifetime;
        public int speed;

        
    }
}