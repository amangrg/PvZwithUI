using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Sun;
    public GameObject Regular_Zombie;
    public GameObject setWorld;
    public GameObject game_manager;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSun", 1f, 8f);
        InvokeRepeating("spawnZombies", 5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (game_manager.GetComponent<GameManager>().Zombie_Count >= 6)
        {
            GameObject zombie = Instantiate(
            Regular_Zombie,
            setWorld.GetComponent<SetWorld>().lanePositions[Random.Range(0, 5)],
            Quaternion.identity,
            transform
            );

            game_manager.GetComponent<GameManager>().Zombie_Count--;

        }
        if (game_manager.GetComponent<GameManager>().Kill_Count == 5)
        {
            game_manager.GetComponent<GameManager>().HugeWave(true);
            spawnHorde();
        }

    }

    private void spawnHorde()
    {

        while (game_manager.GetComponent<GameManager>().Zombie_Count > 0)
        {
            GameObject zombie = Instantiate(
            Regular_Zombie,
            setWorld.GetComponent<SetWorld>().lanePositions[Random.Range(0, 5)],
            Quaternion.identity,
            transform
            );
            game_manager.GetComponent<GameManager>().Zombie_Count--;
        }

    }
}
