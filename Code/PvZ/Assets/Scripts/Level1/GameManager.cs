using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject canvas = null;
    [SerializeField]
    public GameObject UI = null;
    [SerializeField]
    private GameObject userEvent = null;
    private int TotalSun = 500;
    private int Zombie_Count = 10;
    private int Initial_Zombie_Count = 10;
    //[HideInInspector]
    private int Kill_Count = 0;

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
        UI.GetComponent<UI>().Game_Over(true);
    }

    public void Level_Complete()
    {
        UI.GetComponent<UI>().LevelComplete(true);
    }

    public void HugeWave(bool wave)
    {
        canvas.GetComponent<canvas>().Huge_Wave(wave);
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