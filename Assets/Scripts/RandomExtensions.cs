using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class RandomExtensions
{
    public static Vector3 GetInsideUnitSphere(this Random rand, float minUnitRadius)
    {
        if (!(minUnitRadius < 1.0f && minUnitRadius > 0.0f))
            throw new System.ArgumentException("must be betwee 0.0 - 1.0");

        var value = Random.insideUnitSphere;
        if (Mathf.Abs(value.x) < minUnitRadius)
        {
            if (value.x < 0.0f)
                value.x -= minUnitRadius;
            else
                value.x += minUnitRadius;
        }
        if (Mathf.Abs(value.z) < minUnitRadius)
        {
            if (value.z < 0.0f)
                value.z -= minUnitRadius;
            else
                value.z += minUnitRadius;

        }
        return value;
    }
}
