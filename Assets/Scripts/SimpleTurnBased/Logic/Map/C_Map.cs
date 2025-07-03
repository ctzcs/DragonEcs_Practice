using System;
using System.Text;
using DCFApixels.DragonECS;

namespace SimpleTurnBased.Logic.Map
{
    [Serializable]
    public struct C_Map:IEcsComponent
    {
        public int width;
        public int height;
        public Grid[,] bottom; //TODO 简单版本
        /*public Grid[,] mid;
        public Grid[,] top;*/

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    sb.Append(bottom[i,j].icon);
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }

    [Serializable]
    public class Grid
    {
        public ELayer layer;
        public bool hasSth;
        public string icon;
        public int ent;
    }

    public enum ELayer
    {
        Down,
        Mid,
        Top
    }
}