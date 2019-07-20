using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredZombie : RegularZombie
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (walk)
        {
            zombieWalk();
        }
        if (checkPath())
        {
            walk = false;
        }
        else
            walk = true;
    }
}
