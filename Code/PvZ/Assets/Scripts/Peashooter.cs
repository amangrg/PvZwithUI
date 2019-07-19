using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : Plant
{
    private float TimeInterval = 2f;
    public GameObject Pea;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= TimeInterval)
        {
            timer = 0f;
            shootPea();
        }
        
    }

    private void shootPea()
    {
        GameObject pea = (GameObject)Instantiate(Pea, new Vector3(transform.position.x + 0.7f, transform.position.y + 0.46f, 0), Quaternion.identity);
    }
}
