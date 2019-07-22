using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Sun class gives motion to the natural falling sun and then destroys the sun object if it is not clicked*/
public class Sun : MonoBehaviour
{
    private float fspeed = 1f;
    private float timer = 0f;
    private float lifetime = 11f;
    [SerializeField]
    [HideInInspector]
    private bool sunflowerSun = false;

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

    public void flowerSun(bool value)
    {
        sunflowerSun = value;
    }
}