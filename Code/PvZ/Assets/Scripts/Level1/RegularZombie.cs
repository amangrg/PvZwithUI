using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Regular zombie class defines behavior and special effects of Zombie , Regularzombie is  a parent class of other types of zombies. 
//it handles walking , collision impacts  and path checking
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
            GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,1f,1f);
            speed = 0.1f;
            if (freezeTimer < 5f)
            {
                freezeTimer += Time.deltaTime;
            }
            else
            {
                freezeTimer = 0f;
                frozen = false;
                speed = 0.5f;
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

 
    protected void updateHealth()
    {
        health--;
    }
    //makes zombie walk with  constant speed unless game over condition occurs
    protected void zombieWalk()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < GameObject.Find("SetWorld").GetComponent<SetWorld>().getGameOver())
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Game_Over();
        }
    }
    // OnTriggerEnter2D is handelling collisions between pea projectiles and zombie, reduces health on every impact (by  pea collision)
    // It initiates smoke animations, and moaning sound effects  when last pea is about to hit 
    // it informs gamemanager class  if it has been 'killed'
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

    //checks and returns hit if a plant is in next as the zombie
    protected bool checkPath()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 0.5f, 1 << 9);
        if (hit)
        {
            //Debug.Log("In checkpath");
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
