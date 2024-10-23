using UnityEngine;

namespace Utility.Gizmos
{
    public class DrawBoxGizmos:IGizmosCommand
    {
        private Color _color;
        private Vector3 _center;
        private Vector2 _size;

        public DrawBoxGizmos Set(Vector3 center,Vector2 size,Color color)
        {
            _center = center;
            _size = size;
            _color = color;
            return this;
        }
        public void Draw()
        {
            var oldColor = UnityEngine.Gizmos.color;
            UnityEngine.Gizmos.color = _color;

            var halfWidth = _size.x * 0.5f;
            var halfHeight = _size.y * 0.5f;

            var topLeft = _center + new Vector3(-halfWidth,halfHeight,0 );
            var topRight = _center + new Vector3(halfWidth, halfHeight, 0);
            var bottomLeft = _center + new Vector3(-halfWidth, -halfHeight, 0);
            var bottomRight = _center + new Vector3(halfWidth,-halfHeight, 0 );

            UnityEngine.Gizmos.DrawLine(topLeft, topRight);
            UnityEngine.Gizmos.DrawLine(topRight, bottomRight);
            UnityEngine.Gizmos.DrawLine(bottomRight, bottomLeft);
            UnityEngine.Gizmos.DrawLine(bottomLeft, topLeft);
            
            UnityEngine.Gizmos.color = oldColor;
        }
    }
}