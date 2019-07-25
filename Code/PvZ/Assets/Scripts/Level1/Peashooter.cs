using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* The Peashooter class inherits Plant class and performs pea shooting task when it encounters zombie in its path
*/

public class Peashooter : Plant
{
    private float TimeInterval = 2f;
    [SerializeField]
    private GameObject Pea = null;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;    //initial health of peashooter
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimeInterval && checkPath())
        {
            timer = 0f;
            shootPea();
        }
    }

    /*
        Function: shootPea() function creates new peas from the peashooter
        Usage: called in Update() function 
    */

    private void shootPea()
    {
        Instantiate(Pea, new Vector3(transform.position.x + 0.7f, transform.position.y + 0.46f, 0), Quaternion.identity);
        if(!Pea)
        {
            Debug.Log("Pea instantiate failed");
        }
    }


    /*
        Function: checkPath() lets peashooter check whether there exists zombie in its path (row) and returns true or false accordingly.
        Usage: called in Update() function
    */
    private bool checkPath()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, 7f - transform.position.x, 1 << 8);
        if (hit)
        {
            return hit;
        }
        else
            return false;
    }
}