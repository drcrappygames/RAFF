﻿using UnityEngine;
using UnityEngine.AI;

public static class Extensions
{
    public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
    }

    public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
    {
        return new Vector2(x ?? original.x, y ?? original.y);
    }

    //Only works when stopping distance == 0;
    public static bool CheckIfReachedDestination(this NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent.hasPath || navMeshAgent.pathPending)
            return false;

        return true;
    }

    public static Color Invert(this Color color)
    {
        return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
    }
}
