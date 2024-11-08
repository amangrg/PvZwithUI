﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game manager class is used for updating suncount and incrementing killcount if zombie is killed
//it calls game over and win Ui screens
//it has functions to update and acces kill count zombie count
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas = null;
    [SerializeField]
    private GameObject UI = null;
    [SerializeField]
    private GameObject userEvent = null;
    private int TotalSun = 50;
    [SerializeField]
    private int Zombie_Count = 0;
    [SerializeField]
    private int Initial_Zombie_Count = 0;
    private int Kill_Count = 0;

    //update sends totalsun count to canvas class.
    void Update()
    {
        canvas.GetComponent<canvas>().updateSunCount(TotalSun);
    }

    public void updateSun(int Suncount)
    {
        TotalSun += Suncount;
        canvas.GetComponent<canvas>().updateSunCount(TotalSun);
        for (int i = 0; i < userEvent.GetComponent<UserEvent>().getLength(); ++i)
        {
            canvas.GetComponent<canvas>().checkButtonActive();
        }
    }

    public void Game_Over()
    {
        UI.GetComponent<UI>().Game_Over();
    }

    public void Level_Complete()
    {
        UI.GetComponent<UI>().LevelComplete();
    }

    public void HugeWave()
    {
        canvas.GetComponent<canvas>().Huge_Wave();
    }

    /*Function: killed() increments the Zombie kill count 
       Usage: Called in OnTriggerEnter2D() function of Regular Zombie class
      */
    public void killed()
    {
        Kill_Count++;
        float temp = (float)Kill_Count / Initial_Zombie_Count;
        UI.GetComponent<UI>().fillbar(temp);
    }

    public int getInitialCount()
    {
        return Initial_Zombie_Count;
    }

    public int getKillCount()
    {
        return Kill_Count;
    }
    public int getZombieCount()
    {
        return Zombie_Count;
    }

    /*Function: updateZombieCount() decrements the total Zombie count on spawning a zombie
       Usage: Called in Spawner class
      */
    public void updateZombieCount()
    {
        Zombie_Count--;
    }
}