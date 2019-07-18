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
        InvokeRepeating("spawnSun", 1f, 3f);
        InvokeRepeating("spawnZombies", 15f, 2f);
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

        GameObject zombie = Instantiate(
        Regular_Zombie,
        setWorld.GetComponent<SetWorld>().lanePositions[Random.Range(0, 5)],
        Quaternion.identity,
        transform
        );
    }
}
