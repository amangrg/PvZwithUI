using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 *startgame is first always called at begining or when game is opened.
it initializes start ing variables and let user navigate where to go in the game (level, pause, resume, quit)
*/
public class StartGame : MonoBehaviour
{
    private int resumeLevel = 0;           //To resume the level 
    [SerializeField]
    private Button resume = null;
    [SerializeField]
    private Button play= null;
    [SerializeField]
    private Button quit = null;
    [SerializeField]
    private Button credits = null;
    [SerializeField]
    private Button levels = null;

    
    //resume.GetComponent<Button>().onClick.AddListener(() => onButtonClick(index));

    //Start Function is called at the start of the game always,it is used to initialize methods and variables needed at the start.
    void Start()
    {
        resumeLevel = PlayerPrefs.GetInt("Current Level");         //Getting the Current Level which the user was on
        if(resumeLevel == 0)
        {
            resume.interactable = false;                           //Suggesting that user was on level 0 at the start
        }

        resume.onClick.AddListener(delegate { Resume(); });
        play.onClick.AddListener(delegate { Playbutton(); });
        quit.onClick.AddListener(delegate { QuitButton(); });
        credits.onClick.AddListener(delegate { CreditsButton(); });
        levels.onClick.AddListener(delegate { LevelSelect(); });
    }

    //Resume the last played level
    private void Resume()
    {
        SceneManager.LoadScene(resumeLevel);
    }

    //Start a New game
    private void Playbutton()
    {
        //Debug.Log("Play button Pressed");
        PlayerPrefs.DeleteKey("Current Level");
        SceneManager.LoadScene(3);
    }

    //Quit the Game

    private void QuitButton()
    {
        //Debug.Log("Quit button Pressed");
        Application.Quit();
    }

    //Display Credits
    private void CreditsButton()
    {
        //Debug.Log("Credits button Pressed");
        SceneManager.LoadScene(1);
    }

    //Display LevelSelect Screen
    private void LevelSelect()
    {
        SceneManager.LoadScene(2);
    }
}