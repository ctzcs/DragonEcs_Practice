using UnityEngine;

namespace Framework
{
    internal class UniEventDriver:MonoBehaviour
    {
        private void Update()
        {
            UniEvent.Update();
        }
    }
}