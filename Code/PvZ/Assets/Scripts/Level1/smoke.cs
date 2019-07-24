using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//class to Enable smoke animation when zombie dies
public class smoke : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(death());
    }

    IEnumerator death()
    {
        yield return new WaitForSeconds(0.38f);
        Destroy(gameObject);
    }
}
