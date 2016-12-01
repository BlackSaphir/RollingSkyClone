using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject MenuObject;

    public void start(string scene)
    {   
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        MenuObject.SetActive(false);
        Time.timeScale = 1;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.timeScale == 0)
            {
                MenuObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                MenuObject.SetActive(true);
                Time.timeScale = 0;
            }
        }


    }

    public void EndGame(string scene)
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        MenuObject.SetActive(false);
        Time.timeScale = 1;
    }


}
