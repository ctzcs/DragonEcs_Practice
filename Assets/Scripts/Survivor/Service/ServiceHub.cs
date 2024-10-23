using Survivor.Physics;

namespace Survivor.Service
{
    public class ServiceHub
    {
        public ConfigService Config { get; private set; }
        public PhysicsWorld PhysicsWorld { get; private set; }
        public ServiceHub()
        {
            Config = new ConfigService();
            PhysicsWorld = new PhysicsWorld();
        }
    }
}