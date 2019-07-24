using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//freezeplant class extends properties of the plant to instantiate freeze pea instead of normal pea when attacking

public class FreezePlant : Plant
{
    private float TimeInterval = 2f;
    [SerializeField]
    private GameObject FreezePea;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    //after a time interval from planting i.e "TimeInterval" freezeplant will initiate  shooting pea  if zombie is in its path
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= TimeInterval && checkPath())
        {
            timer = 0f;
            shootPea();
        }

    }
    //shootpea generates projectile FreezPea from freezeplant's position
    private void shootPea()
    {
        if (FreezePea)
            Instantiate(FreezePea, new Vector3(transform.position.x + 0.7f, transform.position.y + 0.46f, 0), Quaternion.identity);
        else
            Debug.Log("Error in Freeze Pea");
    }
    //checkpath function checks if zombie is there in straight line from the plant using Raycast function provided by unity
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
