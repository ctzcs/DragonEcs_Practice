using System.IO;
using System.Text.RegularExpressions;
using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace SimpleTurnBased.Logic.Map
{
    public class S_MapGenerator:IEcsFixedRunProcess
    {
        [DI] private EcsDefaultWorld _world;
        [DI] private EcsEventWorld _eWorld;
        private string _path;
        class Aspect:EcsAspect
        {
            public EcsPool<Ce_GenMap> genMapEvt = Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _eWorld.Where(out Aspect aspect))
            {
                ref readonly var e = ref ent.Read(aspect.genMapEvt);
                //加载地图
                if (string.IsNullOrEmpty(_path))
                {
                    _path = Path.Combine( CstStr.Config,CstStr.MapPath);
                }
                //TODO 读取资源工具
                var txt = Resources.Load<TextAsset>(Path.Combine(_path,e.mapId));
                var map = _world.NewEntityLong();
                C_Map mapCom = new C_Map();
                ParseMapTxt(txt.text,ref mapCom);
                map.Add(ref mapCom);
                map.AddTag<Ct_FinishGenMap>();
                _eWorld.DelEntity(ent);
            }
        }
        
        void ParseMapTxt(string txt,ref C_Map map)
        {
            string output = Regex.Replace(txt, @"[\r\n]+", ""); 
            var lines= output.Split("|");
            if (lines is null || lines.Length<=0)
            {
                return;
            }
            
            int height = lines.Length;
            int width = lines[0].Length;
            map.height = height;
            map.width = width;
            map.bottom = new Grid[width,height];
            FillMapGrid(lines,width,height,ELayer.Down,map.bottom);
            /*map.mid = new Grid[width,height];
            FillMapGrid(width,height,ELayer.Down,map.mid);
            map.top = new Grid[width,height];
            FillMapGrid(width,height,ELayer.Down,map.top);*/
            
            EcsDebug.Print(map.ToString());
        }
        void FillMapGrid(string[] lines,int width,int height,ELayer layer,Grid[,] grids)
        {
            //左上角开始填
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var grid = new Grid();
                    grid.icon = lines[j][i].ToString();
                    grids[i,j] = grid;
                    grid.layer = layer;

                }
                
            }
        }
    }
}