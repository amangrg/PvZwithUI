using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Regular_Zombie;
    public GameObject setWorld;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnZombies", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void spawnSun()
    {
        
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
