using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/*
Canvas class displays the panel and its elements, transition UIs, dialog boxes
*/
public class canvas : MonoBehaviour
{
    [SerializeField]
    public Text SuncountT;
    public GameObject userEvent;
    public int[] plantCosts;

    [HideInInspector]
    public bool GameOver = false;
    public bool Level_Complete = false;
    public static bool GamePaused = false;
    public bool GameQuitDialog = false;
    public bool GameMenuDialog = false;
    public bool HugeWave = false;
    public GameObject PauseMenu = null;
    public GameObject GameOverUI = null;
    public GameObject LevelCompleteUI = null;
    public GameObject GameQuitDialogBox = null;
    public GameObject GameMenuDialogBox = null;
    public GameObject HugeWaveUI = null;
    public bool[] checkButtonCoolTime;
    public float[] timeToWait;
    public float[] currentWaitTime;
    public Sprite[] panelChargeButtonImage;
    public Sprite[] panelImage;
    private float WaveTimer = 0f;
    private int currentLevel;
    public Slider progressBar;


    void Awake()
    {
        Time.timeScale = 1f;
    }

    /*
    Start function will be called before the first frame update
    Set the current level index in PlayerPrefs
    At start updateSunCount will be set to 0 and ButtonCoolTime of each button will be set to false,
    All the Dialog boxes and transition UI's are disabled
    */
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Current Level", currentLevel);
        PlayerPrefs.Save();
        PauseMenu.SetActive(false);
        GameOverUI.SetActive(false);
        LevelCompleteUI.SetActive(false);
        GameQuitDialogBox.SetActive(false);
        GameMenuDialogBox.SetActive(false);
        updateSunCount(0);
        for (int i = 0; i < plantCosts.Length; ++i)
        {
            checkButtonCoolTime[i] = false;
        }
    }


    /* 
    Update is called once per frame
    Update function calls checkCoolDownTimer function to check cool down time for each seed button in panel
    Update function checks for Escape key press and the boolian variables to enable different transition UI's
    */
    void Update()
    {
        checkCooldownTimer(); //checkCoolDownTimer for each button in panel at every frame
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
        if (HugeWave)
        {
            HugeWaveUI.SetActive(HugeWave);
            if (WaveTimer < 2f)
            {
                WaveTimer += Time.deltaTime;
            }
            else
            {
                HugeWave = false;
                HugeWaveUI.SetActive(HugeWave);
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

    /*
    checkCooldownTimer function will check if the checkButtonCoolTime of any button is true
    then increment the currentWaitTime of that button till timeToWait of that button and 
    when it is equal then make that button interactive by checking if the suncount is available
    If the checkButtonCoolTime is false for a button then check if Button is active
    */
    public void checkCooldownTimer()
    {
        for (int i = 0; i < checkButtonCoolTime.Length; ++i)
        {
            if (checkButtonCoolTime[i])
            {
                if ((float)Math.Ceiling(currentWaitTime[i]) != timeToWait[i])
                {
                    currentWaitTime[i] += Time.deltaTime;
                    userEvent.GetComponent<UserEvent>().button[i].interactable = false;
                }
                else
                {
                    checkButtonActive();
                    checkButtonCoolTime[i] = false;
                    currentWaitTime[i] = 0.0f;
                }
            }
            else
            {
                checkButtonActive();
            }
        }
    }

    /*
    If the checkButtonCoolTime is false and the suncost is enough for that seed button then 
    set it to interactive and change the button image to available 
    Else, set button uninteractive   
    */
    public void checkButtonActive()
    {
        for (int i = 0; i < plantCosts.Length; ++i)
        {
            if ((!checkButtonCoolTime[i]))
            {
                if ((plantCosts[i] <= System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text)))
                {
                    userEvent.GetComponent<UserEvent>().button[i].interactable = true;
                }
                else
                {
                    userEvent.GetComponent<UserEvent>().button[i].interactable = false;
                }
                checkButtonCoolTime[i] = false;
                Button btn = userEvent.GetComponent<UserEvent>().button[i];
                Sprite img = panelImage[i];
                btn.GetComponent<Image>().sprite = img;
            }
            else
            {
                userEvent.GetComponent<UserEvent>().button[i].interactable = false;
            }
        }
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
    updateSunCount function takes SunCost as argument
    It displays the sunCost on panel
    */
    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
