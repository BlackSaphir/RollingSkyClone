using UnityEngine;
using System.Collections;

public class BoxCollider : MonoBehaviour
{
    public bool OnCollision;
    public SphereCollision Sphere;

    public bool IsJumping;
    public float Timer;

    public AudioManager AudioContainer;
    public float Distance;

    private BoxCollider collisionCheck;
    private AudioSource soundSource;
    private BallMovement ballMovement;

    public bool CheckIfCollisionBox(GameObject Sphere, GameObject Self)
    {
        if (Sphere != null)
        {

            //position = center, localScale = scale
            float MinX = Self.transform.position.x - (Self.transform.localScale.x / 2);
            float MinY = Self.transform.position.y - (Self.transform.localScale.y / 2);
            float MinZ = Self.transform.position.z - (Self.transform.localScale.z / 2);

            float MaxX = Self.transform.position.x + (Self.transform.localScale.x / 2);
            float MaxY = Self.transform.position.y + (Self.transform.localScale.y / 2);
            float MaxZ = Self.transform.position.z + (Self.transform.localScale.z / 2);

            float X = Mathf.Max(MinX, Mathf.Min(Sphere.transform.position.x, MaxX));
            float Y = Mathf.Max(MinY, Mathf.Min(Sphere.transform.position.y, MaxY));
            float Z = Mathf.Max(MinZ, Mathf.Min(Sphere.transform.position.z, MaxZ));

            Distance = Mathf.Sqrt((X - Sphere.transform.position.x) * (X - Sphere.transform.position.x) + (Y - Sphere.transform.position.y) * (Y - Sphere.transform.position.y) + (Z - Sphere.transform.position.z) * (Z - Sphere.transform.position.z));

            return Distance < Sphere.transform.localScale.y / 2;
        }

        return false;
    }


    void Start()
    {
        collisionCheck = GetComponent<BoxCollider>();
        Timer = 0f;
        IsJumping = false;
        soundSource = GetComponent<AudioSource>();
        ballMovement = Sphere.GetComponent<BallMovement>();
    }

    void Update()
    {
        if (Sphere != null)
        {
            OnCollision = collisionCheck.CheckIfCollisionBox(Sphere.gameObject, this.gameObject);
            if (OnCollision)
            {// there is collision
                if (!Sphere.Collisions.Contains(this)) // if this collider is not contained in previous collisions...
                {
                    Sphere.Collisions.Add(this); // ... then we have a new collision (CollisionEnter) and add it to the list of current collisions
                    
                    // Ground
                    if (this.gameObject.layer == 8)
                    {
                        Sphere.FallingSpeed = 0;
                        Timer = 0f;

                        // JumpBox
                        if (this.gameObject.tag == "JumpBox")
                        {
                            Sphere.JumpSpeed = 1;
                            IsJumping = true;
                            soundSource.clip = AudioContainer.au_Jump;
                            soundSource.Play();
                        }
                    }

                    // Obstacle
                    else if (this.gameObject.tag == "Obstacle")
                    {
                        ballMovement.crashed = true;
                        // Play Sound
                        if (!soundSource.isPlaying)
                        {
                            soundSource.clip = AudioContainer.au_Collision;
                            soundSource.Play();
                        }
                        Destroy(this.Sphere, 0.4f);
                    }
                }
            }
            else
            {// no collision
                if (Sphere.Collisions.Contains(this)) // if this collider is contained in previous collisions...
                {
                    Sphere.Collisions.Remove(this); // ... then we remove it from the list of current collisions (CollisionExit)
                }

                if (Sphere.Collisions.Count == 0) // if there are no current collisions left...
                {
                    Sphere.FallingSpeed = 0.1f; // ... then start falling
                }
            }

            if (IsJumping)
            {
                Timer += Time.deltaTime;
                if (Timer > 0.5f)
                {
                    Sphere.JumpSpeed = 0f;
                    Sphere.FallingSpeed = 0.2f;
                    IsJumping = false;
                }
            }
        }

    }
}