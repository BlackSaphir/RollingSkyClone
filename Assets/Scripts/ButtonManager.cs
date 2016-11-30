using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void start(string scene)
    {
        Countdown.Play = false;
        SceneManager.LoadScene(scene);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void EndGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}


