using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject userEvent;
    private int TotalSun = 0;
    public int Zombie_Count = 10;
    public int Initial_Zombie_Count = 10;
    public int Kill_Count = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        canvas.GetComponent<canvas>().updateSunCount(TotalSun);
    }

    public void updateSun(int Suncount)
    {
        TotalSun += Suncount;
        for (int i = 0; i < userEvent.GetComponent<UserEvent>().button.Length; i++)
        {
            canvas.GetComponent<canvas>().checkButtonActive();
        }
    }

    public void Game_Over()
    {
        canvas.GetComponent<canvas>().GameOver = true;
    }

    public void Level1_Complete()
    {
        //Debug.Log("Won");
        canvas.GetComponent<canvas>().Level1_Complete = true;
    }


}