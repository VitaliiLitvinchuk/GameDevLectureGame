using System;
using UnityEngine;

namespace Assets.Code.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);

        public static Vector3 AddX(this Vector3 vector, float x) => vector.WithX(vector.x + x);
    }
}
