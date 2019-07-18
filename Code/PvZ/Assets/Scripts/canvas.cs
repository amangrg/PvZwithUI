using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour
{
    public Text SuncountT;
    public GameObject userEvent;
    public int[] plantCosts;
    // Start is called before the first frame update
    void Start()
    {
        updateSunCount(0);
    }

    // Update is called once per frame
    void Update()
    {
        checkButtonActive(); //update when cooldown is added
    }

    public void checkButtonActive()
    {
        for (int i = 0; i < plantCosts.Length; i++)
        {
            //Debug.Log(plantCosts[i]);
            //Debug.Log(System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text));
            //Debug.Log(plantCosts[i] <= System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text));
            if ((plantCosts[i] <= System.Convert.ToInt32(GetComponent<canvas>().SuncountT.text)))
            {
                //Debug.Log("but");
                userEvent.GetComponent<UserEvent>().button[i].interactable = true;
            }
            else
            {
                userEvent.GetComponent<UserEvent>().button[i].interactable = false;
            }
        }
    }

    public void updateSunCount(int SunCost)
    {
        SuncountT.text = SunCost.ToString();
    }
}
