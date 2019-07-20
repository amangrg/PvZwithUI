using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : Projectile
{
    //    public Projectile proj;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if(transform.position.x == 10f)
        {
            Destroy(gameObject);
        }
    }

}