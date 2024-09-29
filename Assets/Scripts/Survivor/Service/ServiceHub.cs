namespace Survivor.Service
{
    public class ServiceHub
    {
        public ConfigService Config { get; private set; }

        public ServiceHub()
        {
            Config = new ConfigService();
        }
    }
}