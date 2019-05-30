using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtils
{
    public static Vector3 GetFlat(this Vector3 vector)
    {
        vector.y = 0;
        return vector;
    }
}
