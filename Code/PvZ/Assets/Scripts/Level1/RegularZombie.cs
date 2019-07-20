using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularZombie : Zombie
{
    private float TimeInterval = 1f;
    private float timer = 0f;
    private bool walk = true;
    public GameObject Smoke;

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
        if (checkPath())
        {
            walk = false;
        }
        else
            walk = true;
    }

    private void updateHealth()
    {
        health--;
    }

    protected override void zombieEat()
    {

    }

    protected override void zombieWalk()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x < GameObject.Find("SetWorld").GetComponent<SetWorld>().game_over_line)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Game_Over();
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "peaBullet")
        {
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

    private bool checkPath()
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
