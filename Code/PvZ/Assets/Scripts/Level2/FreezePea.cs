using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 freeze pea extends properites of projectile, 
 freezepea's speed is assigned in this function
 pea is also destroyed if it goes beyonf the booundry
 */

public class FreezePea : Projectile
{
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
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
