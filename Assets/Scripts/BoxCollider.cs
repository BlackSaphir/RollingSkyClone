using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BoxCollider : MonoBehaviour
{
    public bool OnCollision;
    public SphereCollision Sphere;
    public bool IsJumping;
    public float Timer;
    public float TimerTillLoseScene;
    public bool CheckTimerTillLoseScene;
    public AudioManager AudioContainer;
    public float Distance;
    public string SceneToDelete;
    public string SceneToLoad;
    public bool DeleteScene;
    public float TimerTillDelete;

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
        Sphere = FindObjectOfType<SphereCollision>();
        collisionCheck = GetComponent<BoxCollider>();
        Timer = 0f;
        IsJumping = false;
        soundSource = GetComponent<AudioSource>();
        ballMovement = Sphere.GetComponent<BallMovement>();
        TimerTillLoseScene = 0f;
        CheckTimerTillLoseScene = false;
        DeleteScene = false;
    }

    void Update()
    {
        if (Sphere != null)
        {
            OnCollision = collisionCheck.CheckIfCollisionBox(Sphere.gameObject, this.gameObject);
            if (OnCollision)
            {// there is collision
                if (!Sphere.Collisions.Contains(this)) // if thhis collider doesnt exist already add it to the List
                {
                    Sphere.Collisions.Add(this);

                    // Ground
                    if (this.gameObject.layer == 8)
                    {
                        Sphere.FallingSpeed = 0;

                        // JumpBox
                        if (this.gameObject.tag == "JumpBox")
                        {
                            Sphere.JumpSpeed = 60;
                            IsJumping = true;
                            soundSource.clip = AudioContainer.au_Jump;
                            soundSource.Play();
                            Application.LoadLevelAdditiveAsync(SceneToLoad);
                            DeleteScene = true;

                        }

                        // Victory
                        if (this.gameObject.tag == "Victory")
                        {
                            Sphere.FallingSpeed = 0;
                            ballMovement.Rightspeed = 0;
                            Sphere.VictoryCanvas.SetActive(true);
                            Sphere.Victory = true;
                        }
                    }

                    // Obstacle
                    else if (this.gameObject.tag == "Obstacle")
                    {
                        ballMovement.Crashed = true;
                        // Play Sound
                        if (!soundSource.isPlaying)
                        {
                            soundSource.clip = AudioContainer.au_Collision;
                            soundSource.Play();
                        }
                        Destroy(this.Sphere, 0.4f);
                        CheckTimerTillLoseScene = true;
                    }

                    // Item
                    if (this.gameObject.tag == "Item")
                    {
                        Utility.Points += 1;
                        this.gameObject.SetActive(false);
                        Sphere.Collisions.Remove(this);
                    }
                }
            }
            else
            {
                // no collision
                if (Sphere.Collisions.Contains(this)) // if this collider already exist remove it
                {
                    Sphere.Collisions.Remove(this);
                }

                if (Sphere.Collisions.Count == 0) // No Collisions left start falling
                {
                    Sphere.FallingSpeed = 4f;
                }
            }

            if (IsJumping)
            {
                Timer += Time.deltaTime;
                if (Timer > 0.4f)
                {
                    Sphere.JumpSpeed = 0f;
                    Timer = 0f;
                    IsJumping = false;
                }
            }
        }
        if (CheckTimerTillLoseScene)
        {

            TimerTillLoseScene += Time.deltaTime;
            if (TimerTillLoseScene >= 1.5f)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }


        if (DeleteScene)
        {
            TimerTillDelete += Time.deltaTime;
            if (TimerTillDelete > 2.1f)
            {
                Application.UnloadLevel(SceneToDelete);
            }
        }
    }



}
