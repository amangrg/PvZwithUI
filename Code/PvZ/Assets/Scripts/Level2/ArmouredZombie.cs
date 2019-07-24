using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//armoured zombie extends zombie with more health(more resistance to peashot impacts ) and different animation pattern 
public class ArmouredZombie : RegularZombie
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.18f;
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            zombieWalk();
        }
        if (frozen)                                                                         //Zombie stops walinkg for deltatime if hit by a freezepea
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1f, 1f);
            speed = 0.1f;                                   // Sets less speed for zombie, if it is hit by Frozen Pea
            if (freezeTimer < 5f)
            {
                freezeTimer += Time.deltaTime;
            }
            else
            {
                freezeTimer = 0f;
                frozen = false;
                speed = 0.18f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);           //displays zombie in blue colour to show that it has been frozen
            }
        }

        if (checkPath())                                                                    //stops waling if any plant is in the next tile
        {
            walk = false;
        }
        else
            walk = true;
    }
}
