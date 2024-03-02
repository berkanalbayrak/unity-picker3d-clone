using UnityEngine;

namespace Utils
{
    public static class VectorExtensions
    {
        public static Vector2 ConvertPixelsToInches(this Vector2 pixelDelta)
        {
            return pixelDelta / Screen.dpi;
        }
    }
}