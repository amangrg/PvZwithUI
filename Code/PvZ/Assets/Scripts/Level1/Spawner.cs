﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Sun = null;
    [SerializeField]
    private GameObject[] Zombies = null;
    [SerializeField]
    private GameObject setWorld = null;
    [SerializeField]
    private GameObject gameManager = null;
    [SerializeField]
    private int levelzombies;
    [SerializeField]
    private int hordezombies;

    //public int hordeZombies;  //later if we want to spawn multiple hordes of zombies(not 1).

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSun", 1f, 8f);
        InvokeRepeating("spawnZombies", 5f, 5f);
    }
   
    private void spawnSun()
    {
        float x = Random.Range(-6f, 4f);
        GameObject sun = Instantiate(
        Sun,
        new Vector2(x, 5f),
        Quaternion.identity,
        transform
        );
    }

    private void spawnZombies()
    {
        if (gameManager.GetComponent<GameManager>().getZombieCount() > hordezombies)
        {
            Debug.Log(gameManager.GetComponent<GameManager>().getZombieCount());

            int spawn = Random.Range(0, (Zombies.Length));
            GameObject zombie = Instantiate(
            Zombies[spawn],
            setWorld.GetComponent<SetWorld>().getLane(),
            Quaternion.identity,
            transform
            );

            gameManager.GetComponent<GameManager>().updateZombieCount();

        }
        if (gameManager.GetComponent<GameManager>().getKillCount() == levelzombies)
        {
            Debug.Log("level zombies");
            gameManager.GetComponent<GameManager>().HugeWave(true);
            spawnHorde();
        }
    }

    private void spawnHorde()
    {
        while (gameManager.GetComponent<GameManager>().getZombieCount() > 0)
        {
            
            int spawn = Random.Range(0, (Zombies.Length - 1));
            GameObject zombie = Instantiate(
            Zombies[spawn],
            setWorld.GetComponent<SetWorld>().getLane(),
            Quaternion.identity,
            transform
            );
          
            gameManager.GetComponent<GameManager>().updateZombieCount();
            
        }

    }
}
