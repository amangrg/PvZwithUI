using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas = null;
    [SerializeField]
    private GameObject UI = null;
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
        for (int i = 0; i < userEvent.GetComponent<UserEvent>().button.Length; ++i)
        {
            canvas.GetComponent<canvas>().checkButtonActive();
        }
    }

    public void Game_Over()
    {
        //     UI.GetComponent<UI>().GameOver = true;

        Debug.Log("Game over!");
    }

    public void Level_Complete()
    {
        Debug.Log("Won");
        //  UI.GetComponent<UI>().Level_Complete = true;

    }

    public void HugeWave(bool wave)
    {
        Debug.Log(wave);
      //  canvas.GetComponent<canvas>().HugeWave = wave;
    }


    /*Function: killed() increments the Zombie kill count 
       Usage: Called in OnTriggerEnter2D() function of Regular Zombie class
      */
    public void killed()
    {
        Kill_Count++;
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