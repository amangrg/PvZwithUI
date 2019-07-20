using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombie : RegularZombie
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            zombieWalk();
        }
        if (frozen)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1f, 1f);
            speed = 0.1f;
            if (freezeTimer < 5f)
            {
                freezeTimer += Time.deltaTime;
            }
            else
            {
                freezeTimer = 0f;
                frozen = false;
                speed = 0.5f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        if (checkPath())
        {
            walk = false;
        }
        else
            walk = true;
    }
}
