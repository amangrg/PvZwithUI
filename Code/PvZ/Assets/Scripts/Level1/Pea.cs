using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class assigns peas its  speed and makes it move (transform) 
 pea destorys itself if it reaches backyard boundry */
public class Pea : Projectile
{

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);              //defines how pea will move when generated
        if(transform.position.x == 10f)
        {
            Destroy(gameObject);
        }
    }

}