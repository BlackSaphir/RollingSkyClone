using UnityEngine;
using System.Collections;

public class Ball_Movement : MonoBehaviour
{
    [SerializeField]
    private float Rightspeed;
    [SerializeField]
    public float ForwardSpeed;
    [SerializeField]
    private float Jumpspeed;

    public bool crashed;


    // Use this for initialization
    void Start()
    {
        Rightspeed = 0.1f;
        Jumpspeed = 100.0f;
        ForwardSpeed = 10.0f;
        crashed = false;
    }

    // Update is called once per frame
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3Self MovementVector = new Vector3Self(horizontal, vertical, 0);

        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X + Rightspeed * Time.deltaTime, MovementVector.Y, MovementVector.Z);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X + Rightspeed * Time.deltaTime, MovementVector.Y, MovementVector.Z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X, MovementVector.Y + Jumpspeed * Time.deltaTime, MovementVector.Z);
        }

        if (!crashed)
        {
        // Moving forward all the time
        this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X, MovementVector.Y, MovementVector.Z + ForwardSpeed * Time.deltaTime);
        }
    }
}
