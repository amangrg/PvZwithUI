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
    public bool HugeWave = false;
    public GameObject HugeWaveUI = null;
    public bool[] checkButtonCoolTime;
    public float[] timeToWait;
    public float[] currentWaitTime;
    public Sprite[] panelChargeButtonImage;
    public Sprite[] panelImage;
    private float WaveTimer = 0f;
    private int currentLevel;



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
    
     */

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
    updateSunCount function takes SunCost as argument
    It displays the sunCost on panel
    */

    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
