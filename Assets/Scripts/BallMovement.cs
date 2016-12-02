using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    public float ForwardSpeed;
    public float JumpSpeed;
    public float Rightspeed;
    public bool Crashed;


    // Use this for initialization

#if UNITY_STANDALONE
    void Start()
    {
        ForwardSpeed = 10.0f;
        Crashed = false;
        Rightspeed = 13.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Countdown.Play)
        {

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3Self MovementVector = new Vector3Self(horizontal, vertical, 0);

            if (!Crashed)
            {
                // Moving forward all the time
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X * Rightspeed * Time.deltaTime, MovementVector.Y, MovementVector.Z + ForwardSpeed * Time.deltaTime);
            }
        }

    }
#endif
#if UNITY_ANDROID
    void Start ()
    {
        JumpSpeed = 100f;
        ForwardSpeed = 10.0f;
        Crashed = false;
        Rightspeed = 4;
    }


    // Update is called once per frame


    void Update()
    {
        if (Countdown.Play)
        {
            Vector3Self MovementVector = new Vector3Self(0, 0, 0);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovementVector.X = Input.GetTouch(0).deltaPosition.x;

            }

            if (!Crashed)
            {
                // Moving forward all the time
                this.gameObject.GetComponent<Transform>().transform.Translate(MovementVector.X * Rightspeed * Time.deltaTime, MovementVector.Y, MovementVector.Z + ForwardSpeed * Time.deltaTime);
            }
        }

    }
#endif

    // to change Speed in Game
    void OnGUI()
    {
        Rightspeed = GUI.HorizontalSlider(new Rect(0, 0, 120, 20), Rightspeed, 0, 10);
    }
}
