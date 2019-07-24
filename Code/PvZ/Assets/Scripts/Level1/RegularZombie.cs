using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 Regular zombie class defines behavior and special effects of Zombie , Regularzombie is  a parent class of other types of zombies. 
    it handles walking , collision impacts  and path checking
*/

public class RegularZombie : MonoBehaviour
{
    protected float TimeInterval = 1f;
    protected float timer = 0f;
    protected bool walk = true;
    [SerializeField]
    protected GameObject Smoke;
    protected bool frozen = false;
    protected float freezeTimer = 0f;
    protected float speed = 0f;
    protected int health = 0;

    //audioclips need  access from Audiolistener hence kept public 
    public AudioSource audiosource;
    public AudioClip collidesound;
    public AudioClip deathsound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            zombieWalk();
        }
        if (frozen)                                                                                 //freezes for freezetimer  if frozen pea has collided to zombie 
        {
            GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 1f, 1f);
            speed = 0.1f;                        // Sets less speed for zombie, if it is hit by Frozen Pea
            if (freezeTimer < 5f)
            {
                freezeTimer += Time.deltaTime;
            }
            else
            {
                freezeTimer = 0f;
                frozen = false;
                speed = 0.3f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            }
        }

        if (checkPath())                                                                            //stops waliking if plant is in the next tile 
        {
            walk = false;
        }
        else
            walk = true;
    }

    /*
       Function: updateHealth() function decrements health of Zombie.
       Parameters: It takes no parameters.
       Usage: Called on collision with Pea.
   */
    protected void updateHealth()
    {
        health--;
    }

    /*
       Function: zombieWalk() gives translation speed to Zombies. It also checks if zombie has crossed the game over line and calls Game Over Function.
       Parameters: It takes no parameters.
       Usage: Called on collision with Pea in OnTriggerEnter2D() of Zombie.
   */

    protected void zombieWalk()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < GameObject.Find("SetWorld").GetComponent<SetWorld>().getGameOver())
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Game_Over();
        }
    }
    /*
       Function: OnTriggerEnter2D() detects type of Pea, updates Health of Zombie according to pea type,and destroys Zombie
       Parameters: Takes inbuilt Collider object
       Usage: It is MonoBehaviour function called directly by Unity on collisions.
   */
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "peaBullet")
        {
            updateHealth();
            Destroy(other.gameObject);
            audiosource.PlayOneShot(collidesound);
        }

        if (other.gameObject.tag == "freezeBullet")
        {
            frozen = true;
            updateHealth();
            Destroy(other.gameObject);
            audiosource.PlayOneShot(collidesound);
        }

        if (health == 2)
        {
            audiosource.PlayOneShot(deathsound);
        }
        if (health == 0)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);

            GameObject.Find("GameManager").GetComponent<GameManager>().killed();
            if (GameObject.Find("GameManager").GetComponent<GameManager>().getKillCount() == GameObject.Find("GameManager").GetComponent<GameManager>().getInitialCount())
                GameObject.Find("GameManager").GetComponent<GameManager>().Level_Complete();

            Destroy(gameObject);
        }
    }

    /*
      Function: checkPath()- Checks if Zombie & plant are in vicinty, and decrements plant health 
      Usage: Called in Update() of Zombies
    */
    protected bool checkPath()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 0.5f, 1 << 9);
        if (hit)
        {
            timer += Time.deltaTime;
            if (timer >= TimeInterval)
            {
                timer = 0f;
                hit.transform.gameObject.GetComponent<Plant>().updateHealth();
            }
            return hit;

        }
        else
            return false;

    }

}
