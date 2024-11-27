using UnityEngine;

namespace Lib
{
    public static class Vector2Tools
    {
        public static Vector2 GetRandomPointOnCircle(Vector2 center, float radius)
        {
            float randomAngle = Random.Range(0f, 2f * Mathf.PI);
            
            float x = center.x + radius * Mathf.Cos(randomAngle);
            float y = center.y + radius * Mathf.Sin(randomAngle);

            return new Vector2(x, y);
        }
    }
}