using System.Globalization;
using UnityEngine;

namespace Lib
{
    public static class ColorTools
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="color">Entry color</param>
        /// <returns>Gradient(entry color alpha=1, entry color alpha=0)</returns>
        public static Gradient ConvertToGradient(this Color color)
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKey = new GradientColorKey[1];
            colorKey[0].color = new Color(color.r, color.g, color.b);
            colorKey[0].time = 0f;
            GradientAlphaKey[] alphaKey = new GradientAlphaKey[1];
            alphaKey[0].alpha = 1;
            alphaKey[0].time = 0;
            gradient.SetKeys(colorKey, alphaKey);

            return gradient;
        }

        public static Color FromHex(string hex)
        {
            hex = hex.Replace("#", "");
            byte[] colors = new byte[] { 0, 0, 0, 255 };

            var colorI = 0;
            for (int i = 0; i <= hex.Length; i = +2)
            {
                colors[colorI] = byte.Parse(hex.Substring(i, 2), NumberStyles.HexNumber);
                colorI++;
            }

            return new Color32(colors[0], colors[1], colors[2], colors[3]);
        }

        public static Color SetAlpha(Color color, float alpha) =>
            new Color(color.r, color.g, color.b, alpha);
    }
}
