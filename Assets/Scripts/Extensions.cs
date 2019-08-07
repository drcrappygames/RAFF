using UnityEngine;
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

    public static string ToMD5(this string original)
    {
        System.Security.Cryptography.MD5 md5hash = System.Security.Cryptography.MD5.Create();
        byte[] data = md5hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(original));
        System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
        foreach (byte b in data)
        {
            strBuilder.Append(b.ToString("x2"));
        }
        return strBuilder.ToString();
    }
}
