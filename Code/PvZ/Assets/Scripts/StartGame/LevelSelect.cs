using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
    int levelLocked;
    public Button[] button;
    public int total_levels = 3;
    void Start()
    {
        levelLocked = PlayerPrefs.GetInt("Current Level",2);
        Debug.Log(levelLocked);
        for(int  i = levelLocked - 2; i < total_levels; i++)
        {
            button[i].interactable = false;
        }
    }
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

    public void LevelThree()
    {
        //Debug.Log("LevelThree Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void BackButton()
    {
        //Debug.Log("Back button Pressed");
        SceneManager.LoadScene(0);
    }

    public void Resetbutton()
    {
        PlayerPrefs.DeleteKey("Current level");
        Debug.Log(PlayerPrefs.GetInt("Current Level"));
    }
}
