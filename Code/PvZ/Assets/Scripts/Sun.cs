using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float fspeed = 1f;
    private float timer;
    private float lifetime = 11f;
    [HideInInspector]
    public bool sunflowerSun = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!sunflowerSun)
        {
            transform.Translate(Vector2.down * fspeed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
