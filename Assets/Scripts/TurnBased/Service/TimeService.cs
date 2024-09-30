

namespace GameOne
{
    /// <summary>
    /// 存储时间
    /// </summary>
    public class TimeService
    {
        public float time;
        public float fixedTime;
        public float deltaTime;
        public float fixedDeltaTime = 0.02f;
        public float elapsedTime = 0f;
        public int targetMaxFrame = 500;
        

        /*public static TimeService CreateInstance()
        {
            return new TimeService();
        }*/
    }

    
}