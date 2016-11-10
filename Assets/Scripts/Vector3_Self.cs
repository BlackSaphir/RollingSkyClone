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

        public float U { get; private set; }
        public float V { get; private set; }


        public Vector3S(float x, float y, float z)
            : this()
        {
            A = x;
            B = y;
            C = z;
        }

        public float A { get; private set; }
        public float B { get; private set; }
        public float C { get; private set; }


        public  Vector3S back {get;} 



















        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
