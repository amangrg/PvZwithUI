using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularZombie : MonoBehaviour
{
    protected float TimeInterval = 1f;
    protected float timer = 0f;
    protected bool walk = true;
    public GameObject Smoke;

    public bool frozen = false;
    private float freezeTimer = 0f;
    protected float speed;
    protected float health;


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
        if (frozen)
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

        if (checkPath())
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

    protected void zombieEat()
    {

    }

    protected void zombieWalk()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < GameObject.Find("SetWorld").GetComponent<SetWorld>().game_over_line)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Game_Over();
        }
    }



    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "peaBullet")
        {
            updateHealth();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "freezeBullet")
        {
            frozen = true;
            updateHealth();
            Destroy(other.gameObject);
        }

        if (health == 0)
        {
            Instantiate(Smoke, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().Kill_Count++;
            GameObject.Find("Canvas").GetComponent<canvas>().progressBar.value = GetProgress();

            if (GameObject.Find("GameManager").GetComponent<GameManager>().Kill_Count == GameObject.Find("GameManager").GetComponent<GameManager>().Initial_Zombie_Count)
                GameObject.Find("GameManager").GetComponent<GameManager>().Level1_Complete();
        }
    }

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

    public float GetProgress()
    {
        float temp = GameObject.Find("GameManager").GetComponent<GameManager>().Kill_Count;
        return (temp / 10);
    }

}
