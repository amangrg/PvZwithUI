using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    int resumeLevel;
    void Start()
    {
        resumeLevel = PlayerPrefs.GetInt("Current Level", 3);
        Debug.Log(resumeLevel);
    }
    public void Resume()
    {
        SceneManager.LoadScene(resumeLevel);
    }
    public void Playbutton()
    {
        //Debug.Log("Play button Pressed");
        PlayerPrefs.DeleteKey("Current Level");
        SceneManager.LoadScene(3);
    }

    public void QuitButton()
    {
        //Debug.Log("Quit button Pressed");
        Application.Quit();
    }

    public void CreditsButton()
    {
        //Debug.Log("Credits button Pressed");
        SceneManager.LoadScene(1);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene(2);
    }
}