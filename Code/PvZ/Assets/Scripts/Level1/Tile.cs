using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    private bool has_plant;

    // modifier kept public on purpose
    public AudioSource audiosrc;
    public AudioClip placed;

    // Start is called before the first frame update
    void Start()
    {
        has_plant = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //plant function will place  plant on that tile if there is no plant on that tile
    public bool plant(GameObject p)

    {   
        if(p == null)
        {
            Debug.Log("Null plant object");
        }
        if (!has_plant)
        {
            Instantiate(p, new Vector3(transform.position.x, transform.position.y + 0.2f, 0), Quaternion.identity);
            has_plant = true;
            audiosrc.PlayOneShot(placed);
            return true;
        }
        return false;
    }
}
