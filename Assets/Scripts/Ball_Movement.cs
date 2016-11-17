using UnityEngine;
using System.Collections;

public class Ball_Movement : MonoBehaviour
{
    [SerializeField]
    private float Rightspeed;
    [SerializeField]
    public float ForwardSpeed;
    [SerializeField]
    private float Fallingspeed;
    [SerializeField]
    private float Jumpspeed;
    [SerializeField]
    private bool grounded = false;

    public GameObject box;

    CheckCollision collisionCheck;
    

	// Use this for initialization
	void Start ()
    {
        Rightspeed = 1.0f;
        Jumpspeed = 200.0f;
        ForwardSpeed = 10.0f;
        Fallingspeed = .1f;
        collisionCheck = GetComponent<CheckCollision>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        grounded = collisionCheck.CheckIfCollision(this.gameObject, box);
        if (!grounded)
        {
            this.gameObject.transform.position = Vector3Self.Falling(this.gameObject, Fallingspeed);
        }

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


        // Moving forward all the time
        this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X, MovementVector.Y, MovementVector.Z + ForwardSpeed * Time.deltaTime);
  	}
}
