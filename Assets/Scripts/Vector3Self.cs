using UnityEngine;
using System.Collections;

public class Vector3Self : MonoBehaviour
{
    float X;
    float Y;
    float Z;

    public static implicit operator Vector3(Vector3Self B)
    {
        return new Vector3(B.X, B.Y, B.Z);
    }
    
    public Vector3Self(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3Self Translation(Vector3Self end)
    {
        return new Vector3Self(end.X, end.Y, end.Z);
    }

    public Vector3Self Position(GameObject A)
    {
        return new Vector3Self(A.transform.position.x, A.transform.position.y, A.transform.position.z);
    }

    public Vector3Self Falling(Vector3Self C)
    {
        return new Vector3Self(C.transform.position.x, C.transform.position.y, C.transform.position.z);
    }
}
