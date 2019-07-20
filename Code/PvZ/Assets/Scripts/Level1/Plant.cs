using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    protected int health;
    protected int cost;
    public GameObject Smoke;
    
    public void updateHealth()
    {
        health--;
        if(health == 0)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
