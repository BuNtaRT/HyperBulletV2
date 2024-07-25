
using Lib;
using UnityEngine;

namespace Bullet.BulletBase
{
    public static class BulletColors
    {
        public static readonly Color Simple = ColorTools.FromHex("");
        public static readonly Gradient SimpleGradient = Simple.ConvertToGradient();
    }
}