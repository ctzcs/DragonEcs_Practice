using UnityEngine;

namespace GameOne.Utils
{
    public class MathExtension
    {
        public static void Clamp(ref int value,int min,int max)
        {
            value = Mathf.Clamp(value, min, max);
        }
    }
}