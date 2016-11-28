using UnityEngine;
using System.Collections;

public class Vector3Self : MonoBehaviour
{


    public float X, Y, Z;
    public Vector3Self(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
    public Vector3Self Translate(Vector3Self end)
    {
        return new Vector3Self(end.X, end.Y, end.Z);
    }

    public static implicit operator Vector3(Vector3Self m)
    {
        return new Vector3(m.X, m.Y, m.Z);
    }

    public static implicit operator Vector3Self(Vector3 m)
    {
        return new Vector3Self(m.x, m.y, m.z);
    }

    public Vector3Self Position(GameObject A)
    {
        return new Vector3Self(A.transform.position.x, A.transform.position.y, A.transform.position.z);
    }

    public static Vector3Self Falling (GameObject B, float Fallingspeed)
    {
        return new Vector3Self(B.transform.position.x, B.transform.position.y - Fallingspeed, B.transform.position.z);
    } 

    public static Vector3Self Jumping(GameObject C, float JumpspeedV)
    {
        return new Vector3Self(C.transform.position.x, C.transform.position.y + JumpspeedV, C.transform.position.z);
    }
}
