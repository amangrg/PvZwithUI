using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//walnut acts as a buffer between zombie and backyard without any mechanism to shot pea , it inherits plant class
// walnut only protects house by  taking more  time to be eate,n  it has more  health than normal plant
//wallnut class adds condition for animation when it is being eaten
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
