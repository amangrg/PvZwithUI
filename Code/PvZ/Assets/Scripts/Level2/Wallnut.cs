using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallnut : Plant
{
    // Start is called before the first frame update
    public Sprite halfWallnut;
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = halfWallnut;
        }
    }
}
