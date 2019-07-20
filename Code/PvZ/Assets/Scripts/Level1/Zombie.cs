using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zombie : MonoBehaviour
{

    protected float speed;
    protected int health;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected abstract void zombieEat();

    protected abstract void zombieWalk();


    private void checkPath()
    {

    }



}
