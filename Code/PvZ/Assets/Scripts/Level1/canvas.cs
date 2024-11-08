﻿using System.Collections;
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
    private Text SuncountT;

    [SerializeField]
    private GameObject userEvent;

    [SerializeField]
    private int[] plantCosts;

    [HideInInspector]
    private bool HugeWave = false;

    [SerializeField]
    private GameObject HugeWaveUI;

    [SerializeField]
    private bool[] checkButtonCoolTime;

    [SerializeField]
    private float[] timeToWait;

    [SerializeField]
    private float[] currentWaitTime;

    [SerializeField]
    private Sprite[] panelChargeButtonImage;

    [SerializeField]
    private Sprite[] panelImage;
    private int currentLevel = 0;



    void Awake()
    {
        Time.timeScale = 1f;
    }

    /*
    Start function will be called before the first frame update
    Set the current level index in PlayerPrefs
    At start updateSunCount will be set to 0 and ButtonCoolTime of each button will be set to false,i.e plants are available to be placed 
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
    }

    /*
    
     */

    /*
    checkCooldownTimer function will check if the checkButtonCoolTime of any button is true
    then increment the currentWaitTime of that button till timeToWait of that button and 
    when it is equal then make that button interactive by checking if the suncount is available
    If the checkButtonCoolTime is false for a button then check if Button is active
    */
    private void checkCooldownTimer()
    {
        for (int i = 0; i < checkButtonCoolTime.Length; ++i)
        {
            if (checkButtonCoolTime[i])
            {
                if ((float)Math.Ceiling(currentWaitTime[i]) != timeToWait[i])
                {
                    currentWaitTime[i] += Time.deltaTime;
                    userEvent.GetComponent<UserEvent>().setButton(i,false);
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
                    userEvent.GetComponent<UserEvent>().setButton(i,true);
                }
                else
                {
                    userEvent.GetComponent<UserEvent>().setButton(i,false);
                }
                checkButtonCoolTime[i] = false;
                Button btn = userEvent.GetComponent<UserEvent>().getButton(i);
                Sprite img = panelImage[i];
                btn.GetComponent<Image>().sprite = img;
            }
            else
            {
                userEvent.GetComponent<UserEvent>().setButton(i,false);
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


    public void Huge_Wave()
    {
        HugeWaveUI.SetActive(true);
        StartCoroutine(waiter());   
    }

    public void setCoolTime(int id)
    {
        checkButtonCoolTime[id] = true;
    }

    public int getPlantCost(int id)
    {
        return plantCosts[id];
    }

    public Sprite getPanelChargeButtonImage(int id)
    {
        return panelChargeButtonImage[id];
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        HugeWaveUI.SetActive(false);
    }
}
