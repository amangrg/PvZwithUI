using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public void Playbutton()
    {
        Debug.Log("Play button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        //Debug.Log("Quit button Pressed");
        Application.Quit();
    }

    public void CreditsButton()
    {
        //Debug.Log("Credits button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}