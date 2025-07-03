using Framework.UI;
using SimpleTurnBased.View.UI;
using UnityEngine;

namespace SimpleTurnBased
{
    public class Main:MonoBehaviour
    {
        private Ecs_Stb _ecsStb;
        private void Awake()
        {
            _ecsStb = new Ecs_Stb();
            ECSMgr.Add(_ecsStb);
            ECSMgr.SetCurEcs(_ecsStb);
        }

        private void Start()
        {
            _ecsStb.Start();
            UIHelper.Show<MainPanel>();
        }

        private void OnDestroy()
        {
            ECSMgr.Remove<Ecs_Stb>();
        }

        private void FixedUpdate()
        {
            _ecsStb.FixedUpdate();
        }

        private void Update()
        {
            _ecsStb.Update();
        }

        
    }
}