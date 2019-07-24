using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    //private bool GameOver = false;
    //private bool Level_Complete = false;
    //private bool GameQuitDialog = false;
    //private bool GameMenuDialog = false;
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject PauseMenu = null;
    [SerializeField]
    private GameObject GameOverUI = null;
    [SerializeField]
    private GameObject LevelCompleteUI = null;
    [SerializeField]
    private GameObject GameQuitDialogBox = null;
    [SerializeField]
    private GameObject GameMenuDialogBox = null;
    [SerializeField]
    private Button quit = null;
    [SerializeField]
    private Button quitConfirm = null;
    [SerializeField]
    private Button menu = null;
    [SerializeField]
    private Button menuConfirm = null;
    [SerializeField]
    private Button nextLevel = null;
    [SerializeField]
    private Button resume = null;
    [SerializeField]
    private Button restart = null;
    [SerializeField]
    private Button gameOverRestart = null;
    [SerializeField]
    private Button gameOverQuit = null;
    [SerializeField]
    private Button gameOverMenu = null;
    [SerializeField]
    private Button gameWonQuit = null;
    [SerializeField]
    private Button gameQuitDialogBoxNo = null;
    [SerializeField]
    private Button gameMenuDialogBoxNo = null;

    private static bool GamePaused = false;
    //Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverUI.SetActive(false);
        LevelCompleteUI.SetActive(false);
        GameQuitDialogBox.SetActive(false);
        GameMenuDialogBox.SetActive(false);
        quit.onClick.AddListener(delegate { Quit(); });
        quitConfirm.onClick.AddListener(delegate { QuitConfirm(); });
        menu.onClick.AddListener(delegate { Menu(); });
        menuConfirm.onClick.AddListener(delegate { MenuConfirm(); });
        nextLevel.onClick.AddListener(delegate { nextLevelScene(); });
        resume.onClick.AddListener(delegate { Resume(); });
        restart.onClick.AddListener(delegate { Restart(); });
        gameOverRestart.onClick.AddListener(delegate { Restart(); });
        gameOverQuit.onClick.AddListener(delegate { Quit(); });
        gameOverMenu.onClick.AddListener(delegate { Menu(); });
        gameWonQuit.onClick.AddListener(delegate { Quit(); });
        gameQuitDialogBoxNo.onClick.AddListener(delegate { Resume(); });
        gameMenuDialogBoxNo.onClick.AddListener(delegate { Resume(); });
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

    public void fillbar(float val)
    {
        slider.value = val;
       
    }
    /*
    resume function will first disable the dialog boxes 
    and then disable the pause menu UI
    */

    private void Resume()
    {
        GameQuitDialogBox.SetActive(false);    
        GameMenuDialogBox.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }

    /*
    Quit function will be invoked on clicking on Quit button and
    it will open Quit dialog box for confirmation
    */
    private void Quit()
    {
        GameQuitDialogBox.SetActive(true);
    }

    /*
    Quit Confirm function will be invoked on dialog box confirmation and 
    it will Quit application
    */
    private void QuitConfirm()
    {
        Application.Quit();
    }
    /*
    Menu function will be invoked on clicking on Menu button and
    it will open Menu dialog box for confirmation
    */
    private void Menu()
    {
        GameMenuDialogBox.SetActive(true);
    }
    /*
    Menu Confirm function will be invoked on dialog box confirmation and 
    it will load the Menu screen
    */
    private void MenuConfirm()
    {
        SceneManager.LoadScene(0);
    }

    /*
    restart function will be called on clicking restart button
    it will restart the level
    */
    private void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    /*
    nextLevelScene function will load the next Level Scene after successful 
    completion of current level
    */
    private void nextLevelScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        LevelCompleteUI.SetActive(false);
    }

    /*
    pause function will enable on clicking escape pause Menu UI
    */
    private void Paused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    /*
    Game_Over() function set the Game over UI screen 
    */
    public void Game_Over()
    {
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }

    /*
    LevelComplete function set the Level complete UI screen 
    through waiter function
    */
    public void LevelComplete()
    {
        StartCoroutine(waiter());
    }

}
