using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
    public AudioSource au_Haha;


    // Use this for initialization
    void Start()
    {
    }

    void Obstacle()
    {
        au_Haha = (AudioSource)gameObject.AddComponent<AudioSource>();
        AudioClip myAudioClip;
        myAudioClip = (AudioClip)Resources.Load("Haha");
        au_Haha.clip = myAudioClip;

        au_Haha.Play();
    }

}
