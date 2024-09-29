using DCFApixels.DragonECS;
using UnityEngine;

namespace Survivor
{
    public class Main:MonoBehaviour
    {
        private EcsDefaultWorld _world;
        private EcsPipeline _pipeline;

        private Service.ConfigService _configService;
    }
}