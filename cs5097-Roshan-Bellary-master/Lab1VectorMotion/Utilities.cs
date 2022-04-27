using System;
using System.Numerics;

namespace Utilities
{
    static class ExtensionMethods
    {
        /// <summary>
        /// Rounds Vector3.
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
        {
            float multiplier = 1;
            for (int i = 0; i < decimalPlaces; i++)
            {
                multiplier *= 10f;
            }
            return new Vector3(
                MathF.Round(vector3.X * multiplier) / multiplier,
                MathF.Round(vector3.Y * multiplier) / multiplier,
                MathF.Round(vector3.Z * multiplier) / multiplier);
        }
    }
}