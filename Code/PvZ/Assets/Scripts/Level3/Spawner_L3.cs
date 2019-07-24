using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner_L3 : MonoBehaviour
{

    public GameObject Sun;
    public GameObject[] Zombies;
    public GameObject setWorld;
    public GameObject gameManager;
    public int levelzombies;
    //public int hordeZombies;  //later if we want to spawn multiple hordes of zombies(not 1).

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSun", 1f, 8f);
        InvokeRepeating("spawnZombies", 5f, 5f);
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
        //Debug.Log(gameManager.GetComponent<GameManager>().Zombie_Count);
        if (gameManager.GetComponent<GameManager>().getZombieCount() > levelzombies)
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
        if (gameManager.GetComponent<GameManager>().getKillCount() == levelzombies)
        {
            gameManager.GetComponent<GameManager>().HugeWave();
            if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                spawnBoss();
                gameManager.GetComponent<GameManager>().updateZombieCount();
            }
            spawnHorde();

        }

    }

    private void spawnHorde()
    {
        while (gameManager.GetComponent<GameManager>().getZombieCount() > 0)
        {
            //Debug.Log("No of Zombies Spawned");
            int spawn = Random.Range(0, (Zombies.Length - 1));
            GameObject zombie = Instantiate(
           Zombies[spawn],
            setWorld.GetComponent<SetWorld>().getLane(),
            Quaternion.identity,
            transform
            );
            //Debug.Log(gameManager.GetComponent<GameManager>().Zombie_Count);
            gameManager.GetComponent<GameManager>().updateZombieCount();

        }

    }

    private void spawnBoss()
    {
        GameObject zombie = Instantiate(
       Zombies[2],
        setWorld.GetComponent<SetWorld>().getLane(),
        Quaternion.identity,
        transform
        );
    }
}
