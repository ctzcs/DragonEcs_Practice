using System;
using System.IO;
using System.Text;
using DCFApixels.DragonECS;
using GameOne.Ecs;
using GameOne.Object;
using GameOne.Service;
using Newtonsoft.Json;


namespace GameOne
{
    public class SaveSystem:IEcsFixedRunProcess
    {
        [EcsInject] private EcsDefaultWorld _world;
        [EcsInject] private TimeService _timeService;
        [EcsInject] private GameService gameService;
        class Aspect:EcsAspect
        {
            public EcsTagPool<PlayerTag> playerTags = Inc;
            public EcsPool<Health> playerHealths = Inc;
        }
        public void FixedRun()
        {
            if (gameService.State == EGameState.Saving)
            {
                Serialize();
                EcsDebug.Print($"Game==>Saving {_timeService.fixedDeltaTime}");
            }
            
        
        }


        private void Serialize()
        {
            //保存场景中的每个Entity
            Save save = new Save();
            foreach (var id in _world.Where(out Aspect aspect))
            {
                Player player = new Player();
                save.player = player.GetDataFromEcs(_world.GetEntityLong(id));
            }
            try
            {
                string txt = JsonConvert.SerializeObject(save, Formatting.Indented);
                string path = Path.Combine(UnityEngine.Application.dataPath + "/../Save");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllText( $"{path}/TestData.sav",txt,Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine(e + $"Write Wrong!");
                throw;
            }
            finally
            {
                gameService.State = EGameState.Play;
            }
        
        }

        public static bool DeSerialize(string path)
        {
            
            //加载每个实体
            return false;
        }
    }
}