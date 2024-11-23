using System;
using UnityEngine;

namespace Assets.Code.Extensions
{
    internal static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);
    }
}
