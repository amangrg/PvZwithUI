using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    int resumeLevel;
    public Button resume;
    void Start()
    {
        resumeLevel = PlayerPrefs.GetInt("Current Level");
        if(resumeLevel == 0)
        {
            resume.interactable = false;
        } 
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