using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public static int LevelProgress;
    void Start()
    {
        LevelProgress = PlayerPrefs.GetInt("Current Level",1);
        Debug.Log(LevelProgress);
    }
    public void Playbutton()
    {
        Debug.Log("Play button Pressed");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(LevelProgress);
    }

    public void QuitButton()
    {
        //Debug.Log("Quit button Pressed");
        //Application.Quit();
        PlayerPrefs.DeleteKey("Current Level");

    }

    public void CreditsButton()
    {
        //Debug.Log("Credits button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}