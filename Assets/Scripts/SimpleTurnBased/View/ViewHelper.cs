using System.IO;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.U2D;

namespace SimpleTurnBased.View
{
    public static class ViewHelper
    {
        public static SpriteAtlas GetSpriteAtlas()
        {
            return Resources.Load<SpriteAtlas>(Path.Combine(CstStr.Image, "SpriteAtlas"));
        }
    }
}