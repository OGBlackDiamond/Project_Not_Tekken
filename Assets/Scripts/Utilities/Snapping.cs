using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Snapping
{
    public static Vector2 Round(Vector2 vector)
    {
        vector.x = Mathf.Round(vector.x);
        vector.y = Mathf.Round(vector.y);
        return vector;
    }
    public static Vector3 Round(Vector3 vector)
    {
        vector.x = Mathf.Round(vector.x);
        vector.y = Mathf.Round(vector.y);
        vector.z = Mathf.Round(vector.z);
        return vector;
    }
    public static Vector4 Round(Vector4 vector)
    {
        vector.x = Mathf.Round(vector.x);
        vector.y = Mathf.Round(vector.y);
        vector.z = Mathf.Round(vector.z);
        vector.w = Mathf.Round(vector.w);
        return vector;
    }
    public static List<float> Round(List<float> vector)
    {
        List<float> output = new List<float>();

        foreach (float num in vector)
        {
            output.Add(Mathf.Round(num));
        }

        return output;
    }
    public static float[] Round(float[] vector)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            vector[i] = Mathf.Round(vector[i]);
        }
        return vector;
    }
}
