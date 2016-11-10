using UnityEngine;

public class Vector3Self : MonoBehaviour
{
    public struct Vector3S
    {
        public float x;
        public float y;
        public float z;

        public Vector3S(float x, float y)
            : this()
        {
            U = x;
            V = y;
        }

        //erlaubt
        public float U { get; private set; }
        public float V { get; private set; }

        //nicht erlaubt da property im Struct (gleicher typ)
        //public Vector3S Penis { get; set; }

        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }

        public Vector3S(float x, float y, float z)
            : this()
        {
            A = x;
            B = y;
            C = z;
        }




        //public  Vector3S back {get;}
        //prop Tab tab macht dir automatisch eine property in C# Easy 
    }
    public Vector3S back { get; set; }
    public Vector3S down { get; set; }
    public Vector3S forward { get; set; }
    public Vector3S left { get; set; }
    public Vector3S right { get; set; }
    public Vector3S up { get; set; }
    public float magnitude { get; set; }
    public float normalize { get; set; }
    public float sqrmagnitude { get; set; }
    public static Vector3S operator +(Vector3S a, Vector3S b)
    {

    }






    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
