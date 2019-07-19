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
    //public static bool GamePaused = false;
    //public GameObject PauseMenu;
    public GameObject GameOverUI;
    //public GameObject GameWonUI;
    //public GameObject HugeWaveUI;
    public bool[] checkButtonCoolTime = new bool[2];
    public float[] timeToWait = new float[2] { 7.0f, 7.0f };
    private float[] currentWaitTime = new float[2];
    public Sprite[] panelChargeButtonImage = new Sprite[2];
    public Sprite[] panelImage = new Sprite[2];
    //public GameObject GameOverUI;
    //public GameObject GameWonUI;
    // Start is called before the first frame update

    //at start updateSunCount should be 0 and ButtonCoolTime of each button must be false

    void Awake()
    {
        Time.timeScale = 1f;
    }


    void Start()
    {
        //PauseMenu.SetActive(false);
        GameOverUI.SetActive(false);
        //GameWonUI.SetActive(false);

        updateSunCount(0);
        for (int i = 0; i < 2; i++)
        {
            checkButtonCoolTime[i] = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        checkCooldownTimer(); //checkCoolDownTimer for each button in panel at every frame

        if (GameOver)
        {
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
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
            if ((!checkButtonCoolTime[i]) && (plantCosts[i] <= System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text)))
            {
                //Debug.Log("but");
                userEvent.GetComponent<UserEvent>().button[i].interactable = true;
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

    public void Quit()
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
    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
