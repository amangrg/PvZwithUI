using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class canvas : MonoBehaviour
{
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
    public GameObject PauseMenu;
    public GameObject GameOverUI;
    public GameObject LevelCompleteUI;
    public GameObject GameQuitDialogBox;
    public GameObject GameMenuDialogBox;
    public GameObject HugeWaveUI;
    //public GameObject HugeWaveUI;
    public bool[] checkButtonCoolTime;
    public float[] timeToWait;
    public float[] currentWaitTime;
    public Sprite[] panelChargeButtonImage;
    public Sprite[] panelImage;
    private float WaveTimer = 0f;
    private int currentLevel;

    //public GameObject GameOverUI;
    //public GameObject GameWonUI;


    public Slider progressBar;


    // Start is called before the first frame update

    //at start updateSunCount should be 0 and ButtonCoolTime of each button must be false

    void Awake()
    {
        Time.timeScale = 1f;
    }


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
        for (int i = 0; i < plantCosts.Length; i++)
        {
            checkButtonCoolTime[i] = false;
        }
    }


    // Update is called once per frame
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
            //Time.timeScale = 0f;
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

    IEnumerator waiter()
    {
        Debug.Log("wait for sec");
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
        for (int i = 0; i < checkButtonCoolTime.Length; i++)
        {
            if (checkButtonCoolTime[i])
            {
                if ((float)Math.Ceiling(currentWaitTime[i]) != timeToWait[i])
                {
                    currentWaitTime[i] += Time.deltaTime;
                    //currentWaitTime[i] = (float)Math.Ceiling(currentWaitTime[i]);
                    //Debug.Log(currentWaitTime[i]);
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
                //Debug.Log(1);
                checkButtonActive();
            }
        }
    }

    /*
    If the checkButtonCoolTime is false and the suncost is enough for that seed button then 
    set it interactive and change the button image to available 
    Else, set button uninteractive
    */
    public void checkButtonActive()
    {
        for (int i = 0; i < plantCosts.Length; i++)
        {
            //Debug.Log(plantCosts[i]);
            //Debug.Log(System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text));
            //Debug.Log(plantCosts[i] <= System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text));
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
                //Debug.Log("but");
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

    public void Paused()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

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
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    /*
    level2Scene function will load the Level 2 Scene after successful 
    completion of level 1
    */
    public void level2Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    /*
    level3Scene function will load the Level 3 Scene after successful
    completion of level 2
    */
    public void level3Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
