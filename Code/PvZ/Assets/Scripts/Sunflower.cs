using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : Plant
{
    private float TimeInterval = 4f;
    public GameObject Sun;
    private float timer;

    void Start()
    {
        health = 3;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimeInterval)
        {
            timer = 0f;
            spawnSunfSun();
        }
    }

    private void spawnSunfSun()
    {
        GameObject sun = Instantiate(
        Sun,
        new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f,0.5f)),
        Quaternion.identity,
        transform
        );
        sun.transform.localScale = new Vector3(0.75f, 0.75f, 1f);
        sun.GetComponent<Sun>().sunflowerSun = true;
    }
}
