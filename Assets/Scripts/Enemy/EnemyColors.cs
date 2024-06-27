using UnityEngine;

namespace Enemy
{
    public static class EnemyColors
    {
        public static readonly Color Red = new Color(1, 0, 0.390801f, 0.4f);
        public static readonly Color Auaq = new Color(0, 1, 0.9764706f, 0.4f);
        public static readonly Color Yellow = new Color(1, 0.69f, 0, 0.4f);
        public static readonly Color Purpule = new Color(0.58f, 0f, 1, 0.4f);
        public static readonly Color Green_white = new Color(0.5061855f, 0.8584906f, 0.5474501f, 0.4f);

        private static readonly Color[] colors = new Color[] { Red, Auaq, Yellow, Purpule, Green_white };

        public static Color GetRandomColor() =>
            colors[Random.Range(0, colors.Length - 1)];
    }
}