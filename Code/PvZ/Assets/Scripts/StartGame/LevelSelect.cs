using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//allows user to select level based on player's click and takes player to that level scene
public class LevelSelect : MonoBehaviour
{
    
    private int levelLocked = 3;

    [SerializeField]
    private Button level1 = null;

    [SerializeField]
    private Button level2 = null;

    [SerializeField]
    private Button level3 = null;

    [SerializeField]
    private Button back = null;


    // Start is called before the first frame update
   
    //player can only interact with levels if they are not locked 
    void Start()
    {
        levelLocked = PlayerPrefs.GetInt("Current Level",3);
        //Debug.Log(levelLocked);
        level1.onClick.AddListener(delegate { LevelOne(); });
        level2.onClick.AddListener(delegate { LevelTwo(); });
        level3.onClick.AddListener(delegate { LevelThree(); });
        back.onClick.AddListener(delegate { BackButton(); });
        if (levelLocked == 3)
        {
            level2.interactable = false;
            level3.interactable = false;
        }
        else if (levelLocked == 4)
        {
            level3.interactable = false;
        }
    }

    //The below functions are used to load particular one, the one whos button was pressed.
    private void LevelOne()
    {
        //Debug.Log("Level One Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void LevelTwo()
    {
        //Debug.Log("LevelTwo Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void LevelThree()
    {
        //Debug.Log("LevelThree Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    private void BackButton()
    {
        //Debug.Log("Back button Pressed");
        SceneManager.LoadScene(0);
    }

}
