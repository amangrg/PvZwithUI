using System.Collections;
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

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnSun", 1f, 6f);
        InvokeRepeating("spawnZombies", 10f, 12f);
    }
   
    private void spawnSun()                                                      //generates sun at some interval but at random positions on backyard         
    {
        float x = Random.Range(-6f, 4f);
        GameObject sun = Instantiate(
        Sun,
        new Vector2(x, 5f),
        Quaternion.identity,
        transform
        );
        if (!sun)
        {
            Debug.Log("Sun Instantiate failed");
        }
    }

    private void spawnZombies()                                                     //generates pattern in which zombies attack the backyard, in different rows in different amount and time                                                       
    {

        if (gameManager.GetComponent<GameManager>().getZombieCount() > hordezombies)
     
        {
            int spawn = Random.Range(0, (Zombies.Length));
            GameObject zombie = Instantiate(
            Zombies[spawn],
            setWorld.GetComponent<SetWorld>().getLane(),
            Quaternion.identity,
            transform
            );
            if (!Zombies[spawn])
            {
                Debug.Log("Tile Instantiate failed");
            }
            else
                gameManager.GetComponent<GameManager>().updateZombieCount();

        }
        if (gameManager.GetComponent<GameManager>().getKillCount() == levelzombies && gameManager.GetComponent<GameManager>().getZombieCount() > 0)
        {
            gameManager.GetComponent<GameManager>().HugeWave();
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
            if (!Zombies[spawn])
            {
                Debug.Log("Tile Instantiate failed");
            }
            else
                gameManager.GetComponent<GameManager>().updateZombieCount();
            
        }

    }
}
