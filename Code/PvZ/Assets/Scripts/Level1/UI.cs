using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public bool GameOver = false;
    public bool Level_Complete = false;
    public static bool GamePaused = false;
    public bool GameQuitDialog = false;
    public bool GameMenuDialog = false;
    public Slider slider;
    public GameObject PauseMenu = null;
    public GameObject GameOverUI = null;
    public GameObject LevelCompleteUI = null;
    public GameObject GameQuitDialogBox = null;
    public GameObject GameMenuDialogBox = null;
    //Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverUI.SetActive(false);
        LevelCompleteUI.SetActive(false);
        GameQuitDialogBox.SetActive(false);
        GameMenuDialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
        if (GameOver)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
        }
        if (Level_Complete)
        {
            StartCoroutine(waiter());
        }
        if (GameQuitDialog)
        {
            GameQuitDialogBox.SetActive(true);
        }
        if (GameMenuDialog)
        {
            GameMenuDialogBox.SetActive(true);
        }
    }

    /*
    waiter function will make the current screen wait for given second
    before enabling the Level Complete transition UI
    */
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);
        LevelCompleteUI.SetActive(true);
    }

    public void fillbar(float value)
    {
        slider.value = value;
    }
    /*
    resume function will first disable the dialog boxes 
    and then disable the pause menu UI
    */

    public void Resume()
    {
        GameQuitDialog = false;
        GameQuitDialogBox.SetActive(false);
        GameMenuDialog = false;
        GameMenuDialogBox.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }

    /*
    Quit function will be invoked on clicking on Quit button and
    it will open Quit dialog box for confirmation
    */
    public void Quit()
    {
        GameQuitDialog = true;
    }

    /*
    Quit Confirm function will be invoked on dialog box confirmation and 
    it will Quit application
    */
    public void QuitConfirm()
    {
        Application.Quit();
    }
    /*
    Menu function will be invoked on clicking on Menu button and
    it will open Menu dialog box for confirmation
    */
    public void Menu()
    {
        GameMenuDialog = true;
    }
    /*
    Menu Confirm function will be invoked on dialog box confirmation and 
    it will load the Menu screen
    */
    public void MenuConfirm()
    {
        SceneManager.LoadScene(0);
    }

    /*
    restart function will be called on clicking restart button
    it will restart the level
    */
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    /*
    nextLevelScene function will load the next Level Scene after successful 
    completion of current level
    */
    public void nextLevelScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Level_Complete = false;
    }

    /*
    pause function will enable on clicking escape pause Menu UI
    */
    public void Paused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }


}
