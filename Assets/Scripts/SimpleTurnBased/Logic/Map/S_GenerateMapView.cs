using System.IO;
using Base;
using DCFApixels.DragonECS;
using SimpleTurnBased.View;
using SimpleTurnBased.View.Map;
using UnityEngine;

namespace SimpleTurnBased.Logic.Map
{
    public class S_GenerateMapView:IEcsFixedRunProcess
    {
        [DI] private EcsDefaultWorld _world;
        class Aspect
        {
            public EcsTagPool<Ct_FinishGenMap> finishGenMapTag = API.Inc;
            public EcsPool<C_Map> map = API.Inc;
        }
        public void FixedRun()
        {
            foreach (var ent in _world.Where(out Aspect aspect))
            {
                ref readonly var mapCom = ref ent.Read(aspect.map);
                CreateMapView(in mapCom, out C_MapView mapView);
                ent.Add(_world,ref mapView);
                ent.DelTag(aspect.finishGenMapTag);
            }
        }
        
        
        void CreateMapView(in C_Map map,out C_MapView view)
        {
            
            var prefab = Resources.Load<GameObject>(Path.Combine(CstStr.Prefab, CstStr.MapPath, "MapGrid"));
            var sprite = ViewHelper.GetSpriteAtlas().GetSprite("mapTile_4");
            var mapRoot = new GameObject();
            
            view = new C_MapView
            {
                startPoint = new Vector2(-5,3),
                cellSize = 1,
                mapRoot = mapRoot,
                bottom = new GameObject[map.width,map.height]
            };
            for (int j = 0; j < map.height; j++)
            {
                for (int i = 0; i < map.width; i++)
                {
                    var grid = Object.Instantiate(prefab,mapRoot.transform);
                    grid.GetComponent<MapGridView>().gridView.sprite = sprite;
                    grid.transform.localPosition = view.startPoint + new Vector2(i * view.cellSize, j * view.cellSize);
                    view.bottom[i, j] = grid;
                }
            }
        }
    }
}