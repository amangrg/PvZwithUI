﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePea : Projectile
{
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x == 10f)
        {
            Destroy(gameObject);
        }
    }

}
