using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SphereCollision : MonoBehaviour
{
    public float JumpSpeed;
    public AudioManager AudioContainer;
    public float Distance;
    public float Timer;
    public float FallingSpeed;
    public bool Victory;
    public float VictoryTimer;
    public GameObject VictoryCanvas;

    /// <summary>
    /// A List of Collideres this Collider is currently colliding with.
    /// </summary>
    public List<BoxCollider> Collisions;

    private AudioSource soundSourceSphere;
    private bool died;



    public bool CheckIfCollisionSphere(GameObject Sphere, GameObject other)
    {
        if (Sphere != null)
        {

            //position = center, localScale = scale
            float MinX = other.transform.position.x - (other.transform.localScale.x / 2);
            float MinY = other.transform.position.y - (other.transform.localScale.y / 2);
            float MinZ = other.transform.position.z - (other.transform.localScale.z / 2);

            float MaxX = other.transform.position.x + (other.transform.localScale.x / 2);
            float MaxY = other.transform.position.y + (other.transform.localScale.y / 2);
            float MaxZ = other.transform.position.z + (other.transform.localScale.z / 2);

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
        FallingSpeed = 4f;
        JumpSpeed = 0f;
        soundSourceSphere = GetComponent<AudioSource>();
        soundSourceSphere.clip = AudioContainer.au_BackBeat;
        soundSourceSphere.Play();
        Victory = false;
        VictoryCanvas.SetActive(false);
    }

    void Update()
    {
        this.transform.position = Vector3Self.Falling(this.gameObject, FallingSpeed);
        this.transform.position = Vector3Self.Jumping(this.gameObject, JumpSpeed);

        // die if below y < - 
        if (this.gameObject.transform.position.y < -7)
        {
            // play Sound
            if (!died)
            {
                soundSourceSphere.PlayOneShot(AudioContainer.au_Death[Random.Range(0, AudioContainer.au_Death.Length)], 1);
                died = true;
            }
            Timer += Time.deltaTime;
            // load Scene
            if (Timer > 3.8f)
            {
                Destroy(this.gameObject, 2f);
                SceneManager.LoadScene("LoseScene");
            }
        }

        if (Victory)
        {
            VictoryTimer += Time.deltaTime;
            if (VictoryTimer > 3.1f)
            {
                SceneManager.LoadScene("VictoryScene");
            }
        }
    }
}
