using UnityEngine;
using System.Collections;

public class CheckCollision : MonoBehaviour
{
    public float distance;
    public bool CheckIfCollision(GameObject Sphere, GameObject Cube)
    {
        // position = Center, localScale = Scale
        float MinX = Cube.transform.position.x - (Cube.transform.localScale.x / 2);
        float MinY = Cube.transform.position.y - (Cube.transform.localScale.y /2);
        float MinZ = Cube.transform.position.z - (Cube.transform.localScale.z/2);

        float MaxX = Cube.transform.position.x + (Cube.transform.localScale.x /2);
        float MaxY = Cube.transform.position.y + (Cube.transform.localScale.y /2);
        float MaxZ = Cube.transform.position.z + (Cube.transform.localScale.z /2);


        float X = Mathf.Max(MinX, Mathf.Min(Sphere.transform.position.x, MaxX));
        float Y = Mathf.Max(MinY, Mathf.Min(Sphere.transform.position.y, MaxY));
        float Z = Mathf.Max(MinZ, Mathf.Min(Sphere.transform.position.z, MaxZ));


        distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - (Sphere.transform.position.y + 0.5f)) * (Y - (Sphere.transform.position.y + 0.5f)) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));


        return distance < Sphere.transform.localScale.y;
    }
}
