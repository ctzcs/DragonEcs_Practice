using System;
using System.IO;
using System.Net;
using System.Text;
using Component;
using DCFApixels.DragonECS;
using Newtonsoft.Json;
using Object;
using Application = UnityEngine.Device.Application;

public class SaveSystem:IEcsRun
{
    [EcsInject] private EcsDefaultWorld _world;
    [EcsInject] private TimeService _timeService;
    [EcsInject] private GameStateService _gameStateService;
    class Aspect:EcsAspect
    {
        public EcsTagPool<PlayerTag> playerTags = Inc;
        public EcsPool<Health> playerHealths = Inc;
    }
    public void Run()
    {
        if (_gameStateService.state == EGameState.Saving)
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
            string path = Path.Combine(Application.dataPath + "/../Save");
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
            _gameStateService.state = EGameState.Play;
        }
        
    }

    public static bool DeSerialize(string path)
    {
        //加载每个实体
        return false;
    }
}