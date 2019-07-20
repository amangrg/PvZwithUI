using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public void LevelOne()
    {
        //Debug.Log("Level One Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelTwo()
    {
        //Debug.Log("LevelTwo Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void BackButton()
    {
        //Debug.Log("Back button Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
