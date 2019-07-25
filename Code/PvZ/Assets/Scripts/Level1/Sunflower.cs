using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This class gives health to a sunflower that is created, and spawns sun on the sunflower */


public class Sunflower : Plant
{
    private float TimeInterval = 20f;
    [SerializeField]
    private GameObject Sun = null;
    private float timer = 0f;

    void Start()
    {
        health = 6;                         //assigns initial health to the sunflower
    }

    //calls spawnsunfsun on sunflower at regular interval set by timer.
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimeInterval)
        {
            timer = 0f;
            spawnSunfSun();                    
        }
    }

    /*
        Function: spawnSunfSun() function creates a sun object for every sunflower after certain time interval, and destroys after a while if not clicked
        Usage: called in Update() function
    */


    private void spawnSunfSun()
    {
        GameObject sun = Instantiate(
        Sun,
        new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f,0.5f)),
        Quaternion.identity,
        transform
        );


        if (sun != null)
        {
            sun.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
            sun.GetComponent<Sun>().flowerSun(true);
        }
        else
            Debug.Log("Sun object is null");
    }
}
