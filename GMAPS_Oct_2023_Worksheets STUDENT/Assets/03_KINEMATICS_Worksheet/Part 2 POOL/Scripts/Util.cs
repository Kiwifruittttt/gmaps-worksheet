using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        return Mathf.Sqrt((p2.x - p1.x) * (p2.x - p1.x) + (p2.y - p1.y) * (p2.y - p1.y));

        HVector2D a = new HVector2D(8f, 5f);
        HVector2D b = new HVector2D(1f, 3f);
        float distance = Util.FindDistance(a, b);



    }
}

