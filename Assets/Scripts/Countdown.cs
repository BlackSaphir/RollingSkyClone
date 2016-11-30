using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text TextObject;
    public GameObject MenuObject;
    public static bool Play = false;
    public AudioManager AudioContainer;

    private float timer = 4;
    private bool textbool = true;
    private AudioSource soundSource;


    // Use this for initialization
    void Start()
    {
        MenuObject.SetActive(true);
        TextObject.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (textbool)
        {
            timer -= Time.deltaTime;
            TextObject.text = ((int)timer).ToString();
            if (timer <= 0)
            {
                Play = true;
                MenuObject.SetActive(false);
                textbool = false;

            }


        }
    }
}
