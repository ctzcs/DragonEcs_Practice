using Base;
using DCFApixels.DragonECS;
using Survivor.Actor;
using Survivor.Property;
using UnityEngine;

namespace GameOne.Ecs.Z_UnitTest
{
    public class CatSpawnSystem : IEcsInit
    {
        [EcsInject] EcsDefaultWorld _world;
        private int _entityCount = 2000;
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
            for (int i = 0; i < _entityCount; i++)
            {
                Vector2 position = Random.insideUnitCircle;
                var entity = _world.NewEntityLong();
                
                //链接GameObject
                GameObject catInstance = UnityEngine.Object.Instantiate(cat);
                entity.Connect(catInstance,false);
                
                VelPos logicTransform = new VelPos()
                {
                    position = position,
                };
                entity.Add(ref logicTransform);
                

                View view = new View()
                {
                    transform = catInstance.transform,
                    sp = catInstance.GetComponent<SpriteRenderer>(),
                    Color = Color.white
                };
                entity.Add(ref view);
                
                //KdTree
                Evt_AddToKdTree addToKdTree = new Evt_AddToKdTree
                {
                    target = entity
                };
                _world.NewEntityLong().Add(ref addToKdTree);
            }
        }
    }
}