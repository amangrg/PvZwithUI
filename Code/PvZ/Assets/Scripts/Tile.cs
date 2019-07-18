using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   
    public bool has_plant;

    // Start is called before the first frame update
    void Start()
    {
        has_plant = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void plant(GameObject p)
    {
        if (!has_plant)
        {
            GameObject plant = (GameObject)Instantiate(p, new Vector3(transform.position.x, transform.position.y + 0.2f, 0), Quaternion.identity);
            has_plant = true;
        }
    }
}
