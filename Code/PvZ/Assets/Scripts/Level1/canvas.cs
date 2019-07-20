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
    public bool Level1_Complete = false;
    public static bool GamePaused = false;
    public bool GameQuitDialog = false;
    public bool HugeWave = false;
    public GameObject PauseMenu;
    public GameObject GameOverUI;
    public GameObject Level1CompleteUI;
    public GameObject GameQuitDiaglogBox;
    public GameObject HugeWaveUI;
    //public GameObject HugeWaveUI;
    public bool[] checkButtonCoolTime;
    public float[] timeToWait;
    public float[] currentWaitTime;
    public Sprite[] panelChargeButtonImage;
    public Sprite[] panelImage;
    private float WaveTimer = 0f;

    public int CurrentLevel = 1;
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
        PlayerPrefs.SetInt("Current Level", 2);
        PlayerPrefs.Save();
        CurrentLevel = PlayerPrefs.GetInt("Current Level", 0);
        Debug.Log(CurrentLevel);
        PauseMenu.SetActive(false);
        GameOverUI.SetActive(false);
        Level1CompleteUI.SetActive(false);
        GameQuitDiaglogBox.SetActive(false);
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

        if (Level1_Complete)
        {
            //Time.timeScale = 0f;
            Level1CompleteUI.SetActive(true);
        }
        if (GameQuitDialog)
        {
            GameQuitDiaglogBox.SetActive(true);
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
        GameQuitDiaglogBox.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

    }

    public void Quit()
    {
        GameQuitDialog = true;
    }

    public void QuitConfirm()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void level2Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
