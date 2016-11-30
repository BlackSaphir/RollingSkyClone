using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    public float ForwardSpeed;
    [SerializeField]
    private float Jumpspeed;
    [SerializeField]
    private float SideMovement;

    public float Rightspeed;
    public bool Crashed;
    Vector3Self MovementVector;

    // Use this for initialization
    void Start()
    {
        Jumpspeed = 100.0f;
        ForwardSpeed = 10.0f;
        Crashed = false;
        Rightspeed = 18.0f;
    }

#if UNITY_STANDALONE
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
    // Update is called once per frame
    void Update()
    {
        if (Countdown.play)
        {
            MovementVector = new Vector3Self(0, 0, 0);
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                MovementVector.X = Input.GetTouch(0).deltaPosition.x;

            }

            if (!crashed)
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
