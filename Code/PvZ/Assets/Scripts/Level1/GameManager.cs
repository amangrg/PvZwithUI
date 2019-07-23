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
        for (int i = 0; i < userEvent.GetComponent<UserEvent>().button.Length; ++i)
        {
            canvas.GetComponent<canvas>().checkButtonActive();
        }
    }

    public void Game_Over()
    {
        UI.GetComponent<UI>().GameOver = true;
    }

    public void Level_Complete()
    {
        UI.GetComponent<UI>().Level_Complete = true;
    }

    public void HugeWave(bool wave)
    {
        Debug.Log("wave");
        canvas.GetComponent<canvas>().HugeWave = wave;
    }

    public void killed()
    {
        Kill_Count++;
        UI.GetComponent<UI>().fillbar((float)Kill_Count/Initial_Zombie_Count);
    }

    public int getInitialCount()
    {
        return Initial_Zombie_Count;
    }
    
    public int getKillCount()
    {
        Debug.Log(Kill_Count);
        return Kill_Count;
    }
    public int getZombieCount()
    {
        return Zombie_Count;
    }
    public void updateZombieCount()
    {
        Zombie_Count--;
    }
}