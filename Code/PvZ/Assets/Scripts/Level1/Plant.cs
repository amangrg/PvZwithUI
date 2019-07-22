using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Plant class is a base class for all types of plant that can be created*/

public class Plant : MonoBehaviour
{
    protected int health=0;
    protected int cost=0;
    [SerializeField]
    private GameObject Smoke = null;

    //plant eat music kept public access modifier for inspector mapping.
    public AudioSource audiosource;
    public AudioClip eatsound;
    
    /*
        Function: updateHealth() function decreases health of a plant, when a zombie eats that plant, and lastly destroys plant
        parameters: No parameters are taken
        Usage: The function is called in checkPath() function of RegularZombie class
    */

    public void updateHealth()
    {
        health--;
        audiosource.PlayOneShot(eatsound);
        if(health == 0)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
