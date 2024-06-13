using Base;
using DCFApixels.DragonECS;
using UnityEngine;

namespace GameOne.Ecs.UnitTest
{
    public class CatSpawnSystem : IEcsInit
    {
        [EcsInject] EcsDefaultWorld _world;
        
        public void Init()
        {
            ViewTest();
        }
        
        /// <summary>
        /// 带动view的变化
        /// </summary>
        void ViewTest()
        {
            GameObject cat = Resources.Load<GameObject>("GameOne/Prefab/Cat");
            int entityCount = 1000;
            for (int i = 0; i < entityCount; i++)
            {
                Vector2 position = Random.insideUnitCircle;
                var entity = _world.NewEntityLong();
                //链接GameObject
                GameObject catInstance = UnityEngine.Object.Instantiate(cat);
                entity.Connect(catInstance,false);
                
                LogicTransform logicTransform = new LogicTransform()
                {
                    position = position,
                };
                entity.Add(ref logicTransform);

                View view = new View()
                {
                    transform = catInstance.transform,
                    elapsedTime = 0,
                };
                entity.Add(ref view);
            }
        }
    }
}