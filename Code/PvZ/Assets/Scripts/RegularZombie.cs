﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularZombie : Zombie
{

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {      
            zombieWalk();
    }

    private void updateHealth()
    {
       
    }

    protected override void zombieEat()
    {

    }

    protected override void zombieWalk()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < GameObject.Find("SetWorld").GetComponent<SetWorld>().game_over_line)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Game_Over();
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
